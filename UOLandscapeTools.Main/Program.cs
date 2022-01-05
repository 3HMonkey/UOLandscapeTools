using Microsoft.Extensions.DependencyInjection;
using Serilog;
using UOLandscapeTools;
using UOLandscapeTools.Components.GenerateBitmapTemplates;
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
        // Generate Bitmaps Component
        services.AddSingleton<IMapInfoProvider, MapInfoProvider>();
        //==============================================================
        services.AddSingleton<IDockSpaceWindow, DockSpaceWindow>();
        services.AddSingleton<IToolsWindow, ToolsWindow>();
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
