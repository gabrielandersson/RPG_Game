using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Warrior : Hero
    {
        public Warrior(string name)
        {
            Name = name;
            Level = 1;
            PrimaryAttribute = new PrimaryAttribute(5, 2, 1);
            TotalAttribute = PrimaryAttribute.Strength + PrimaryAttribute.Dexterity + PrimaryAttribute.Intelligence;
            Damage = 1;
        }

        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 3;
            PrimaryAttribute.Dexterity += 2;
            PrimaryAttribute.Intelligence += 1;
            Level++;
        }
    }
}
