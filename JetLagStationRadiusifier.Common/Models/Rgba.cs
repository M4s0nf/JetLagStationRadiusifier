namespace JetLagStationRadiusifier.Common.Models;

/// <summary>
/// RGBA struct which can convert to colour used by .kml (Hex)
/// </summary>
public readonly record struct Rgba(byte R, byte G, byte B, byte A = 255)
{
    public string ToKmlColor() => $"{A:X2}{B:X2}{G:X2}{R:X2}";
}
