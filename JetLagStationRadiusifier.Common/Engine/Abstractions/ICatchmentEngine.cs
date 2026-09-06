using JetLagStationRadiusifier.Common.Models;
using System.Xml.Linq;

namespace JetLagStationRadiusifier.Common.Engine.Abstractions;

public interface ICatchmentEngine
{
    /// <summary>
    /// Adds catchment radius' to the provided .kml, outputting a new kml
    /// </summary>
    XDocument AddCatchments(XDocument kmlDocument, CatchmentDefinition definition);
}
