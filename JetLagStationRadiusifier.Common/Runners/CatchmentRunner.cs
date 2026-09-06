using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Engine.Abstractions;
using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Models;
using JetLagStationRadiusifier.Common.Results;
using JetLagStationRadiusifier.Common.Runners.Abstractions;
using System.Xml.Linq;

namespace JetLagStationRadiusifier.Common.Runners;

public sealed class CatchmentRunner(ICatchmentEngine engine) : ICatchmentRunner
{
    private readonly ICatchmentEngine _engine = engine;

    private const double FeetToMetresFactor = 0.3048;

    public ServiceResult<XDocument> Run(CatchmentRequestDto request)
    {
        var radiusMetersRequest = NormaliseDistanceToMeters(request);
        if (radiusMetersRequest.IsSuccess == false)
        {
            return ServiceResult<XDocument>.Failure(radiusMetersRequest.ErrorMessage!);
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
            using var stream = request.InputKmlStream;
            var kmlDoc = XDocument.Load(stream);
            var radiusifiedKmlDoc = _engine.AddCatchments(kmlDoc, catchmentDefinition);
            return ServiceResult<XDocument>.Success(radiusifiedKmlDoc);
        }
        catch (Exception ex)
        {
            return ServiceResult<XDocument>.Failure($"An error occurred while processing the KML file: {ex.Message}");
        }
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
