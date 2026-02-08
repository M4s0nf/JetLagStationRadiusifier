using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Engine.Abstractions;
using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Models;
using JetLagStationRadiusifier.Common.Results;
using JetLagStationRadiusifier.Common.Runners.Abstractions;

namespace JetLagStationRadiusifier.Common.Runners;

public sealed class CatchmentRunner(ICatchmentEngine engine) : ICatchmentRunner
{
    private readonly ICatchmentEngine _engine = engine;

    private const double FeetToMetresFactor = 0.3048;

    public ServiceResult Run(CatchmentRequestDto request)
    {
        var radiusMetersRequest = NormaliseDistanceToMeters(request);
        if (radiusMetersRequest.IsSuccess == false)
        {
            return ServiceResult.Failure(radiusMetersRequest.ErrorMessage!);
        }

        var radius = Distance.FromMetres(radiusMetersRequest.Value);
        var borderColour = new Rgba(request.Red, request.Green, request.Blue);

        var catchmentDefinition = new CatchmentDefinition
        {
            Radius = radius,
            BorderColour = borderColour,
        };

        try
        {
            _engine.AddCatchments(request.InputKmlPath, request.OutputKmlPath, catchmentDefinition);
        }
        catch (Exception ex)
        {
            return ServiceResult.Failure($"An error occurred while processing the KML files: {ex.Message}");
        }

        return ServiceResult.Success();
    }

    private static ServiceResult<int> NormaliseDistanceToMeters(CatchmentRequestDto request)
    {
        var radiusValue = request.Radius;
        if (radiusValue <= 0)
        {
            return ServiceResult<int>.Failure("Radius must be a positive integer.");
        }

        if (request.RadiusUnit == DistanceUnit.Metres)
        {
            return ServiceResult<int>.Success(radiusValue);
        }
        
        if (request.RadiusUnit == DistanceUnit.Feet)
        {
            return ServiceResult<int>.Success((int)(radiusValue * FeetToMetresFactor));
        }

        return ServiceResult<int>.Failure("Unsupported distance unit.");
    }
}
