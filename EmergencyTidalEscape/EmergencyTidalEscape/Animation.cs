using Microsoft.Xna.Framework.Graphics;

namespace EmergencyTidalEscape
{
    public class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }

        public float FrameSpeed { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get{ return Texture.Height; } }
        public bool IsLooping { get; set; }

        public Texture2D Texture { get; set; }

        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;
            FrameSpeed = 0.2f;
        }

    }
}
