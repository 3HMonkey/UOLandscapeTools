using UOLandscapeTools.UI.Windows;

namespace UOLandscapeTools.UI
{
    public sealed class WindowService : IWindowService
    {

        public IDockSpaceWindow DockSpaceWindow { get; }
        public IToolsWindow ToolsWindow { get; }
        public WindowService(

            IDockSpaceWindow dockSpaceWindow,
            IToolsWindow toolsWindow
            )
        {

            DockSpaceWindow = dockSpaceWindow;
            ToolsWindow = toolsWindow;

        }
    }
}
