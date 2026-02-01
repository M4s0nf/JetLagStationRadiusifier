namespace JetLagStationRadiusifier.Common.Infrastructure.Kml;

/// <summary>
/// A representation of the KML XML schema used to remove use of 
/// strinsg inline in-engine.
/// </summary>
public static class KmlSchema
{
    public const string NamespaceUri = "http://www.opengis.net/kml/2.2";

    public const string Document = "Document";
    public const string Folder = "Folder";
    public const string Name = "name";

    public const string Placemark = "Placemark";
    public const string Point = "Point";
    public const string Coordinates = "coordinates";

    public const string Style = "Style";
    public const string StyleIdAttribute = "id";
    public const string StyleUrl = "styleUrl";

    public const string LineStyle = "LineStyle";
    public const string PolyStyle = "PolyStyle";
    public const string Color = "color";
    public const string Width = "width";
    public const string Fill = "fill";
    public const string Outline = "outline";

    public const string Polygon = "Polygon";
    public const string Tessellate = "tessellate";
    public const string OuterBoundaryIs = "outerBoundaryIs";
    public const string LinearRing = "LinearRing";

    public const string DefaultStationName = "Station";
    public const string RingAltitude = "0";
    public const string TessellateOn = "1";
    public const string FillOn = "1";
    public const string OutlineOn = "1";
    public const string LineWidth = "1.5";
}
