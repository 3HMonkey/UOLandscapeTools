using Newtonsoft.Json;
using Serilog;

namespace UOLandscapeTools.IO
{
    public sealed class JSONDataLoader : IJSONDataLoader
    {
        private readonly ILogger _logger;

        public JSONDataLoader(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T LoadData<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName))
            {
                _logger.Warning($"File: '{fileName}' does not exist.");
                return null;
            }

            _logger.Information($"Loading file: {fileName}...");
            var DataContent = File.ReadAllText(fileName);
            _logger.Information($"Loading file: {fileName}...Done.");
            return JsonConvert.DeserializeObject<T>(DataContent);
        }
    }
}
