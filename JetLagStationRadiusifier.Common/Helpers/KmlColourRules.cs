namespace JetLagStationRadiusifier.Common.Helpers;

using JetLagStationRadiusifier.Common.Models;

public static class KmlColorRules
{
    /// <summary>
    /// 100% solid border
    /// </summary>
    private const byte BorderAlpha = 255;

    /// <summary>
    /// ~16% soft interior
    /// </summary>
    private const byte FillAlpha = 40;
    
    /// <summary>
    /// 
    /// </summary>
    public static (string BorderKmlColour, string FillKmlColour) DeriveBorderAndFill(CatchmentDefinition definition)
    {
        ArgumentNullException.ThrowIfNull(definition);

        var rgb = definition.BorderColour;
        var border = new Rgba(rgb.R, rgb.G, rgb.B, BorderAlpha);
        var fill = new Rgba(rgb.R, rgb.G, rgb.B, FillAlpha);

        return (border.ToKmlColor(), fill.ToKmlColor());
    }
}
