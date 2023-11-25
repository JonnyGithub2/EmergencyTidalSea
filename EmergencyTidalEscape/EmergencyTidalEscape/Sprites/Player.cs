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

namespace EmergencyTidalEscape.Sprites
{
    internal class Player : Sprite
    {
        private Game1 _root;


        private float movementSpeed = 10.0f;




        public Player(Game1 root, Vector2 position) : base(position)
        {
            this._root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;

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
            if(position.Y = )
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            HandleInput(currentKeyboardState);
        }

    }
}

