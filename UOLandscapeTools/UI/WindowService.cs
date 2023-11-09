using UOLandscapeTools.UI.Windows;

namespace UOLandscapeTools.UI
{
    public sealed class WindowService : IWindowService
    {

        public IDockSpaceLeftWindow DockSpaceLeftWindow { get; }
        public IDockSpaceMainWindow DockSpaceMainWindow { get; }
        public IToolsWindow ToolsWindow { get; }
        public IDebugWindow DebugWindow { get; }
        public IGenerateBitmapTemplatesWindow GenerateBitmapTemplatesWindow { get; }

        public WindowService(

            IDockSpaceLeftWindow dockSpaceLeftWindow,
            IDockSpaceMainWindow dockSpaceMainWindow,
            IToolsWindow toolsWindow,
            IDebugWindow debugWindow,
            IGenerateBitmapTemplatesWindow generateBitmapTemplatesWindow
            )
        {

            DockSpaceLeftWindow = dockSpaceLeftWindow;
            DockSpaceMainWindow = dockSpaceMainWindow;
            ToolsWindow = toolsWindow;
            DebugWindow = debugWindow;
            GenerateBitmapTemplatesWindow = generateBitmapTemplatesWindow;

        }
    }
}
