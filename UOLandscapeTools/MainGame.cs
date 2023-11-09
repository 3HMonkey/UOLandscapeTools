using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Imgui.Renderer;
using Serilog;
using UOLandscapeTools.Components.GenerateBitmapTemplates;
using UOLandscapeTools.Components.GenerateColorTable;
using UOLandscapeTools.UI;

namespace UOLandscapeTools
{
    public class MainGame : Game
    {
        private readonly ILogger _logger;
        private readonly IWindowService _windowService;
        private readonly ITerrainColorMapProvider _terrainColorMapProvider;
        private readonly IMapInfoProvider _mapInfoProvider;
        private ImGuiRenderer _imGuiRenderer;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static uint LeftDockspaceID = 1;
        public static uint ButtonDockspaceID = 2;

        public MainGame(ILogger logger, IWindowService windowService, IMapInfoProvider mapInfoProvider, ITerrainColorMapProvider terrainColorMapProvider)
        {
            _logger = logger;
            _mapInfoProvider = mapInfoProvider;
            _terrainColorMapProvider = terrainColorMapProvider;

            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _windowService = windowService;
            _graphics = new GraphicsDeviceManager(this)
            {

                PreferMultiSampling = true,
                IsFullScreen = false,
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight,
                GraphicsProfile = GraphicsProfile.HiDef,
            };


        }

        protected override void Initialize()
        {
            _logger.Information("Initializing renderer...");
            _imGuiRenderer = new ImGuiRenderer(this);
            _imGuiRenderer.RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags = ImGuiConfigFlags.DockingEnable;

            // Workaround for window sizes
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
            _logger.Information("Initializing renderer...Done");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // =====================================
            // Spritebatch
            _spriteBatch.Begin();


            _spriteBatch.End();
            // =====================================
            // Imgui Renderer begin layout
            _imGuiRenderer.BeforeLayout(this, gameTime);
            // Imgui code
            ImGuiLayout();
            // Imgui Renderer end layout
            _imGuiRenderer.AfterLayout();
            // =====================================
            base.Draw(gameTime);
        }

        private void ImGuiLayout()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("Menu"))
                {
                    //if( ImGui.MenuItem("New", "Ctrl+N", false, true) ) NewProjectWindow.IsVisible = !NewProjectWindow.IsVisible;
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("View"))
                {
                    if (ImGui.MenuItem("Tools", null, _windowService.ToolsWindow.IsVisible, true))
                    {
                        _windowService.ToolsWindow.ToggleVisibility();
                    }
                    
                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }
            if (_windowService.DockSpaceMainWindow.IsVisible)
            {
                _windowService.DockSpaceMainWindow.Show(ButtonDockspaceID);
            }
            if (_windowService.DockSpaceLeftWindow.IsVisible)
            {
                _windowService.DockSpaceLeftWindow.Show(LeftDockspaceID);
            }
            if (_windowService.ToolsWindow.IsVisible)
            {
                _windowService.ToolsWindow.Show(LeftDockspaceID);

            }
            if (_windowService.GenerateBitmapTemplatesWindow.IsVisible)
            {
                _windowService.GenerateBitmapTemplatesWindow.Show(ButtonDockspaceID);

            }

        }
    }
}
