﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmergencyTidalEscape.RenderingGlobals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace EmergencyTidalEscape
{
    public abstract class Powerup
    {
        public bool _enabled;
        public Vector2 _location;
        public Texture2D _texture;
        public Powerup(Vector2 pLocation, Texture2D pTexture)
        {
            _enabled = true;
            _location = pLocation;
            _texture = pTexture;
        }
        public void OnPickup()
        {
            Console.WriteLine("Powerup Picked Up");
            _enabled = false;
        }
        public void Render()
        {
            if (_enabled)
            {
                SpriteBatchGlobal.Draw(_texture, _location, Color.White);
            }
        }
    }
    public class WaveFreeze : Powerup
    {
        public WaveFreeze(Vector2 pLocation) : base(pLocation, TextureLoaderGlobal.LoadTexture("WaveFreezeTexture"))
        {

        }
    }
}
