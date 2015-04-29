using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{
    class Mage : CharacterSheet
    {
        public Mage(string name)
        {
            Name = name;
            Strength = 5;
            Intelligence = 10;
            Dexterity = 5;
            Health = 30;
            Armor = 10;
            Evasion = 0.10f;
            Damage = 4;
            Fire_Resistance = 0;
            Cold_Resistance = 0;
            Storm_Resistance = 0;
            Arcane_Resistance = 0;
            Toxic_Resistance = 0;
        }
    }
}
