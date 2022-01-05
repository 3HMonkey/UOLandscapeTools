using UOLandscapeTools.UI.Windows;

namespace UOLandscapeTools.UI
{
    public sealed class WindowService : IWindowService
    {

        public IDockSpaceWindow DockSpaceWindow { get; }
        public WindowService(

            IDockSpaceWindow dockSpaceWindow
            )
        {

            DockSpaceWindow = dockSpaceWindow;

        }
    }
}
