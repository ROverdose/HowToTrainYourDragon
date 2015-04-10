using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MovementTest
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera cam;
        Vector2 velocity, movementSpeed;
        public Vector2 position;
        public Rectangle avatarBounds;
        //sprite
        public AnimatedSprite animatedSprite;
        //Background
        Vector2 backgroundPosition;
        List<Texture2D> tiles = new List<Texture2D>();
        static int tileWidth = 32;
        static int tileHeight = 32;
        int tileMapWidth;
        int tileMapHeight;
        int[,] map = {
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
{3, 3, 3, 3, 3, 3, 3, 3, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, },
};
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {  
            position = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);
            velocity = Vector2.Zero;
            movementSpeed = new Vector2(5, 5);

            cam = new Camera(GraphicsDevice.Viewport); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //avatarBounds = new Rectangle((int)(position.X - avatar.Width / 2),
           // (int)(position.Y - avatar.Height / 2), avatar.Width, avatar.Height);

            //sprite animation
            animatedSprite = new AnimatedSprite(Content.Load<Texture2D>("scarybaldman"), 1, 64,64);
            animatedSprite.Position = new Vector2(400, 300);


            //background
            tiles.Add(Content.Load<Texture2D>("grass"));//0
            tiles.Add(Content.Load<Texture2D>("dirt"));//1
            tiles.Add(Content.Load<Texture2D>("flowers"));//2
            tiles.Add(Content.Load<Texture2D>("tree_single"));//3
            backgroundPosition = new Vector2(-400, 0);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

      
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            KeyboardState KS = Keyboard.GetState();



            if (KS.IsKeyDown(Keys.Escape))
                this.Exit();
            velocity = Vector2.Zero;
            //movement
            //if (KS.IsKeyDown(Keys.W)) { velocity.Y = -movementSpeed.Y; }
            //if (KS.IsKeyDown(Keys.S)) { velocity.Y = +movementSpeed.Y; }
            //if (KS.IsKeyDown(Keys.A)) { velocity.X = -movementSpeed.Y; }
            //if (KS.IsKeyDown(Keys.D)) { velocity.X = +movementSpeed.Y; }
        
            position += velocity;
            avatarBounds.X = (int)position.X;
            avatarBounds.Y = (int)position.Y;
            tiles.Add(Content.Load<Texture2D>("grass"));
            
            animatedSprite.HandleSpriteMovement(gameTime);
            cam.update(gameTime,this);
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,cam.transform);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    spriteBatch.Draw(tiles[map[y, x]],
                    new Rectangle(
                    x * tileWidth,
                    y * tileHeight,
                    tileWidth,
                    tileHeight),
                    Color.White);
                }
            } 
            spriteBatch.Draw(animatedSprite.Texture, animatedSprite.Position, animatedSprite.SourceRect, Color.White, 0f, animatedSprite.Origin, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();
           
            base.Draw(gameTime);
        }
  
    }
}
