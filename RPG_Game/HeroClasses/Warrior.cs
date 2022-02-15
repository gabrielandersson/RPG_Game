using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game.HeroClasses
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {

            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(5, 2, 1);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Strength / 100.0));
        }

     
        public virtual void LevelUp()
        {
            if (PrimaryAttribute != null)
            {
                PrimaryAttribute.Strength += 3;
                PrimaryAttribute.Dexterity += 2;
                PrimaryAttribute.Intelligence += 1;
            }

            if (TotalAttribute != null)
            {
                TotalAttribute.Strength += 3;
                TotalAttribute.Dexterity += 2;
                TotalAttribute.Intelligence += 1;

                if (EquippedItems != null && !EquippedItems.ContainsKey(Slot.Weapon))
                {
                    Damage = 1.0 * (1.0 + ((TotalAttribute.Strength / 100.0)));
                }
            }

            Level++;
        }

    }
}
