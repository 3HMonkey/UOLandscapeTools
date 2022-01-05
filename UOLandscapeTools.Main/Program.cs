using Microsoft.Extensions.DependencyInjection;
using Serilog;
using UOLandscapeTools;

internal class Program
{
    public static void Main(string[] args)
    {
        Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
        var services = new ServiceCollection();
        var logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("UOLandscapeTools.log", shared: true)
            .CreateLogger();


        //==============================================================
        services.AddSingleton<ILogger>(logger);
        //services.AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
        services.AddSingleton<MainGame>();
        //==============================================================

        //Environment.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "1");

        var serviceProvider = services.BuildServiceProvider();
        using var game = serviceProvider.GetService<MainGame>();
        game.Run();
    }
}
