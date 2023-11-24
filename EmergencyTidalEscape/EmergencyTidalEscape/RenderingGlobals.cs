using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTidalEscape
{
    public static class RenderingGlobals
    {
        private static SpriteBatch _spriteBatch;
        public static SpriteBatch SpriteBatchGlobal
        {
            get => _spriteBatch;
            set => _spriteBatch = value;
        }
        private static int _screenHeight;
        public static int ScreenHeight
        {
            get => _screenHeight;
            set => _screenHeight = value;
        }
        private static int _screenWidth;
        public static int ScreenWidth
        {
            get => _screenWidth;
            set => _screenWidth = value;
        }
        private static TextureLoader _textureLoader;
        public static TextureLoader TextureLoaderGlobal
        {
            get => _textureLoader;
            set => _textureLoader = value;
        }
    }
    public class TextureLoader
    {
        private Game1 _game;
        public TextureLoader(Game1 pGame)
        {
            _game = pGame;
        }
        public Texture2D LoadTexture(string pTextureName)
        {
            return _game.LoadTexture(pTextureName);
        }
    }
}