using System.Globalization;
using System.Xml.Linq;
using JetLagStationRadiusifier.Common.Helpers;
using JetLagStationRadiusifier.Common.Infrastructure.Kml;
using JetLagStationRadiusifier.Common.Models;

namespace JetLagStationRadiusifier.Common.Engine;

public sealed class CatchmentEngine : ICatchmentEngine
{
    private const double EarthRadiusMeters = 6371000.0;

    // KML coordinate tuples can be separated by various whitespace characters.
    private static readonly char[] CoordinateTupleSeparators = [' ', '\n', '\r', '\t'];

    /// <inheritdoc/>
    public void AddCatchments(string inputKmlPath, string outputKmlPath, CatchmentDefinition definition)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(inputKmlPath);
        ArgumentException.ThrowIfNullOrWhiteSpace(outputKmlPath);
        ArgumentNullException.ThrowIfNull(definition);

        if (File.Exists(inputKmlPath) == false)
        {
            throw new FileNotFoundException("Input KML not found.", inputKmlPath);
        }

        // We want a reasonably smooth circle. Very low segment counts look visibly polygonal.
        if (definition.Segments < 8)
        {
            throw new InvalidOperationException($"Segments must be >= 8. actual: {definition.Segments}");
        }

        XNamespace kmlNamespace = KmlSchema.NamespaceUri;

        var kmlDocument = XDocument.Load(inputKmlPath);
        var rootElement = kmlDocument.Root ?? throw new InvalidOperationException("Invalid KML: missing root element.");

        var documentElement = rootElement.Element(kmlNamespace + KmlSchema.Document);
        if (documentElement == null)
        {
            // Some KML files might be missing <Document>. We create it to keep output consistent.
            documentElement = new XElement(kmlNamespace + KmlSchema.Document);
            rootElement.Add(documentElement);
        }

        var styleId = BuildStyleId(definition);
        EnsureStyleExists(documentElement, kmlNamespace, styleId, definition);

        var catchmentsFolderElement = new XElement(
            kmlNamespace + KmlSchema.Folder,
            new XElement(kmlNamespace + KmlSchema.Name, definition.KmlLayerName)
        );

        // Materialize to a list: we'll be adding new nodes under <Document> and don't want deferred-enum surprises.
        var stationPlacemarks = documentElement
            .Descendants(kmlNamespace + KmlSchema.Placemark)
            .Where(placemark => placemark.Element(kmlNamespace + KmlSchema.Point) != null)
            .ToList();

        foreach (var stationPlacemark in stationPlacemarks)
        {
            var stationName = (string?)stationPlacemark.Element(kmlNamespace + KmlSchema.Name)
                ?? KmlSchema.DefaultStationName;

            var coordinateText = stationPlacemark
                .Descendants(kmlNamespace + KmlSchema.Point)
                .Elements(kmlNamespace + KmlSchema.Coordinates)
                .Select(element => (element.Value ?? string.Empty).Trim())
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(coordinateText))
            {
                continue;
            }

            // KML <coordinates> can contain multiple tuples; the first is enough for a Point.
            var firstCoordinateTuple = coordinateText
                .Split(CoordinateTupleSeparators, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault();

            if (firstCoordinateTuple == null)
            {
                continue;
            }

            // Tuple format: lon,lat[,alt]
            var tupleParts = firstCoordinateTuple.Split(',');
            if (tupleParts.Length < 2)
            {
                continue;
            }

            var parsedLatitude = double.TryParse(tupleParts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double latitudeDegrees);
            if (parsedLatitude == false)
            {
                continue;
            }

            var parsedLongitude = double.TryParse(tupleParts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double longitudeDegrees);
            if (parsedLongitude == false)
            {
                continue;
            }

            var circleCoordinates = BuildCircleCoordinates(
                latitudeDegrees, longitudeDegrees, definition.Radius.Metres, definition.Segments
            );

            var catchmentPlacemarkElement =
                new XElement(kmlNamespace + KmlSchema.Placemark,
                    new XElement(kmlNamespace + KmlSchema.Name, $"{stationName} ({FormatRadius(definition.Radius.Metres)})"),
                    new XElement(kmlNamespace + KmlSchema.StyleUrl, $"#{styleId}"),
                    new XElement(kmlNamespace + KmlSchema.Polygon,
                        new XElement(kmlNamespace + KmlSchema.Tessellate, KmlSchema.TessellateOn),
                        new XElement(kmlNamespace + KmlSchema.OuterBoundaryIs,
                            new XElement(kmlNamespace + KmlSchema.LinearRing,
                                new XElement(kmlNamespace + KmlSchema.Coordinates, circleCoordinates)))));

            catchmentsFolderElement.Add(catchmentPlacemarkElement);
        }

