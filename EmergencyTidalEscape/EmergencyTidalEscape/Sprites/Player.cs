using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyTidalEscape.Sprites;
using EmergencyTidalEscape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;
using System.Diagnostics;

namespace EmergencyTidalEscape.Sprites
{
    internal class Player : Sprite
    {
        private Game1 _root;

        float gravity;

        private float movementSpeed = 10.0f;

        private Vector2 velocity;
        private Wave _wave;
        public int _dangerLevel; //0 = not near wave, 1 = near wave (siren active), 2 = in wave (die)


        private enum playerState
        {
            JUMPING,
            STANDING,
            FALLING
        }
        private playerState _state;


        public Player(Game1 root, Vector2 position, Wave wave) : base(position)
        {
            this._root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;
            gravity = 4f;

            velocity = GetVelocity();
            _state = playerState.STANDING;

            LoadContent();
            _wave = wave;
            _dangerLevel = 0;
        }



        public void LoadContent()
        {

            this.SpriteImage = _root.Content.Load<Texture2D>("duck");
        }

        private void HandleInput(KeyboardState currentKeyboardState)
        {
            bool wKeyPressed = currentKeyboardState.IsKeyDown(Keys.W);
            bool sKeyPressed = currentKeyboardState.IsKeyDown(Keys.S);
            bool aKeyPressed = currentKeyboardState.IsKeyDown(Keys.A);
            bool dKeyPressed = currentKeyboardState.IsKeyDown(Keys.D);
            if (wKeyPressed && _state == playerState.STANDING)
            {
                StartJump();
            }
            if (aKeyPressed)
            {
                position.X -= movementSpeed;
                SpriteImage = _root.Content.Load<Texture2D>("duck-left");
            }
            if (dKeyPressed)
            {
                position.X += movementSpeed;
                SpriteImage = _root.Content.Load<Texture2D>("duck");
            }
            
        }
        private void StartJump()
        {
            velocity.Y -= 20;
            _state = playerState.JUMPING;
        }
        private bool OnGround(List<Sprite> sprites)
        {
            foreach(Sprite sprite in sprites)
            {
                if(sprite != this)
                {
                    if (this.position.X > sprite.PositionRectangle.Left - (this.SpriteWidth / 2) && this.position.X < sprite.PositionRectangle.Right - (this.SpriteWidth / 2))
                    {
                        //sprite is lined up with player, now check if player is on top
                        if (this.position.Y < sprite.PositionRectangle.Bottom - 100 && this.position.Y > sprite.PositionRectangle.Top - 80)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private Powerup FindPowerups(List<Powerup> pPowerups)
        {
            foreach(Powerup powerup in pPowerups)
            {
                Point pos = new Point((int)this.position.X, (int)this.position.Y);
                if (powerup._bounds.Contains(pos))
                {
                    return powerup;
                }
            }
            return null;
        }
        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            bool Grounded = OnGround(sprites);
            if(Grounded && !(_state == playerState.JUMPING))
            {
                _state = playerState.STANDING;
            }
            else if(!Grounded && _state == playerState.STANDING)
            {
                _state = playerState.FALLING;
            }
            else
            {
                if(_state == playerState.JUMPING)
                {
                    velocity += new Vector2(0, 0.5f);
                }
                if(velocity.Y > 0)
                {
                    _state = playerState.FALLING;
                }
            }
            if(_state == playerState.FALLING)
            {
                velocity = new Vector2(0, 0);
                position.Y += gravity;
            }
            position += velocity;
            KeyboardState currentKeyboardState = Keyboard.GetState();
            HandleInput(currentKeyboardState);
            if(this.position.Y > _wave.GetWaveKillZone() - 300)
            {
                _dangerLevel = 1;
                if(this.position.Y > _wave.GetWaveKillZone())
                {
                    _dangerLevel = 2;
                }
            }
            else
            {
                _dangerLevel = 0;
            }
            Powerup getPowerup = FindPowerups(_root._powerups);
            if (getPowerup != null)
            {
                getPowerup.OnPickup();
            }
        }

    }
}

