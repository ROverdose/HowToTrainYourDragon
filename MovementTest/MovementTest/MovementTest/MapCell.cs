using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{//Holds the ID's for all textures to be drawn in each space of the grid
   public class MapCell
    { 
       public List<int> BaseTiles = new List<int>();
        public MapCell(int tileID)
        {
            TileID = tileID;
        }
       public int TileID
       {
           get { return BaseTiles.Count > 0 ? BaseTiles[0] : 0; }
           set
           {
               if (BaseTiles.Count > 0)
                   BaseTiles[0] = value;
               else
                   AddBaseTile(value);
           }
       }
       //use AddBaseTile whenever you want to add anything to be drawn ontop of a basetile
       public void AddBaseTile(int tileID)
       {
           BaseTiles.Add(tileID);
       }
       
    }
}
