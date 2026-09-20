using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Helpers;
using JetLagStationRadiusifier.Common.Runners.Abstractions;
using Microsoft.AspNetCore.Components;

namespace JetLagStationRadiusifier.Blazor.Components.Shared;

partial class RadiusifierMainCard
{
    private int _selectedRadiusValue;
    private DistanceUnit _selectedDistanceUnit = DistanceUnit.Metres;
    private GameSize _selectedGameSize = GameSize.Medium;
    private string _catchmentColourHex = "#AA4A44"; // Nice "Brick Red" default colour

    [Inject]
    private ICatchmentRunner Runner { get; set; } = default!;

    private void RunRequest()
    {

    }

    private byte GetRedBytesFromHex() => ColourHelper.GetRedBytesFromHex(_catchmentColourHex);

    private byte GetGreenBytesFromHex() => ColourHelper.GetGreenBytesFromHex(_catchmentColourHex);

    private byte GetBlueBytesFromHex() => ColourHelper.GetBlueBytesFromHex(_catchmentColourHex);

    //private CatchmentRequestDto? BuildRequest()
    //{

    //}

    //private bool ValidateControls()
    //{

    //}
}
