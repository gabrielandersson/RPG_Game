using System.Collections.Generic;
using System.IO;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game.HeroClasses
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(1, 7, 1);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Dexterity / 100.0));
        }
        #region ConstructorForFun
        public Ranger(string name, IReadHeroState log) : base(name, log)
        {
            EquippedItems = new Dictionary<Slot, Item>();
            ReadHeroState = log;
            PrimaryAttribute = new PrimaryAttribute(1, 7, 1);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Dexterity / 100.0));
        }
        #endregion

        /// <summary>
        /// The method responsible for upping the specific stats of this hero type
        /// some nice null checks there too.
        /// </summary>
        public virtual void LevelUp()
        {
            if (PrimaryAttribute != null)
            {
                PrimaryAttribute.Strength += 1;
                PrimaryAttribute.Dexterity += 5;
                PrimaryAttribute.Intelligence += 1;
            }

            if (TotalAttribute != null)
            {
                TotalAttribute.Strength += 1;
                TotalAttribute.Dexterity += 5;
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
