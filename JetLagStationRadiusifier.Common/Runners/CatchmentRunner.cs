using JetLagStationRadiusifier.Common.Engine.Abstractions;
using JetLagStationRadiusifier.Common.Results;
using JetLagStationRadiusifier.Common.Runners.Abstractions;

namespace JetLagStationRadiusifier.Common.Runners;

public sealed class CatchmentRunner(ICatchmentEngine engine) : ICatchmentRunner
{
    private readonly ICatchmentEngine _engine = engine;

    public ServiceResult Run()
    {
        _engine.AddCatchments();
    }
}
