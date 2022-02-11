using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute(2, 6, 1);
            TotalAttribute = PrimaryAttribute.Strength + PrimaryAttribute.Dexterity + PrimaryAttribute.Intelligence;
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
