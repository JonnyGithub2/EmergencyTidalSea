using EmergencyTidalEscape.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmergencyTidalEscape.RenderingGlobals;
namespace EmergencyTidalEscape
{
    public class Wave
    {
        private Game1 _root;
        

        private float _waveHeight; //float between 1 and 0 showing how close it is to reaching top of screen (1 = top, 0 = bottom)
        private float _waveScroll; //maybe wave should scroll sideways and this will track that? 1 to 0;
        public Texture2D _waveTexture; // the texture of the wave
        public Wave(Game1 root)
        {
            _root = root;
            _waveTexture = _root.Content.Load<Texture2D>("WaveTexture");
            _waveHeight = 0;
            _waveScroll = 0;
        }
        public void Render()
        {
            Vector2 waveLocation1 = new Vector2(ScreenWidthGlobal * _waveScroll, ScreenHeightGlobal * (1 - _waveHeight));
            Vector2 waveLocation2 = new Vector2(ScreenWidthGlobal * (_waveScroll - 1), ScreenHeightGlobal * (1 - _waveHeight));
            SpriteBatchGlobal.Draw(_waveTexture, new Rectangle((int)waveLocation1.X, (int)waveLocation1.Y, 900, 900), Color.White);
            SpriteBatchGlobal.Draw(_waveTexture, new Rectangle((int)waveLocation2.X, (int)waveLocation2.Y, 900, 900), Color.White);



        }

        public void Rise(float heightToRise)
        {
            _waveHeight += heightToRise;
        }
        public void Scroll()
        {
            _waveScroll += 0.01f;
            if (_waveScroll >= 1)
            {
                _waveScroll -= 1;
            }
        }



    }
}
