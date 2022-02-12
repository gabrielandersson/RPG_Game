using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Warrior : Hero
    {
        private Dictionary<Slot, Item> EquippedItems = new Dictionary<Slot, Item>();

        public Warrior(string name) : base(name)
        {

            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(5, 2, 1);
            TotalAttribute = PrimaryAttribute.Strength + PrimaryAttribute.Dexterity + PrimaryAttribute.Intelligence;
            HeroClass = HeroClass.Warrior;
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
