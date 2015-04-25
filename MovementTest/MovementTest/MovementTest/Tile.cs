using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MovementTest
{//returns the rectangle associated with the tile to be drawn based on the tile index
    static class Tile
    {
        static public Texture2D TileSetTexture;
        static public int TileWidth = 32;
        static public int TileHeight = 32;
       
        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TileSetTexture.Height / TileHeight);
            int tileX = tileIndex % (TileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
   
}
