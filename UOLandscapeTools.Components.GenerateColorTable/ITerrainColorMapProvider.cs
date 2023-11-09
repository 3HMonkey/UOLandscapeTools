using UOLandscapeTools.Components.GenerateColorTable.Models;

namespace UOLandscapeTools.Components.GenerateColorTable
{
    public interface ITerrainColorMapProvider
    {
        List<TerrainColorMapEntry> TerrainColorMap { get; }

        void Save();

        void Load();
    }
}
