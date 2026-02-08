using JetLagStationRadiusifier.Common.Enums;

namespace JetLagStationRadiusifier.Common.Contracts;

public sealed record CatchmentRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public required string InputKmlPath { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string OutputKmlPath { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int Radius { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required DistanceUnit RadiusUnit { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required byte Red { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required byte Green { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required byte Blue { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public string LayerName { get; init; } = "Stations";
}
