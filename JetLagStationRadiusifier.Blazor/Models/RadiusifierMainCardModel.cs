using JetLagStationRadiusifier.Common.Enums;

namespace JetLagStationRadiusifier.Blazor.Models;

public sealed class RadiusifierMainCardModel
{
    public DistanceUnit RadiusUnit { get; set; } = DistanceUnit.Metres;
    public int RadiusValue { get; set; } = 1;
    public string ColourHex { get; set; } = "#AA4A44";
    public GameSize GameSize { get; set; } = GameSize.Small;
}
