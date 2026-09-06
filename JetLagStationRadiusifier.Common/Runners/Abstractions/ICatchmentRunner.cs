using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Results;
using System.Xml.Linq;

namespace JetLagStationRadiusifier.Common.Runners.Abstractions;

public interface ICatchmentRunner
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    ServiceResult<XDocument> Run(CatchmentRequestDto request);
}
