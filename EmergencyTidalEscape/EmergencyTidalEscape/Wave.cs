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
        private float _waveHeight; //float between 1 and 0 showing how close it is to reaching top of screen (1 = top, 0 = bottom)
        private float _waveScroll; //maybe wave should scroll sideways and this will track that? 1 to 0;
        public Texture2D _waveTexture; // the texture of the wave
        public Wave()
        {
            _waveTexture = TextureLoaderGlobal.LoadTexture("WaveTexture");
            _waveHeight = 0;
            _waveScroll = 0;
        }
        public void Render()
        {
            Vector2 waveLocation1 = new Vector2(ScreenWidthGlobal * _waveScroll, ScreenHeightGlobal * (1 - _waveHeight));
            Vector2 waveLocation2 = new Vector2(ScreenWidthGlobal *( _waveScroll - 1), ScreenHeightGlobal * (1 - _waveHeight));
            SpriteBatchGlobal.Draw(_waveTexture, waveLocation1, Color.White);
            SpriteBatchGlobal.Draw(_waveTexture, waveLocation2, Color.White);

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
