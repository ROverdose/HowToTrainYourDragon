using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{
    class CharacterSheet
    {
        private int strength, 
            intelligence, 
            dexterity, 
            health, 
            armor, 
            damage, 
            fireResistance, 
            coldResistance,
            stormResistance,
            toxicResistance,
            arcaneResistance;
        private float evasion;
        private string characterName;

        public string Name
        {
            get { return characterName; }
            set { characterName = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public float Evasion
        {
            get { return evasion; }
            set { evasion = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Fire_Resistance
        {
            get { return fireResistance; }
            set { fireResistance = value; }
        }
        public int Cold_Resistance
        {
            get { return coldResistance; }
            set { coldResistance = value; }
        }
        public int Storm_Resistance
        {
            get { return stormResistance; }
            set { stormResistance = value; }
        }
        public int Toxic_Resistance
        {
            get { return toxicResistance; }
            set { toxicResistance = value; }
        }
        public int Arcane_Resistance
        {
            get { return arcaneResistance; }
            set { arcaneResistance = value; }
        }
        
    }
}
