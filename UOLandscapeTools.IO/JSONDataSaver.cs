using Newtonsoft.Json;
using Serilog;

namespace UOLandscapeTools.IO
{
    public sealed class JSONDataSaver : IJSONDataSaver
    {
        private readonly ILogger _logger;

        public JSONDataSaver(ILogger logger)
        {
            _logger = logger;
        }

        public void SaveData<T>(string fileName, T data) where T : class
        {
            _logger.Information($"Writing file: {fileName}...");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(data, Formatting.Indented));
            _logger.Information($"Writing file: {fileName}...Done");
        }
    }
}
