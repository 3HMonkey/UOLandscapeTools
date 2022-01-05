using UOLandscapeTools.Components.GenerateBitmapTemplates.Models;

namespace UOLandscapeTools.Components.GenerateBitmapTemplates
{
    public interface IMapInfoProvider
    {
        List<MapInfo> MapInfos { get; }
        void Save();
        void Load();

    }
}
