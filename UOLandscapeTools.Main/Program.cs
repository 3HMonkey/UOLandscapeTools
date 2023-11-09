using Microsoft.Extensions.DependencyInjection;
using Serilog;
using UOLandscapeTools;
using UOLandscapeTools.Components.GenerateBitmapTemplates;
using UOLandscapeTools.Components.GenerateColorTable;
using UOLandscapeTools.IO;
using UOLandscapeTools.UI;
using UOLandscapeTools.UI.Windows;

internal class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        var logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("UOLandscapeTools.log", shared: true)
            .CreateLogger();

        logger.Information("Registering internal services...");
        //==============================================================
        services.AddSingleton<ILogger>(logger);
        services.AddSingleton<IJSONDataLoader, JSONDataLoader>();
        services.AddSingleton<IJSONDataSaver, JSONDataSaver>();
        //==============================================================
        // Register GenerateColotTable Component
        services.AddSingleton<ITerrainColorMapProvider, TerrainColorMapProvider>();
        // Register GenerateBitmapTemplates Component
        services.AddSingleton<IGenerateBitmapTemplates, GenerateBitmapTemplates>();
        services.AddSingleton<IMapInfoProvider, MapInfoProvider>();
        //==============================================================
        services.AddSingleton<IDockSpaceLeftWindow, DockSpaceLeftWindow>();
        services.AddSingleton<IDockSpaceMainWindow, DockSpaceMainWindow>();
        services.AddSingleton<IDebugWindow, DebugWindow>();
        services.AddSingleton<IToolsWindow, ToolsWindow>();
        services.AddSingleton<IGenerateBitmapTemplatesWindow, GenerateBitmapTemplatesWindow>();
        services.AddSingleton<IWindowService, WindowService>();
        //services.AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
        services.AddSingleton<MainGame>();
        //==============================================================
        logger.Information("Registering internal services...Done!");
        //Environment.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "1");

        var serviceProvider = services.BuildServiceProvider();
        using var game = serviceProvider.GetService<MainGame>();
        game.Run();
    }
}
