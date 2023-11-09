using UOLandscapeTools.UI.Windows;

namespace UOLandscapeTools.UI
{
    public interface IWindowService
    {
        public IDockSpaceLeftWindow DockSpaceLeftWindow { get; }
        public IDockSpaceMainWindow DockSpaceMainWindow { get; }
        public IToolsWindow ToolsWindow { get; }
        public IDebugWindow DebugWindow { get; }
        public IGenerateBitmapTemplatesWindow GenerateBitmapTemplatesWindow { get; }


    }
}
