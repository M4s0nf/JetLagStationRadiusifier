using System.Drawing;

namespace JetLagStationRadiusifier.Common.Helpers;

public static class ColourHelper
{
    public static byte GetRedBytesFromHex(string hex)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(hex);
        var colour = ColorTranslator.FromHtml(hex);
        return colour.R;
    }

    public static byte GetGreenBytesFromHex(string hex)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(hex);
        var colour = ColorTranslator.FromHtml(hex);
        return colour.G;
    }

    public static byte GetBlueBytesFromHex(string hex)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(hex);
        var colour = ColorTranslator.FromHtml(hex);
        return colour.B;
    }
}
