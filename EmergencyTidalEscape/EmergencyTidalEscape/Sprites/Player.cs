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


        public Player(Game1 root, Vector2 position) : base(position)
        {
            this._root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;
            gravity = 3f;

            velocity = GetVelocity();

            LoadContent();
        }



        public void LoadContent()
        {

            this.SpriteImage = _root.Content.Load<Texture2D>("duncan_morter");
        }

        private void HandleInput(KeyboardState currentKeyboardState)
        {
            bool wKeyPressed = currentKeyboardState.IsKeyDown(Keys.W);
            bool sKeyPressed = currentKeyboardState.IsKeyDown(Keys.S);
            bool aKeyPressed = currentKeyboardState.IsKeyDown(Keys.A);
            bool dKeyPressed = currentKeyboardState.IsKeyDown(Keys.D);
            if (wKeyPressed)
            {
                position.Y -= movementSpeed;
            }
            if (sKeyPressed)
            {
                position.Y += movementSpeed;
            }
            if (aKeyPressed)
            {
                position.X -= movementSpeed;
            }
            if (dKeyPressed)
            {
                position.X += movementSpeed;
            }
            
        }


        public void Update(GameTime gameTime, List<Sprite> sprites)
        {

            position.Y += gravity;
            KeyboardState currentKeyboardState = Keyboard.GetState();
            HandleInput(currentKeyboardState);

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                {
                    continue;
                }

                if (this.velocity.X > 0 && this.IsTouchingLeft(sprite)
                    || this.velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.velocity.X = 0;
                }
                if (this.velocity.Y > 0 && this.IsTouchingTop(sprite)
                    || this.velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.velocity.Y = 0;
                }
            }

            Position += velocity;
            velocity = Vector2.Zero;

        }

    }
}

