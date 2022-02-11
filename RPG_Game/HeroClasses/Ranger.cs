using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Ranger : Hero
    {
        public Ranger(string name)
        {
            Name = name;
            Level = 1;
            PrimaryAttribute = new PrimaryAttribute(1, 7, 1);
        }

        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 1;
            PrimaryAttribute.Dexterity += 5;
            PrimaryAttribute.Intelligence += 1;
            Level++;
        }
    }
}
