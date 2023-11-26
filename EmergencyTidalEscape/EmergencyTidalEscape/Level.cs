using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyTidalEscape.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace EmergencyTidalEscape
{
    public class Level
    {
        private int levelID {  get; set; }

        Platform _platform;
        Powerup _powerup;
        Player _player;
        enum GameState
        {
            Start,
            Playing,
            GameOver
        }
        public Level()
        {
           
        }

        public void LoadLevel(int levelID)
        {

        }

        public Vector2 GetPlatformLocations()
        {
            return _platform.GetTargetPosition();
        }

        public Vector2 GetPlayerLocation()
        {
            return _player.GetTargetPosition();
        }

        public Vector2 GetPowerups()
        {
            return _powerup.PowerupPosition();
        }

    }
}
