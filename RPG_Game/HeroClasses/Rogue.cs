using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game.HeroClasses
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {

            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(2, 6, 1);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Dexterity / 100.0));
        }

        /// <summary>
        /// The method responsible for upping the specific stats of this hero type
        /// some nice null checks there too.
        /// </summary>
        public void LevelUp()
        {
            if (PrimaryAttribute != null)
            {
                PrimaryAttribute.Strength += 1;
                PrimaryAttribute.Dexterity += 4;
                PrimaryAttribute.Intelligence += 1;
            }

            if (TotalAttribute != null)
            {
                TotalAttribute.Strength += 1;
                TotalAttribute.Dexterity += 4;
                TotalAttribute.Intelligence += 1;

                if (EquippedItems != null && !EquippedItems.ContainsKey(Slot.Weapon))
                {
                    Damage = 1.0 * (1.0 + ((TotalAttribute.Dexterity / 100.0)));
                }
            }

            Level++;
        }




    }
}
