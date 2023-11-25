using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmergencyTidalEscape.Sprites
{
    class Background : Sprite
    {
        Game1 _root;
        private Vector2 _position;
        public Background(Game1 root, Vector2 positions) : base(positions)
        {
            _root = root;
            _position = positions;
            SpriteWidth = 1000;
            LoadContent();
        }

        public void LoadContent()
        {
            SpriteImage = _root.Content.Load<Texture2D>("big-beach");
        }
    }
}
