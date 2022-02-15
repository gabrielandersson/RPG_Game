using RPG_Game.Enums;

namespace RPG_Game.Items
{
    public class Weapon : Item
    {
        public double BaseDamage { get; protected set; }
        public double AttacksPerSecond { get; protected set; }
        public double DamagePerSecond { get; protected set; }
        public WeaponCat Category { get; protected set; }

        /// <summary>
        /// Constructor method for Weapon
        /// </summary>
        public Weapon(string name, int requiredLevel, WeaponCat category, double baseDmg, double attacksPSec)
           : base(name, requiredLevel)
        {
            Category = category;
            BaseDamage = baseDmg;
            AttacksPerSecond = attacksPSec;
            DamagePerSecond = BaseDamage * AttacksPerSecond;
            Slot = Slot.Weapon;
        }

    }

}
