using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static EmergencyTidalEscape.RenderingGlobals;
namespace EmergencyTidalEscape
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Wave _wave;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        public Texture2D LoadTexture(string pTextureName)
        {
            return Content.Load<Texture2D>(pTextureName);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteBatchGlobal = _spriteBatch;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            TextureLoaderGlobal = new TextureLoader(this);

            _wave = new Wave();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _wave.Scroll();
            _wave.Rise(0.0001f);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatchGlobal.Begin();
            _wave.Render();
            SpriteBatchGlobal.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}