using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static EmergencyTidalEscape.RenderingGlobals;
namespace EmergencyTidalEscape
{
    public class Siren
    {
        public float _alpha;
        public bool _alphaChangeDirection; //true = alpha is decreasing, false = alpha is increasing
        public bool _enabled;
        public Texture2D _overlayTexture;
        private float _maxAlpha;
        private float _alphaChange;
        public Siren()
        {
            _alpha = 0f;
            _alphaChangeDirection = false;
            _enabled = false;
            _overlayTexture = TextureLoaderGlobal.LoadTexture("RedOverlay");

            _maxAlpha = 0.4f;
            _alphaChange = 0.015f;
        }
        public void Update()
        {
            if (_enabled)
            {
                if(_alphaChangeDirection)
                {
                    _alpha -= _alphaChange;
                }
                else
                {
                    _alpha += _alphaChange;
                }
                if (_alpha > _maxAlpha)
                {
                    _alphaChangeDirection = true;
                }
                else if (_alpha <= 0f)
                {
                    _alphaChangeDirection = false;
                }
            }
        }
        public void Render()
        {
            if (_enabled)
            {
                SpriteBatchGlobal.Draw(_overlayTexture, new Rectangle(0, 0, ScreenWidth, ScreenHeight), new Color(1, 1, 1, _alpha));
            }
        }
    }
}
