using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOLandscapeTools.UI.Windows
{
    public interface IWindow
    {
        bool IsVisible { get; }

        void Hide();

        void ToggleVisibility();

        bool Show(uint dockSpaceId);
    }
}
