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

        //public Vector2 position;
        //public Rectangle avatarBounds;

        //sprite
        public SpriteAnimator animatedSprite;

        //tilemapping
        TileMap myMap = new TileMap();
        int squaresAcross=50;
        int squaresDown=50;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {  
            cam = new Camera(GraphicsDevice.Viewport); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //avatarBounds = new Rectangle((int)(position.X - avatar.Width / 2),
           // (int)(position.Y - avatar.Height / 2), avatar.Width, avatar.Height);

            //sprite animation
            animatedSprite = new SpriteAnimator(Content.Load<Texture2D>("scarybaldman"), 0, 64, 64);
            animatedSprite.Position = new Vector2(400, 300);

            //tilemapping
            Tile.TileSetTexture = Content.Load<Texture2D>("terrain");
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
            animatedSprite.HandleSpriteMovement(gameTime);
            cam.update(gameTime,this);
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,cam.transform);

           //tilemapping
            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                   foreach (int tileID in myMap.Rows[y].Columns[x].BaseTiles)
                  {
                    spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle((x * Tile.TileWidth) , (y * Tile.TileHeight) , Tile.TileWidth, Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White);
                  }
                }
            }
            //
            //animated sprite
            spriteBatch.Draw(animatedSprite.Texture, animatedSprite.Position, animatedSprite.SourceRect, Color.White, 0f, animatedSprite.Origin, 1.0f, SpriteEffects.None, 0);
            //
            spriteBatch.End();
            base.Draw(gameTime);
        }
  
    }
}
