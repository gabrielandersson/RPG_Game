using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Rogue : Hero
    {
        public Rogue(string name)
        {
            Name = name;
            Level = 1;
            PrimaryAttribute = new PrimaryAttribute(2, 6, 1);
        }

        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 1;
            PrimaryAttribute.Dexterity += 4;
            PrimaryAttribute.Intelligence += 1;
            Level++;
        }
    }
}
