using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{
    class Warrior : CharacterSheet 
    {
        public Warrior(string name)
        {
            Name = name;
            Strength = 10;
            Intelligence = 5;
            Dexterity = 5;
            Health = 50;
            Armor = 20;
            Evasion = 0.10f;
            Damage = 8;
            Fire_Resistance = 0;
            Cold_Resistance = 0;
            Storm_Resistance = 0;
            Arcane_Resistance = 0;
            Toxic_Resistance = 0;
        }
    }
}
