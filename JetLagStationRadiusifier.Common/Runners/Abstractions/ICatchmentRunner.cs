using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Results;

namespace JetLagStationRadiusifier.Common.Runners.Abstractions;

public interface ICatchmentRunner
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    ServiceResult Run(CatchmentRequestDto request);
}
