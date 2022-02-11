using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute(1, 7, 1);
            TotalAttribute = PrimaryAttribute.Strength + PrimaryAttribute.Dexterity + PrimaryAttribute.Intelligence;
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
