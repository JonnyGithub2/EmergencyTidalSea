using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EmergencyTidalEscape.Sprites
{
    internal class Platform : Sprite
    {
        private Game1 _root;

        public Platform(Game1 root, Vector2 Position, float width) : base(Position) 
        { 
            _root = root;
            this.Position = Position;
            this.SpriteWidth = 700f;
            
            LoadContent();
            
        }
        public void LoadContent()
        {
            this.SpriteImage = _root.Content.Load<Texture2D>("platform_sprite");
        }


    }
}
