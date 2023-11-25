using EmergencyTidalEscape.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static EmergencyTidalEscape.RenderingGlobals;
namespace EmergencyTidalEscape
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        KeyboardState currentKeyboardState;
        private SpriteBatch _spriteBatch;
        private Wave _wave;
        private bool _showGame = false;
        private Background _background;
        private TitleScreen _titleScreen;
        private Player _player;
        private List<Sprite> _sprites;
        private Platform _platform;
        private int screenWidth = 900;
        public int ScreenWidth
        {
            get { return screenWidth; }
            set { screenWidth = value; }
        }

        private int screenHeight = 900;
        public int ScreenHeight
        {
            get { return screenHeight; }
            set { screenHeight = value; }
        }
        private Siren _siren;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
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
            _titleScreen = new TitleScreen(this, new Vector2 (0, 0));
            _background = new Background(this, new Vector2(0,0));
            _player = new Player(this, new Vector2(0.0f, 0.0f));
            _platform = new Platform(this, new Vector2(400, 200));

            _sprites = new List<Sprite>()
            {
                _platform,_player
            };


            SpriteBatchGlobal = _spriteBatch;
            ScreenHeightGlobal = screenHeight;
            ScreenWidthGlobal = screenWidth;
            TextureLoaderGlobal = new TextureLoader(this);

            _wave = new Wave(this);
            _siren = new Siren();
            _siren._enabled = true;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _wave.Scroll();
            _player.Update(gameTime, _sprites);
            _wave.Rise(0.0005f);
            _siren.Update();

            _showGame = false;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatchGlobal.Begin();


            
            if (_showGame = false)
            {
                _titleScreen.Draw(gameTime, _spriteBatch);

            }


            if (currentKeyboardState.IsKeyDown(Keys.Enter))
            {
                _showGame = true;
            }


            if (_showGame = true)
            {
                _background.Draw(gameTime, _spriteBatch);
                _player.Draw(gameTime, _spriteBatch);
                _platform.Draw(gameTime, _spriteBatch);
                _wave.Render();
            }











            //_siren.Render();
            SpriteBatchGlobal.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}