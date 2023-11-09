using ImGuiNET;
using Serilog;
using UOLandscapeTools.Components.GenerateBitmapTemplates;
using UOLandscapeTools.Components.GenerateBitmapTemplates.Models;
using UOLandscapeTools.Components.GenerateColorTable;
using UOLandscapeTools.Components.GenerateColorTable.Models;
using Num = System.Numerics;

namespace UOLandscapeTools.UI.Windows
{
    public sealed class GenerateBitmapTemplatesWindow : Window, IGenerateBitmapTemplatesWindow
    {
        private readonly ILogger _logger;
        private readonly IMapInfoProvider _mapInfoProvider;
        private readonly ITerrainColorMapProvider _terrainColorMapProvider;
        private readonly IGenerateBitmapTemplates _generateBitmapTemplates;
        private Num.Vector3 _currentColor;
        private MapInfo _currentMapInfo;
        private TerrainColorMapEntry _currentTerrainColorMapEntry;
        



        public GenerateBitmapTemplatesWindow(ILogger logger, IMapInfoProvider mapInfoProvider, ITerrainColorMapProvider terrainColorMapProvider, IGenerateBitmapTemplates generateBitmapTemplates)
        {
            _logger = logger;
            _mapInfoProvider = mapInfoProvider;
            _terrainColorMapProvider = terrainColorMapProvider;
            _generateBitmapTemplates = generateBitmapTemplates;
            _isVisible = false;
            _currentMapInfo = _mapInfoProvider.MapInfos[0];
            _currentTerrainColorMapEntry = _terrainColorMapProvider.TerrainColorMap.Find(x => x.Name == "Deep Water");
            _currentColor = new Num.Vector3(
                                _currentTerrainColorMapEntry.Color.R,
                                _currentTerrainColorMapEntry.Color.G,
                                _currentTerrainColorMapEntry.Color.B);
        }

        public override bool Show(uint dockSpaceId)
        {
            
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(120, 450));
            ImGui.SetNextWindowDockID(dockSpaceId);


            if (ImGui.Begin("Bitmap Templates", ref _isVisible, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoBackground))
            {
                

                ImGui.Spacing();
                ImGui.Text("This component will generate empty bmp map templates. You can import it");
                ImGui.Text("in your favorite photo editing tool like Photoshop, Gimp, Paint etc.");
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Separator();
                ImGui.Text("Please select the map you plan generating a template image for!");
                ImGui.Spacing();
                //==================================================================================
                if (ImGui.BeginCombo("Choose Map", _currentMapInfo.Name))
                {
                    foreach (var item in _mapInfoProvider.MapInfos)
                    {
                        bool isSelected = _currentMapInfo.Name == item.Name;
                        if (ImGui.Selectable(item.Name, isSelected))
                        {
                            _currentMapInfo = item;
                        }
                        if (isSelected)
                        {
                            ImGui.SetItemDefaultFocus();
                        }
                    }

                    ImGui.EndCombo();
                }
                ImGui.Spacing();
                ImGui.SameLine(30); ImGui.Text($"Map Width: {_currentMapInfo.MapWidth}"); ImGui.SameLine(200); ImGui.Text($"Map Height: {_currentMapInfo.MapHeight}");
                //==================================================================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Separator();
                ImGui.Text("Please select the default color (map tile) to fill the map!");
                ImGui.Spacing();
                //==================================================================================
                if (ImGui.BeginCombo("Choose Default Tile", _currentTerrainColorMapEntry.Name))
                {
                    foreach (var item in _terrainColorMapProvider.TerrainColorMap)
                    {
                        bool isSelected = _currentTerrainColorMapEntry.Name == item.Name;
                        if (ImGui.Selectable(item.Name, isSelected))
                        {
                            _currentTerrainColorMapEntry = item;
                            _currentColor = new Num.Vector3(
                                _currentTerrainColorMapEntry.Color.R,
                                _currentTerrainColorMapEntry.Color.G,
                                _currentTerrainColorMapEntry.Color.B);
                        }
                        if (isSelected)
                        {
                            ImGui.SetItemDefaultFocus();
                            
                        }
                    }

                    ImGui.EndCombo();
                }
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.SetNextItemWidth(200);
                ImGui.ColorPicker3("Current Color", ref _currentColor);
                
                //==================================================================================
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Separator();
                ImGui.Spacing();

                if (ImGui.Button("Start generating templates"))
                {
                    string hex = _currentTerrainColorMapEntry.Color.R.ToString("X2") + _currentTerrainColorMapEntry.Color.G.ToString("X2") + _currentTerrainColorMapEntry.Color.B.ToString("X2");
                    _generateBitmapTemplates.MakeTerrainMap(_currentMapInfo.MapWidth, _currentMapInfo.MapHeight, hex);
                    

                }
                
                ImGui.End();

                return true;
            }

            return false;
        }
    }
}

