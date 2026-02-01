using JetLagStationRadiusifier.Common.Models;

namespace JetLagStationRadiusifier.Common.Engine.Abstractions;

public interface ICatchmentEngine
{
    /// <summary>
    /// Adds catchment radius' to the provided .kml, outputting a new kml
    /// </summary>
    void AddCatchments(string inputKmlPath, string outputKmlPath, CatchmentDefinition catchmentDefinition);
}
