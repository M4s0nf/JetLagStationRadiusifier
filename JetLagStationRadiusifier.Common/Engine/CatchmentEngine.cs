using System.Globalization;
using System.Xml.Linq;
using JetLagStationRadiusifier.Common.Models;

namespace JetLagStationRadiusifier.Common.Engine;

public sealed class CatchmentEngine : ICatchmentEngine
{
    private const double EarthRadiusMeters = 6371000.0;
    private static readonly char[] Separators = [' ', '\n', '\r', '\t'];

    public void AddCatchments(string inputKmlPath, string outputKmlPath, CatchmentDefinition definition)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(inputKmlPath);
        ArgumentException.ThrowIfNullOrWhiteSpace(outputKmlPath);
        ArgumentNullException.ThrowIfNull(definition);

        if (File.Exists(inputKmlPath) == false)
        {
            throw new FileNotFoundException("Input KML not found.", inputKmlPath);
        }

        // Minimal validation beyond what Distance already guarantees
        var segments = definition.Segments;
        if (definition.Segments < 8)
        {
            throw new InvalidOperationException($"Segments must be >= 8. segments. actual: {segments}");
        }

        XNamespace kmlNamespace = "http://www.opengis.net/kml/2.2";

        var kmlDoc = XDocument.Load(inputKmlPath);
        var root = kmlDoc.Root ?? throw new InvalidOperationException("Invalid KML: missing root element.");

        // Ensure <Document> exists
        var document = root.Element(kmlNamespace + "Document");
        if (document == null)
        {
            document = new XElement(kmlNamespace + "Document");
            root.Add(document);
        }

        // Style setup
        var styleId = BuildStyleId(definition);
        EnsureStyleExists(document, kmlNamespace, styleId, definition);

        // Create folder/layer for catchments
        var catchmentsFolder = new XElement(kmlNamespace + "Folder",
            new XElement(kmlNamespace + "name", definition.KmlLayerName)
        );

        // Materialize placemarks to avoid deferred enumeration surprises
        var stops = document
            .Descendants(kmlNamespace + "Placemark")
            .Where(pm => pm.Element(kmlNamespace + "Point") != null)
            .ToList();

        foreach (var stop in stops)
        {
            var name = (string?)stop.Element(kmlNamespace + "name") ?? "Stop";

            var coordText = stop
                .Descendants(kmlNamespace + "Point")
                .Elements(kmlNamespace + "coordinates")
                .Select(x => (x.Value ?? "").Trim())
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(coordText))
            {
                continue;
            }

            // KML coordinates may contain multiple tuples separated by whitespace; take first tuple
            var firstTuple = coordText
                .Split(Separators, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault();

            if (firstTuple == null)
            {
                continue;
            }

            // Tuple is: lon,lat[,alt]
            var parts = firstTuple.Split(',');
            if (parts.Length < 2)
                continue;

            if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var lat))
                continue;

            if (!double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var lon))
                continue;

            var coords = BuildCircleCoordinates(lat, lon, definition.Radius.Meters, definition.Segments);

            var polygonPlacemark = new XElement(kmlNamespace + "Placemark",
                new XElement(kmlNamespace + "name", $"{name} ({FormatRadius(definition.Radius.Meters)})"),
                new XElement(kmlNamespace + "styleUrl", $"#{styleId}"),
                new XElement(kmlNamespace + "Polygon",
                    new XElement(kmlNamespace + "tessellate", "1"),
                    new XElement(kmlNamespace + "outerBoundaryIs",
                        new XElement(kmlNamespace + "LinearRing",
                            new XElement(kmlNamespace + "coordinates", coords)
                        )
                    )
                )
            );

            catchmentsFolder.Add(polygonPlacemark);
        }

        document.Add(catchmentsFolder);
        kmlDoc.Save(outputKmlPath);
    }

    private static string BuildStyleId(CatchmentDefinition definition)
    {
        // Keeps it stable and somewhat unique. You can simplify to a constant if you prefer.
        // Avoid spaces and weird chars in XML id.
        var r = (int)Math.Round(definition.Radius.Meters);
        return $"catchment-{r}m";
    }

    private static void EnsureStyleExists(XElement document, XNamespace k, string styleId, CatchmentDefinition definition)
    {
        var exists = document.Elements(k + "Style")
                             .Any(s => (string?)s.Attribute("id") == styleId);

        if (exists) return;

        document.AddFirst(
            new XElement(k + "Style",
                new XAttribute("id", styleId),
                new XElement(k + "LineStyle",
                    new XElement(k + "color", definition.FillColor.ToKmlColor()),
                    new XElement(k + "width", "1.5")
                ),
                new XElement(k + "PolyStyle",
                    new XElement(k + "color", definition.FillColor.ToKmlColor()),
                    new XElement(k + "fill", "1"),
                    new XElement(k + "outline", "1")
                )
            )
        );
    }

    private static string BuildCircleCoordinates(double latDeg, double lonDeg, double radiusMeters, int segments)
    {
        var coords = new string[segments + 1];
        var step = 360.0 / segments;

        for (int i = 0; i < segments; i++)
        {
            var bearing = i * step;
            var (lat2, lon2) = DestinationPoint(latDeg, lonDeg, bearing, radiusMeters);
            coords[i] = string.Create(CultureInfo.InvariantCulture, $"{lon2},{lat2},0");
        }

        coords[segments] = coords[0]; // close ring
        return string.Join(" ", coords);
    }

    private static (double latDeg, double lonDeg) DestinationPoint(double latDeg, double lonDeg, double bearingDeg, double distanceM)
    {
        var lat1 = ToRad(latDeg);
        var lon1 = ToRad(lonDeg);
        var brng = ToRad(bearingDeg);
        var dr = distanceM / EarthRadiusMeters;

        var lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(dr) +
                             Math.Cos(lat1) * Math.Sin(dr) * Math.Cos(brng));

        var lon2 = lon1 + Math.Atan2(Math.Sin(brng) * Math.Sin(dr) * Math.Cos(lat1),
                                     Math.Cos(dr) - Math.Sin(lat1) * Math.Sin(lat2));

        // Normalize to [-180, 180)
        var lonDegNorm = ((ToDeg(lon2) + 540) % 360) - 180;

        return (ToDeg(lat2), lonDegNorm);
    }

    private static double ToRad(double deg) => deg * Math.PI / 180.0;
    private static double ToDeg(double rad) => rad * 180.0 / Math.PI;

    private static string FormatRadius(double meters)
        => $"{Math.Round(meters)}m";
}
