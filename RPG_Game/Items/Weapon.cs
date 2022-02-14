using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Weapon : Item
    {
        public double BaseDamage { get; set; }
        public double AttacksPerSecond { get; set; }
        public double DamagePerSecond { get; set; }
        public WeaponCat Category { get; set; }


        public Weapon(string name, int requiredLevel, WeaponCat category, double baseDmg, double attacksPSec)
             : base(name, requiredLevel)
        {
            Category = category;
            BaseDamage = baseDmg;
            AttacksPerSecond = attacksPSec;
            DamagePerSecond = BaseDamage * AttacksPerSecond;
            Slot = Slot.Weapon;
        }

        public override Weapon Duplicate()
        {
            return new Weapon(Name, RequiredLevel, Category, BaseDamage, AttacksPerSecond);
        }
    }

}