        documentElement.Add(catchmentsFolderElement);
        kmlDocument.Save(outputKmlPath);
    }

    private static string BuildStyleId(CatchmentDefinition definition)
    {
        // Keep the ID stable and XML-friendly. Radius is the main differentiator.
        int radiusMetresRounded = (int)Math.Round(definition.Radius.Metres);
        return $"catchment-{radiusMetresRounded}m";
    }

    private static void EnsureStyleExists(
        XElement documentElement,
        XNamespace kmlNamespace,
        string styleId,
        CatchmentDefinition definition)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(styleId);

        var styleAlreadyExists = documentElement
            .Elements(kmlNamespace + KmlSchema.Style)
            .Any(styleElement => (string?)styleElement.Attribute(KmlSchema.StyleIdAttribute) == styleId);

        if (styleAlreadyExists)
        {
            return;
        }

        // Keep styling logic centralized so it can evolve without touching XML-writing code.
        (string borderKmlColour, string fillKmlColour) = KmlColorRules.DeriveBorderAndFill(definition);

        var styleElement =
            new XElement(kmlNamespace + KmlSchema.Style,
                new XAttribute(KmlSchema.StyleIdAttribute, styleId),
                new XElement(kmlNamespace + KmlSchema.LineStyle,
                    new XElement(kmlNamespace + KmlSchema.Color, borderKmlColour),
                    new XElement(kmlNamespace + KmlSchema.Width, KmlSchema.LineWidth)),
                new XElement(kmlNamespace + KmlSchema.PolyStyle,
                    new XElement(kmlNamespace + KmlSchema.Color, fillKmlColour),
                    new XElement(kmlNamespace + KmlSchema.Fill, KmlSchema.FillOn),
                    new XElement(kmlNamespace + KmlSchema.Outline, KmlSchema.OutlineOn)));

        // Add near the top so styles are easy to find when inspecting output.
        documentElement.AddFirst(styleElement);
    }

    private static string BuildCircleCoordinates(double latitudeDegrees, double longitudeDegrees, double radiusMeters, int segments)
    {
        var coordinateTuples = new string[segments + 1];
        var stepDegrees = 360.0 / segments;

        for (int segmentIndex = 0; segmentIndex < segments; segmentIndex++)
        {
            var bearingDegrees = segmentIndex * stepDegrees;

            (var destinationLatitude, var destinationLongitude) = DestinationPoint(latitudeDegrees, longitudeDegrees, bearingDegrees, radiusMeters);

            coordinateTuples[segmentIndex] = string.Create(
                CultureInfo.InvariantCulture,
                $"{destinationLongitude},{destinationLatitude},{KmlSchema.RingAltitude}"
            );
        }

        // KML rings must repeat the first coordinate at the end to "close" the polygon.
        coordinateTuples[segments] = coordinateTuples[0];

        return string.Join(" ", coordinateTuples);
    }

    private static (double latDeg, double lonDeg) DestinationPoint(
        double latitudeDegrees,
        double longitudeDegrees,
        double bearingDegrees,
        double distanceMeters)
    {
        var latitudeRadians = ToRadians(latitudeDegrees);
        var longitudeRadians = ToRadians(longitudeDegrees);
        var bearingRadians = ToRadians(bearingDegrees);

        double angularDistance = distanceMeters / EarthRadiusMeters;

        var destinationLatitudeRadians =
            Math.Asin(
                Math.Sin(latitudeRadians) * Math.Cos(angularDistance) +
                Math.Cos(latitudeRadians) * Math.Sin(angularDistance) * Math.Cos(bearingRadians));

        var destinationLongitudeRadians =
            longitudeRadians +
            Math.Atan2(
                Math.Sin(bearingRadians) * Math.Sin(angularDistance) * Math.Cos(latitudeRadians),
                Math.Cos(angularDistance) - Math.Sin(latitudeRadians) * Math.Sin(destinationLatitudeRadians));

        // KML longitudes should be normalized to [-180, 180) to avoid wrapping artefacts.
        var destinationLongitudeDegreesNormalised = ((ToDegrees(destinationLongitudeRadians) + 540) % 360) - 180;
        return (ToDegrees(destinationLatitudeRadians), destinationLongitudeDegreesNormalised);
    }

    private static double ToRadians(double degrees) => degrees * Math.PI / 180.0;

    private static double ToDegrees(double radians) => radians * 180.0 / Math.PI;

    private static string FormatRadius(double meters) => $"{Math.Round(meters)}m";
}
