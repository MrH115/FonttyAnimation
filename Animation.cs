using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FonttyAnimation
{
    public class Animation
    {
        public int width, height, Xpos, Ypos, frames, currentFrame;
        public Rectangle rectangle;
        public Texture2D texture;
        public Vector2 origin, position;
        public float frameTime, timer;
        public bool isLooped, isFliped;

        public Animation(Texture2D texture, int width, int height,int Xpos,int Ypos,int frames, float timer, Vector2 pos, bool isLooped, bool isFliped)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            frameTime = timer;
            position = pos;
            origin = new Vector2(width / 2, height / 2);
            rectangle = new Rectangle(Xpos, Ypos, width, height);
            this.frames = frames;
            this.timer = 0;
            currentFrame = 0;
            this.isLooped = isLooped;
            this.isFliped = isFliped;
        }
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle(Xpos + (width * currentFrame), Ypos, width, height);
            if (timer > frameTime)
            {
                if (currentFrame < frames)
                {
                    currentFrame++;
                    timer = 0;
                }
                else if (currentFrame >= frames && isLooped)
                {
                    currentFrame = 0;
                    timer = 0;
                }
            }
        }
        public void Draw(SpriteBatch sp)
        {
            if(!isFliped)
                sp.Draw(texture, position, rectangle, Color.White, 0, origin,1, SpriteEffects.None, 0);
            else if(isFliped)
                sp.Draw(texture, position, rectangle, Color.White, 0, origin, 1, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
