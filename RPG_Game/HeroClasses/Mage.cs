using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;
using RPG_Game.IReadHero;

namespace RPG_Game.HeroClasses
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(1, 1, 8);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Intelligence / 100.0));
        }
        #region ConstructorForFun
        public Mage(string name, IReadHeroState log) : base(name, log)
        {
            EquippedItems = new Dictionary<Slot, Item>();
            ReadHeroState = log;
            PrimaryAttribute = new PrimaryAttribute(1, 1, 8);
            TotalAttribute = new TotalAttribute
            {
                Strength = PrimaryAttribute.Strength,
                Dexterity = PrimaryAttribute.Dexterity,
                Intelligence = PrimaryAttribute.Intelligence
            };
            Damage = 1.0 * (1.0 + (TotalAttribute.Intelligence / 100.0));
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
                PrimaryAttribute.Dexterity += 1;
                PrimaryAttribute.Intelligence += 5;
            }

            if (TotalAttribute != null)
            {
                TotalAttribute.Strength += 1;
                TotalAttribute.Dexterity += 1;
                TotalAttribute.Intelligence += 5;
                if (EquippedItems != null && !EquippedItems.ContainsKey(Slot.Weapon))
                {
                    Damage = 1.0 * (1.0 + ((TotalAttribute.Dexterity / 100.0)));
                }
            }

            Level++;
        }
    }
}
