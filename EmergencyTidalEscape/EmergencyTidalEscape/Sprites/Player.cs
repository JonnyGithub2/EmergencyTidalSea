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
            velocity.X += 10;
            _state = playerState.JUMPING;
        }
        private bool OnGround(List<Sprite> sprites)
        {
            foreach(Sprite sprite in sprites)
            {
                Console.WriteLine("checking x pos");
                if(this.position.X > sprite.PositionRectangle.Right && this.position.X < sprite.PositionRectangle.Left)
                {
                    Console.WriteLine("checking y pos");
                    //sprite is lined up with player, now check if player is on top
                    if (this.position.Y < sprite.PositionRectangle.Top + 50 && this.position.Y > PositionRectangle.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if(OnGround(sprites) && !(_state == playerState.JUMPING))
            {
                _state = playerState.STANDING;
            }
            else
            {
                _state = playerState.FALLING;
            }
            if(_state == playerState.FALLING)
            {
                position.Y += gravity;
            }
            
            KeyboardState currentKeyboardState = Keyboard.GetState();
            HandleInput(currentKeyboardState);

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                {
                    continue;
                }

                

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                    || (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                {
                    position.X = 0;
                    HandleInput(currentKeyboardState);
                }
                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                    || (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite)))
                {
                    position.Y = 0;
                    HandleInput(currentKeyboardState);
                }
            }



        }

    }
}

