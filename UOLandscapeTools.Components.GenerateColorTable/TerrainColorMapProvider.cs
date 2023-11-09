using Serilog;
using UOLandscapeTools.Components.GenerateColorTable.Models;
using UOLandscapeTools.IO;

namespace UOLandscapeTools.Components.GenerateColorTable
{
    public sealed class TerrainColorMapProvider : ITerrainColorMapProvider
    {
        private readonly ILogger _logger;
        private readonly IJSONDataLoader _JSONDataLoader;
        private readonly IJSONDataSaver _JSONDataSaver;
        public List<TerrainColorMapEntry> TerrainColorMap { get; private set; }

        public TerrainColorMapProvider(ILogger logger, IJSONDataLoader jSONDataLoader, IJSONDataSaver jSONDataSaver)
        {
            _logger = logger;
            _JSONDataLoader = jSONDataLoader;
            _JSONDataSaver = jSONDataSaver;
            TerrainColorMap = new List<TerrainColorMapEntry>();
            this.Load();
        }

        public void Load()
        {
            Directory.CreateDirectory("Data/Meta");
            TerrainColorMap = _JSONDataLoader.LoadData<List<TerrainColorMapEntry>>("Data/Meta/Terrain.json");

            if (TerrainColorMap is null)
            {
                TerrainColorMap = new DefaultTerrainColorMap().TerrainColorMap;
                Save();
            }
        }

        public void Save()
        {
            _JSONDataSaver.SaveData("Data/Meta/Terrain.json", TerrainColorMap);
        }
    }
}
