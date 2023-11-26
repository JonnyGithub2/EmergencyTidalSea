﻿using EmergencyTidalEscape.Levels;
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
        private WaveFreeze _powerupTest;
        public List<Powerup> _powerups;
        private bool _loadingLevel;
        private int _currentLevel;
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
        private void NextLevel()
        {
            foreach(Sprite sprite in _sprites)
            {
                sprite.FallAway();
            }
            LoadLevel(_currentLevel);
            _currentLevel++;
        }
        private void LoadLevel(int levelID)
        {
            _loadingLevel = true;
            Level level = Level.LoadLevel(levelID);
            foreach(Vector2 platformLocation in level.GetPlatformLocations())
            {
                _sprites.Add(new Platform(this, platformLocation));
            }
            foreach(Powerup powerup in level.GetPowerups())
            {
                _powerups.Add(powerup);
            }
            _player.Position = level._playerLocation;
            _loadingLevel = false;
        }
        private void Die()
        {
            _showGame = false;
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
            _wave = new Wave(this);
            _player = new Player(this, new Vector2(401f, 500f), _wave);
            _platform = new Platform(this, new Vector2(400, 200));
            _showGame = true;
            _loadingLevel = false;
            _currentLevel = 0;

            _sprites = new List<Sprite>()
            {
                _platform, _player, new Platform(this, new Vector2(400, 600)), new Platform(this, new Vector2(400, 400))
            };


            SpriteBatchGlobal = _spriteBatch;
            ScreenHeightGlobal = screenHeight;
            ScreenWidthGlobal = screenWidth;
            TextureLoaderGlobal = new TextureLoader(this);

            _siren = new Siren();
            _powerupTest = new WaveFreeze(new Vector2(400, 500));
            _powerups = new List<Powerup>();
            _powerups.Add(_powerupTest);
            _siren._enabled = true;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(!_loadingLevel)
            {
                _wave.Scroll();
                _player.Update(gameTime, _sprites);
                _wave.Rise(0.0005f);
                _siren.Update();
                foreach (var sprite in _sprites)
                {
                    if (sprite != _player)
                    {
                        sprite.UpdateFall();
                    }
                }
                _sprites.RemoveAll(sprite => sprite._dead);
                currentKeyboardState = Keyboard.GetState();
                if (currentKeyboardState[Keys.Enter] == KeyState.Down)
                {
                    _showGame = true;
                }
                if (_player._levelWon)
                {
                    NextLevel();
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatchGlobal.Begin(SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            SamplerState.PointClamp,
            DepthStencilState.None,
            RasterizerState.CullNone,
            null);



            if (_showGame == false)
            {
                _titleScreen.Draw(gameTime, _spriteBatch);

            }




            if (_showGame == true)
            {
                _background.Draw(gameTime, _spriteBatch);
                //_player.Draw(gameTime, _spriteBatch);
                //_platform.Draw(gameTime, _spriteBatch);
                foreach (Sprite sprite in _sprites)
                {
                    sprite.Draw(gameTime, _spriteBatch);
                }
                _wave.Render();
                if (_player._dangerLevel == 1)
                {
                    _siren.Render();
                }
                else if(_player._dangerLevel == 2)
                {
                    Die();
                }
                _powerupTest.Render();
            }











            //_siren.Render();
            SpriteBatchGlobal.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}