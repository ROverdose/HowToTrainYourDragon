using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//If you play around with tile mapping at all, making structures isnt that bad if you make a grid and fill in corresponding numbers

namespace MovementTest
{
    public class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }

   
    public class TileMap //Is responsible for filling a list of MapCell structures that hold data regarding what to draw
    {
        static public Texture2D TileSetTexture;
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;
        Random randy= new Random();

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {//prints two different base grasses to make it feel less tile-e
                    if (randy.Next(1, 5) == 4)
                        thisRow.Columns.Add(new MapCell(354));
                    else
                        thisRow.Columns.Add(new MapCell(353));
                }
                Rows.Add(thisRow);
            }



            addStaticGrass();
            generatepond5x5(8,10);

            

                       //
           // Rows[5].Columns[2].TileID = 3;
            //Rows[5].Columns[3].TileID = 1;
            //Rows[5].Columns[4].TileID = 1;
            //Rows[5].Columns[5].TileID = 2;
            //Rows[5].Columns[6].TileID = 2;
            //Rows[5].Columns[7].TileID = 2;
            //Rows[5].Columns[8].TileID = 3;
            //Rows[5].Columns[9].TileID = 1;
            //Rows[5].Columns[10].TileID = 1;
            //Rows[5].Columns[11].TileID = 2;
            //Rows[5].Columns[12].TileID = 2;
            //Rows[5].Columns[13].TileID = 2;

            //Rows[6].Columns[2].TileID = 3;
            //Rows[6].Columns[3].TileID = 1;
            //Rows[6].Columns[4].TileID = 1;
            //Rows[6].Columns[5].TileID = 2;
            //Rows[6].Columns[6].TileID = 2;
            //Rows[6].Columns[7].TileID = 2;

            //Rows[7].Columns[2].TileID = 3;
            //Rows[7].Columns[3].TileID = 1;
            //Rows[7].Columns[4].TileID = 1;
            //Rows[7].Columns[5].TileID = 2;
            //Rows[7].Columns[6].TileID = 2;
            //Rows[7].Columns[7].TileID = 2;

            //Rows[8].Columns[2].TileID = 3;
            //Rows[8].Columns[3].TileID = 1;
            //Rows[8].Columns[4].TileID = 1;
            //Rows[8].Columns[5].TileID = 2;
            //Rows[8].Columns[6].TileID = 2;
            //Rows[8].Columns[7].TileID = 2;

            //Rows[9].Columns[2].TileID = 3;
            //Rows[9].Columns[3].TileID = 1;
            //Rows[9].Columns[4].TileID = 1;
            //Rows[9].Columns[5].TileID = 2;
            //Rows[9].Columns[6].TileID = 2;
            //Rows[9].Columns[7].TileID = 2;

            //Rows[3].Columns[5].AddBaseTile(30);
            //Rows[4].Columns[5].AddBaseTile(27);
            //Rows[5].Columns[5].AddBaseTile(28);

            //Rows[3].Columns[6].AddBaseTile(25);
            //Rows[5].Columns[6].AddBaseTile(24);

            //Rows[3].Columns[7].AddBaseTile(31);
            //Rows[4].Columns[7].AddBaseTile(26);
            //Rows[5].Columns[7].AddBaseTile(29);

            //Rows[4].Columns[6].AddBaseTile(104);

        }
        //makes sporatic grass textures get drawn over the base grass
        private void addStaticGrass()
       { 
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (randy.Next(1, 4) == 3)
                        Rows[y].Columns[x].AddBaseTile(367);
                    
                }
            }
        }
        //makes a 5x5 generic pond at Rows[startY].Columns[startX]
        //the top left corner of the pond is drawn on the specified X&Y
        //ps i feel like there has to be an easier way
        private void generatepond5x5(int startX, int startY)
         {
             // Create pond
             Rows[0 + startY].Columns[0 + startX].AddBaseTile(91);//top left corner
             Rows[0 + startY].Columns[1 + startX].AddBaseTile(92);//top edge
             Rows[0 + startY].Columns[2 + startX].AddBaseTile(92);//top edge
             Rows[0 + startY].Columns[3 + startX].AddBaseTile(92);//top edge
             Rows[0 + startY].Columns[4 + startX].AddBaseTile(93);//top right corner

             Rows[1 + startY].Columns[0 + startX].AddBaseTile(123);//left edge
             Rows[1 + startY].Columns[1 + startX].AddBaseTile(124);//water
             Rows[1 + startY].Columns[2 + startX].AddBaseTile(124);//water
             Rows[1 + startY].Columns[3 + startX].AddBaseTile(124);//water
             Rows[1 + startY].Columns[4 + startX].AddBaseTile(125);//right edge

             Rows[2 + startY].Columns[0 + startX].AddBaseTile(123);//left edge
             Rows[2 + startY].Columns[1 + startX].AddBaseTile(124);//water
             Rows[2 + startY].Columns[2 + startX].AddBaseTile(124);//water
             Rows[2 + startY].Columns[3 + startX].AddBaseTile(124);//water
             Rows[2 + startY].Columns[4 + startX].AddBaseTile(125);//right edge

             Rows[3 + startY].Columns[0 + startX].AddBaseTile(123);//left edge
             Rows[3 + startY].Columns[1 + startX].AddBaseTile(124);//water
             Rows[3 + startY].Columns[2 + startX].AddBaseTile(124);//water
             Rows[3 + startY].Columns[3 + startX].AddBaseTile(124);//water
             Rows[3 + startY].Columns[4 + startX].AddBaseTile(125);//right edge
             //pond lillies
             Rows[1 + startY].Columns[1 + startX].AddBaseTile(551);
             Rows[1 + startY].Columns[2 + startX].AddBaseTile(550);
             Rows[2 + startY].Columns[1 + startX].AddBaseTile(554);
             Rows[2 + startY].Columns[2 + startX].AddBaseTile(553);
             Rows[2 + startY].Columns[3 + startX].AddBaseTile(550);
             Rows[3 + startY].Columns[1 + startX].AddBaseTile(552);
             Rows[3 + startY].Columns[3 + startX].AddBaseTile(553);
             // end pond lillies
             Rows[4 + startY].Columns[0 + startX].AddBaseTile(155);//bottom left corner
             Rows[4 + startY].Columns[1 + startX].AddBaseTile(156);//bottom edge
             Rows[4 + startY].Columns[2 + startX].AddBaseTile(156);//bottom edge
             Rows[4 + startY].Columns[3 + startX].AddBaseTile(156);//bottom edge
             Rows[4 + startY].Columns[4 + startX].AddBaseTile(157);//bottom right corner
         }
    } 
}
