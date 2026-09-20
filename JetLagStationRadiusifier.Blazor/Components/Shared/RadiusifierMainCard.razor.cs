using JetLagStationRadiusifier.Blazor.Models;
using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Helpers;
using JetLagStationRadiusifier.Common.Runners.Abstractions;
using Microsoft.AspNetCore.Components;

namespace JetLagStationRadiusifier.Blazor.Components.Shared;

partial class RadiusifierMainCard
{
    [Inject]
    private ICatchmentRunner Runner { get; set; } = default!;

    private RadiusifierMainCardModel _model = new();

    private void RunRequest()
    {

    }

    private byte GetRedBytesFromHex() => ColourHelper.GetRedBytesFromHex(_model.ColourHex);

    private byte GetGreenBytesFromHex() => ColourHelper.GetGreenBytesFromHex(_model.ColourHex);

    private byte GetBlueBytesFromHex() => ColourHelper.GetBlueBytesFromHex(_model.ColourHex);

    private void RecalculateRadiusValue()
    {
        var selectedGameSize = _model.GameSize;
        if (selectedGameSize == GameSize.Custom)
        {
            return;
        }

        _model.RadiusValue = RadiusPresetHelper.GetPreset(_model.RadiusUnit, selectedGameSize);
    }
}
