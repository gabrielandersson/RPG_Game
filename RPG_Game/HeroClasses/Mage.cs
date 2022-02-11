using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Mage : Hero
    {
        public Mage(string name)
        {
            Name = name;
            Level = 1;
            PrimaryAttribute = new PrimaryAttribute(1, 1, 8);
        }

        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 1;
            PrimaryAttribute.Dexterity += 1;
            PrimaryAttribute.Intelligence += 5;
            Level++;
        }
    }
}
