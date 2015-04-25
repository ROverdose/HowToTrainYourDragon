using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MovementTest
{
    public class SpriteAnimator
    {
        KeyboardState currentKBState;
        KeyboardState previousKBState;
        Texture2D spriteTexture;
        float timer = 0f;
        float interval = 200f;
        int currentFrame = 0;
        int frameHeight;
        int frameWidth;
        int spriteWidth;
        int spriteHeight;
        int spriteSpeed = 8;//2
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public SpriteAnimator(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight; 
            frameHeight = spriteTexture.Height/spriteHeight;
            frameWidth = spriteTexture.Width/spriteWidth;
        }
        public void HandleSpriteMovement(GameTime gameTime)
        {
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();
         
            //(x,y,width, height)
            sourceRect = new Rectangle((currentFrame % frameWidth) * spriteWidth, (currentFrame / frameWidth)*spriteHeight, spriteWidth, spriteHeight);
            if (currentKBState.GetPressedKeys().Length == 0)
            {
                int row = currentFrame/frameWidth;
                currentFrame = row * frameWidth;
            }

            if (currentKBState.IsKeyDown(Keys.D) == true)
            {
                AnimateRight(gameTime);
                    position.X += spriteSpeed;
            }

            if (currentKBState.IsKeyDown(Keys.A) == true)
            {
                AnimateLeft(gameTime);
                    position.X -= spriteSpeed;
            }

            if (currentKBState.IsKeyDown(Keys.S) == true)
            {
                AnimateDown(gameTime);
                    position.Y += spriteSpeed;
            }

            if (currentKBState.IsKeyDown(Keys.W) == true)
            {
                AnimateUp(gameTime);
                    position.Y -= spriteSpeed;
            }

            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        public void AnimateRight(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = (frameWidth*3);
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame > (frameWidth * 4)-1)
                {
                    currentFrame = (frameWidth * 3)+1;
                }
                timer = 0f;
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = (frameWidth);
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > (frameWidth * 2) - 1)
                {
                    currentFrame = (frameWidth * 1) + 1;
                }
                timer = 0f;
            }
        }

        public void AnimateUp(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 1;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > frameWidth  - 1)
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }
        }

        public void AnimateDown(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = (frameWidth * 2) + 1;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > (frameWidth * 3) - 1)
                {
                    currentFrame = (frameWidth * 2) + 1;
                }
                timer = 0f;
            }
        }

    }
}