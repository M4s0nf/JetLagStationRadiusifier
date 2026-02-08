namespace JetLagStationRadiusifier.Common.Models;

/// <summary>
/// Represents a positive distance measured in meters.
/// Guarantees value is valid at creation time.
/// </summary>
public readonly struct Distance
{
    public double Metres { get; }

    private Distance(double meters)
    {
        if (meters <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(meters), "Distance must be greater than zero."); 
        }

        Metres = meters;
    }

    public static Distance FromMetres(double meters) => new(meters);
}
