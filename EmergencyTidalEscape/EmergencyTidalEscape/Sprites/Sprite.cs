using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyTidalEscape;
using EmergencyTidalEscape.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmergencyTidalEscape.Sprites
{
    public class Sprite : ITargetable
    {
        public Behaviour m_Behaviour { get; private set; } = null;

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;


        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set 
            { 
                position = value;


                //if (_animationManager != null)
                //    _animationManager.Position = position;
            }
        }


        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private Texture2D spriteImage;
        public Texture2D SpriteImage
        {
            get { return spriteImage; }
            set { spriteImage = value; }
        }

        private float spriteWidth;
        public float SpriteWidth
        {
            get { return spriteWidth; }
            set { spriteWidth = value; }
        }

        public float SpriteHeight
        {
            get
            {
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }



        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
            }
        }



        public Sprite(Vector2 position)
        {
            this.position = position;

        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (spriteImage != null)
            {
                spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
            }
        }
        //    else if (_animationManager != null)
        //        _animationManager.Draw(spriteBatch);
        //}

        //protected virtual void SetAnimations()
        //{
        //    _animationManager.Play(_animations["wave-gif"]);
        //}

        //public Sprite(Dictionary<string, Animation> animations)
        //{
        //    _animations = animations;
        //    _animationManager = new AnimationManager(_animations.First().Value);
        //}

        //public virtual void Update(GameTime gameTime, List<Sprite> sprites) 
        //{
        //    SetAnimations();
        //    _animationManager.Update(gameTime);
        //}

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.PositionRectangle.Right + this.Velocity.X > sprite.PositionRectangle.Left &&
                this.PositionRectangle.Left < sprite.PositionRectangle.Left &&
                this.PositionRectangle.Bottom > sprite.PositionRectangle.Top &&
                this.PositionRectangle.Top < sprite.PositionRectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.PositionRectangle.Left + this.Velocity.X < sprite.PositionRectangle.Right &&
                this.PositionRectangle.Right > sprite.PositionRectangle.Right &&
                this.PositionRectangle.Bottom > sprite.PositionRectangle.Top &&
                this.PositionRectangle.Top < sprite.PositionRectangle.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.PositionRectangle.Bottom + this.Velocity.Y < sprite.PositionRectangle.Top &&
                this.PositionRectangle.Top < sprite.PositionRectangle.Top &&
                this.PositionRectangle.Right > sprite.PositionRectangle.Left &&
                this.PositionRectangle.Left < sprite.PositionRectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.PositionRectangle.Top + this.Velocity.Y < sprite.PositionRectangle.Bottom &&
                this.PositionRectangle.Bottom < sprite.PositionRectangle.Top &&
                this.PositionRectangle.Right > sprite.PositionRectangle.Left &&
                this.PositionRectangle.Left < sprite.PositionRectangle.Right;
        }

        public void SetBehaviour(Behaviour pBehaviour)
        {
            m_Behaviour = pBehaviour;
        }

        public Vector2 GetTargetPosition()
        {
            return position;
        }
        public Vector2 GetVelocity()
        {
            return velocity;
        }
    }
}



