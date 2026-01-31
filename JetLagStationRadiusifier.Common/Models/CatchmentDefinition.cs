//using JetLagStationRadiusifier.Common.Enums;

namespace JetLagStationRadiusifier.Common.Models;

/// <summary>
/// Engine-ready specs required to draw the catchments.
/// </summary>
public sealed record CatchmentDefinition
{
    public required Distance Radius { get; init; }
    public required Rgba FillColor { get; init; }
    public string KmlLayerName { get; init; } = "Catchments";
    public int Segments { get; init; } = 64;
}
