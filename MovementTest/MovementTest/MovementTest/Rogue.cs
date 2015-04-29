using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementTest
{
    class Rogue : CharacterSheet
    {
        public Rogue(string name)
        {
            Name = name;
            Strength = 5;
            Intelligence = 5;
            Dexterity = 10;
            Armor = 10;
            Evasion = 0.35f;
            Damage = 8;
            Fire_Resistance = 0;
            Cold_Resistance = 0;
            Storm_Resistance = 0;
            Arcane_Resistance = 0;
            Toxic_Resistance = 0;
        }
    }
}
