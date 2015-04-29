using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{
    class ItemSheet
    {
        private int buyCost,
            sellCost;
        private string itemName;
        private bool equippable;

        public int Buy_Cost
        {
            get { return buyCost; }
            set { buyCost = value; }
        }
        public int Sell_Cost
        {
            get { return sellCost; }
            set { sellCost = value; }
        }
        public string Item_Name
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public bool Can_Equip
        {
            get { return equippable; }
            set { equippable = value; }
        }
        

    }
    public class AffixGenerator
    {
        //Refer to Weapon stuff reference for the effects of these prefixes
        public enum Prefix
        {
            Angelic,
            Arcane,
            Bloodthirsty,
            Broken,
            Brutal,
            Cosmic,
            Creeping,
            Demonic,
            Dwarven,
            Empowered,
            Enchanted,
            Enfeebling,
            Eternal,
            Fine,
            Flaming,
            Freezing,
            Gem_Encrusted,
            Gleaming,
            Golden,
            Guardsman,
            Heavy,
            Holy,
            Lethal,
            Light,
            Macabre,
            Charging,
            Perfect,
            Pestiliential,
            Rogue,
            Runic,
            Serrated,
            Sharp,
            Unholy,
            Vorpal,
            Wooden,
            Worn
        }
    }
}
