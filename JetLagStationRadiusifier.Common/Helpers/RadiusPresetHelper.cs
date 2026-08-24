using JetLagStationRadiusifier.Common.Enums;
using System.Collections.Frozen;

namespace JetLagStationRadiusifier.Common.Helpers;

public static class RadiusPresetHelper
{
    private static readonly FrozenDictionary<GameSize, int> _metres =
        new Dictionary<GameSize, int>
        {
            { GameSize.Small, 400 },
            { GameSize.Medium, 400 },
            { GameSize.Large, 800 },
        }.ToFrozenDictionary();

    private static readonly FrozenDictionary<GameSize, int> _feet =
        new Dictionary<GameSize, int>
        {
            { GameSize.Small, 1320 },
            { GameSize.Medium, 1320 },
            { GameSize.Large, 2640 },
        }.ToFrozenDictionary();

    public static int GetPreset(DistanceUnit unit, GameSize size)
    {
        if (size == GameSize.Custom)
        {
            return 1000;
        }

        // decide which dictionary to use based on unit user is using
        var presets = unit switch
        {
            DistanceUnit.Metres => _metres,
            DistanceUnit.Feet => _feet,
            _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Unhandled distance unit.")
        };

        return presets[size];
    }
}
