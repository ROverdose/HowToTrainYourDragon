using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MovementTest
{
    public class AnimatedSprite
    {
KeyboardState currentKBState;
KeyboardState previousKBState;
Texture2D spriteTexture;
float timer = 0f;
float interval = 200f;
int currentFrame = 0;
int spriteWidth = 32;
int spriteHeight = 48;
int spriteSpeed = 2;
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

public AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
{
    this.spriteTexture = texture;
    this.currentFrame = currentFrame;
    this.spriteWidth = spriteWidth;
    this.spriteHeight = spriteHeight;
}
public void HandleSpriteMovement(GameTime gameTime)
{
    previousKBState = currentKBState;
    currentKBState = Keyboard.GetState();

    int TheDumbAssVariable=0;
    if(currentFrame <= 9)
    {
        TheDumbAssVariable = 0;
    }
    else if (currentFrame > 9 && currentFrame <=18)
    {
        TheDumbAssVariable = 1*spriteHeight;
    }
    else if (currentFrame > 18 && currentFrame <= 27)
    {
        TheDumbAssVariable = 2 * spriteHeight;
    }
    else if (currentFrame > 27 && currentFrame <= 36)
    {
        TheDumbAssVariable = 3 * spriteHeight;
    }
    sourceRect = new Rectangle((currentFrame%9)*spriteHeight, TheDumbAssVariable, spriteWidth, spriteHeight);

    if (currentKBState.GetPressedKeys().Length == 0)
    {
        if (currentFrame > 0 && currentFrame < 9)
        {
            currentFrame = 0;
        }
        if (currentFrame > 9 && currentFrame < 18)
        {
            currentFrame = 9;
        }
        if (currentFrame > 18 && currentFrame < 27)
        {
            currentFrame = 18;
        }
        if (currentFrame > 27 && currentFrame < 36)
        {
            currentFrame = 27;
        }
    }

    if (currentKBState.IsKeyDown(Keys.D) == true)
    {
        AnimateRight(gameTime);
        if (position.X < 780)
        {
            position.X += spriteSpeed;
        }
    }

    if (currentKBState.IsKeyDown(Keys.A) == true)
    {
        AnimateLeft(gameTime);
        if (position.X > 20)
        {
            position.X -= spriteSpeed;
        }
    }

    if (currentKBState.IsKeyDown(Keys.S) == true)
    {
        AnimateDown(gameTime);
        if (position.Y < 575)
        {
            position.Y += spriteSpeed;
        }
    }

    if (currentKBState.IsKeyDown(Keys.W) == true)
    {
        AnimateUp(gameTime);
        if (position.Y > 25)
        {
            position.Y -= spriteSpeed;
        }
    }

    origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
}

public void AnimateRight(GameTime gameTime)
{
    if (currentKBState != previousKBState)
    {
        currentFrame = 29;
    }

    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

    if (timer > interval)
    {
        currentFrame++;
        if (currentFrame > 36)
        {
            currentFrame = 29;
        }
        timer = 0f;
    }
}

public void AnimateLeft(GameTime gameTime)
{
    if (currentKBState != previousKBState)
    {
        currentFrame = 10;
    }

    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

    if (timer > interval)
    {
        currentFrame++;

        if (currentFrame > 18)
        {
            currentFrame = 10;
        }
        timer = 0f;
    }
}

public void AnimateUp(GameTime gameTime)
{
    if (currentKBState != previousKBState)
    {
        currentFrame = 2;
    }

    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

    if (timer > interval)
    {
        currentFrame++;

        if (currentFrame > 9)
        {
            currentFrame = 2;
        }
        timer = 0f;
    }
}

public void AnimateDown(GameTime gameTime)
{
    if (currentKBState != previousKBState)
    {
        currentFrame = 20;
    }

    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

    if (timer > interval)
    {
        currentFrame++;

        if (currentFrame > 27)
        {
            currentFrame = 20;
        }
        timer = 0f;
    }
}

    }
}