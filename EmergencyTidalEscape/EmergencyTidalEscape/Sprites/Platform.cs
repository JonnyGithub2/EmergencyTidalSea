using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTidalEscape.Sprites
{
    internal class Platform : Sprite
    {
        private Game1 _root;

        public Platform(Game1 root, Vector2 Position, float width) : base(Position) 
        { 
            _root = root;
            this.Position = Position;
            this.SpriteWidth = width;
        }


    }
}
