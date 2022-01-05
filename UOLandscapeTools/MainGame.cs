using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame.Imgui.Renderer;
using Serilog;

namespace UOLandscapeTools
{
    public class MainGame : Game
    {
        private readonly ILogger _logger;
        private ImGuiRenderer _imGuiRenderer;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public MainGame(ILogger logger)
        {
            _logger = logger;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _logger.Information("Initializing renderer...");
            _imGuiRenderer = new ImGuiRenderer(this);
            _imGuiRenderer.RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags = ImGuiConfigFlags.DockingEnable;
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
            _imGuiRenderer.BeforeLayout(gameTime);
            // Imgui code
            ImGui.Text("Test");
            // Imgui Renderer end layout
            _imGuiRenderer.AfterLayout();
            // =====================================
            base.Draw(gameTime);
        }
    }
}
