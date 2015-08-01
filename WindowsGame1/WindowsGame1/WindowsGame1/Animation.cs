using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class Animation
    {
        public Texture2D texture;

        public float frameTime;

        public bool islooping;

        public int FrameCount;
        //{
        //    get { return texture.Width / FrameWidth; }
        //}
        public int FrameWidth { get { return texture.Width / FrameCount;} }
        public int FrameHeight { get { return texture.Height; } }

        public Animation(Texture2D texture, float frameTime, bool islooping, int frameCount)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            this.islooping = islooping;
            this.FrameCount = frameCount;
        }
    }
}
