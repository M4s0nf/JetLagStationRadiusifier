namespace JetLagStationRadiusifier.Common.Helpers;

public static class MathsHelper
{
    public static double ToRadians(double degrees) => degrees * Math.PI / 180.0;

    public static double ToDegrees(double radians) => radians * 180.0 / Math.PI;
}
