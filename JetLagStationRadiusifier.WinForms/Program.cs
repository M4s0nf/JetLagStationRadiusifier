using JetLagStationRadiusifier.Common.Engine;
using JetLagStationRadiusifier.Common.Engine.Abstractions;
using JetLagStationRadiusifier.Common.Runners;
using JetLagStationRadiusifier.Common.Runners.Abstractions;
using JetLagStationRadiusifier.WinForms.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JetLagStationRadiusifier.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder(args);

        // Services
        builder.Services.AddSingleton<FrmMain>();
        builder.Services.AddSingleton<ICatchmentRunner, CatchmentRunner>();
        builder.Services.AddTransient<ICatchmentEngine, CatchmentEngine>();

        using var host = builder.Build();

        var mainForm = host.Services.GetRequiredService<FrmMain>();
        Application.Run(mainForm);
    }
}