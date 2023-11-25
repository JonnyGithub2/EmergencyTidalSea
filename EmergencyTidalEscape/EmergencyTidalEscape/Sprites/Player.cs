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
        private enum playerState
        {
            JUMPING,
            STANDING,
            FALLING
        }
        private playerState _state;


        public Player(Game1 root, Vector2 position) : base(position)
        {
            this._root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;
            gravity = 5f;

            velocity = GetVelocity();
            _state = playerState.STANDING;

            LoadContent();
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
            velocity.Y -= 10;
            _state = playerState.JUMPING;
        }
        private bool OnGround(List<Sprite> sprites)
        {
            foreach(Sprite sprite in sprites)
            {
                if(sprite != this)
                {
                    if (this.position.X > sprite.PositionRectangle.Left - 20 && this.position.X < sprite.PositionRectangle.Right + 20)
                    {
                        //sprite is lined up with player, now check if player is on top
                        if (this.position.Y < sprite.PositionRectangle.Bottom && this.position.Y > sprite.PositionRectangle.Top - 50)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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
        }

    }
}

