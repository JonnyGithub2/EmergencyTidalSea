using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EmergencyTidalEscape.Sprites;

namespace EmergencyTidalEscape.Sprites
{
    public abstract class Behaviour
    {
        protected Sprite _sprite;
        protected Behaviour(Sprite pSprite)
        {
            _sprite = pSprite;
        }

        public abstract Vector2 GetSteeringForce();
    }
    internal interface ITargetable
    {
        public Vector2 GetTargetPosition();
        public Vector2 GetVelocity() { return Vector2.Zero; }
    }
}
