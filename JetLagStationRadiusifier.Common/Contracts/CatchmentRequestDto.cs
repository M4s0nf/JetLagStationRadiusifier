using JetLagStationRadiusifier.Common.Enums;

namespace JetLagStationRadiusifier.Common.Contracts;

public sealed record CatchmentRequestDto
{
    /// <summary>
    /// The input stream of the source KML file.
    /// </summary>
    public required Stream InputKmlStream { get; init; }

    /// <summary>
    /// The value of the circumferance radius selected by the user.
    /// See RadiusUnit for the units of the radius.
    /// </summary>
    public required int Radius { get; init; }

    /// <summary>
    /// The unit that Radius is in
    /// </summary>
    public required DistanceUnit RadiusUnit { get; init; }

    /// <summary>
    /// The amount of red for the colour of the drawn radius.
    /// </summary>
    public required byte Red { get; init; }

    /// <summary>
    /// The amount of green for the colour of the drawn radius.
    /// </summary>
    public required byte Green { get; init; }

    /// <summary>
    /// The amount of blue for the colour of the drawn radius.
    /// </summary>
    public required byte Blue { get; init; }
}
