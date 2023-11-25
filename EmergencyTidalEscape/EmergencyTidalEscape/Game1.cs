﻿using EmergencyTidalEscape.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static EmergencyTidalEscape.RenderingGlobals;
using EmergencyTidalEscape.Sprites;
namespace EmergencyTidalEscape
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Wave _wave;
        private Player _player;
        private int screenWidth = 1600;
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
        private Player _player;
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
            _player = new Player(this, new Vector2(0.0f, 0.0f));


            SpriteBatchGlobal = _spriteBatch;
            ScreenHeightGlobal = screenHeight;
            ScreenWidthGlobal = screenWidth;
            TextureLoaderGlobal = new TextureLoader(this);

            _player = new Player(this, new Vector2(0, 0));
            _wave = new Wave();
            _siren = new Siren();
            _siren._enabled = true;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _wave.Scroll();
            _player.Update(gameTime);
            _wave.Rise(0.0001f);
            _siren.Update();
            _player.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatchGlobal.Begin();
            _player.Draw(gameTime, _spriteBatch);
            _wave.Render();
            _siren.Render();
            _player.Draw(gameTime, _spriteBatch);
            SpriteBatchGlobal.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}