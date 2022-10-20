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
        public float rotation;

        public Animation(Texture2D texture, int width, int height, int Xpos, int Ypos, int frames, float timer, Vector2 pos, bool isLooped, bool isFliped)
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
        /// <summary>
        /// Plays the animtaion from Left to Right.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="newPos"></param>
        public void ForwardPlay(GameTime gameTime, Vector2 newPos)
        {
            position = newPos;
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
        /// <summary>
        /// Plays the animation from Right to Left.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="newPos"></param>
        public void BackwardPlay(GameTime gameTime, Vector2 newPos)
        {
            position = newPos;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle(Xpos + (width * currentFrame), Ypos, width, height);
            if (timer > frameTime)
            {
                if (currentFrame == 0)
                {
                    currentFrame = frames;
                    timer = 0;
                }
                else if (frames >= currentFrame && isLooped)
                {
                    currentFrame--;
                    timer = 0;
                }
            }
        }
        /// <summary>
        /// Plays the animation from top to the bottom.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="newPos"></param>
        public void TopPlay(GameTime gameTime, Vector2 newPos)
        {
            position = newPos;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle(Xpos, Ypos + (height * currentFrame), width, height);
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
        /// <summary>
        /// Plays the Animation from the Bottom to the Top.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="newPos"></param>
        public void BottomPlay(GameTime gameTime, Vector2 newPos)
        {
            position = newPos;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle(Xpos, Ypos + (height * currentFrame), width, height);
            if (timer > frameTime)
            {
                if (currentFrame == 0)
                {
                    currentFrame = frames;
                    timer = 0;
                }
                else if (frames >= currentFrame && isLooped)
                {
                    currentFrame--;
                    timer = 0;
                }
            }
        }
        /// <summary>
        /// Loops throw the animation for a specified time.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="newPos"></param>
        /// <param name="LoopTimer"></param>
        public void TimedLoop(GameTime gameTime, Vector2 newPos, float LoopTimer)
        {
            position = newPos;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            LoopTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle(Xpos + (width * currentFrame), Ypos, width, height);
            if (timer > frameTime)
            {
                if (currentFrame < frames)
                {
                    currentFrame++;
                    timer = 0;
                }
                else if (currentFrame >= frames && isLooped && LoopTimer > 0)
                {
                    currentFrame = 0;
                    timer = 0;
                }
            }
        }
        /// <summary>
        /// Resets a non looped animation
        /// </summary>
        public void Reset()
        {
            currentFrame = 0;
        }
        /// <summary>
        /// Draws the animation on screen
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="rotation"></param>
        public void Draw(SpriteBatch sp, float rotation)
        {
            this.rotation = rotation;
            if (!isFliped)
                sp.Draw(texture, position, rectangle, Color.White, this.rotation, origin, 1, SpriteEffects.None, 0);
            else if (isFliped)
                sp.Draw(texture, position, rectangle, Color.White, this.rotation, origin, 1, SpriteEffects.FlipHorizontally, 0);
        }
    }
}


