using ImGuiNET;

namespace UOLandscapeTools.UI.Windows
{
    public sealed class ToolsWindow : Window, IToolsWindow
    {
        private readonly IGenerateBitmapTemplatesWindow _generateBitmapTemplatesWindow;

        public ToolsWindow(IGenerateBitmapTemplatesWindow generateBitmapTemplatesWindow)
        {
            _generateBitmapTemplatesWindow = generateBitmapTemplatesWindow;
            _isVisible = true;
        }

        public override bool Show(uint dockSpaceId)
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(120, 450));
            ImGui.SetNextWindowDockID(dockSpaceId);



            if (ImGui.Begin("Tools", ref _isVisible, ImGuiWindowFlags.NoResize))
            {
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255)); 
                ImGui.Text("Step 1 - Define Color Map");
                ImGui.PopStyleColor();
                ImGui.Text("This is optional");
                ImGui.Spacing();
                ImGui.Button("test");
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255));
                ImGui.Text("Step 2 - Generate Bitmaps");
                ImGui.PopStyleColor();
                ImGui.Spacing();
                if (ImGui.Button("Bitmap Templates"))
                {
                    _generateBitmapTemplatesWindow.ToggleVisibility();
                }
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255));
                ImGui.Text("Step 3");
                ImGui.PopStyleColor();
                ImGui.Spacing();
                ImGui.Button("test");
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255));
                ImGui.Text("Step 4");
                ImGui.PopStyleColor();
                ImGui.Spacing();
                ImGui.Button("test");
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255));
                ImGui.Text("Step 5");
                ImGui.PopStyleColor();
                ImGui.Spacing();
                ImGui.Button("test");
                //================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(255, 0, 0, 255));
                ImGui.Text("Step 6");
                ImGui.PopStyleColor();
                ImGui.Spacing();
                ImGui.Button("test");
                //================================
                ImGui.End();
                return true;
            }

            return false;
        }
    }
}
