using Serilog;
using UOLandscapeTools.Components.GenerateBitmapTemplates.Models;
using UOLandscapeTools.IO;

namespace UOLandscapeTools.Components.GenerateBitmapTemplates
{
    public sealed class MapInfoProvider : IMapInfoProvider
    {
        private readonly ILogger _logger;
        private readonly IJSONDataLoader _JSONDataLoader;
        private readonly IJSONDataSaver _JSONDataSaver;
        public List<MapInfo> MapInfos { get; private set; }

        public MapInfoProvider(ILogger logger, IJSONDataLoader jSONDataLoader, IJSONDataSaver jSONDataSaver)
        {
            _logger = logger;
            _JSONDataLoader = jSONDataLoader;
            _JSONDataSaver = jSONDataSaver;
            MapInfos = new List<MapInfo>();
            this.Load();
        }

        public void Load()
        {
            Directory.CreateDirectory("Data/Meta");
            MapInfos = _JSONDataLoader.LoadData<List<MapInfo>>("Data/Meta/MapInfos.json");

            if (MapInfos is null)
            {
                MapInfos = new DefaultMapInfos().MapInfos;
                Save();
            }
        }

        public void Save()
        {
            _JSONDataSaver.SaveData("Data/Meta/MapInfos.json", MapInfos);
        }
    }
}
