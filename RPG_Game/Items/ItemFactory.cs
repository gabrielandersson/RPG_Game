using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class ItemFactory
    {
        public ItemFactory(){}
        internal static List<Item> StandardItems { get; } = new List<Item>
        {
              new Weapon("Sword of UwU", 3, WeaponCat.Swords, 4, 10),
              new Weapon("Axe of Gimli", 5, WeaponCat.Swords, 6, 3),
              new Weapon("Gandalfs Staff", 3, WeaponCat.Staffs, 2, 4),
              new Weapon("Legolas Bow", 3, WeaponCat.Bows, 2, 6),
              new Weapon("Wand Of Voldemort", 4, WeaponCat.Wands, 4, 5),
              new Weapon("DwarfHammer of Titanium", 7, WeaponCat.Hammers, 8, 2),
              new Weapon("CryptoDagger", 2, WeaponCat.Daggers, 2, 7),
              new Weapon("NerfSword", 1, WeaponCat.Swords, 0, 0),

              new Armor("Chestplate of UwU", 4, Slot.Body, ArmorCat.Plate,
                                               new PrimaryAttribute(5, 2, 2)),
              new Armor("Plate Leg Armor of UwU", 4, Slot.Legs, ArmorCat.Plate,
                                               new PrimaryAttribute(4, 1, 1)),
              new Armor("Cool Helmet Of UwU", 4, Slot.Head, ArmorCat.Plate,
                                               new PrimaryAttribute(2, 1, 5)),
              new Armor("Potato Sack", 1, Slot.Body, 0,
                                               new PrimaryAttribute(1, 1, 1)),
              new Armor("Chainmail Of Gimli", 5, Slot.Body, ArmorCat.Mail,
                                               new PrimaryAttribute(7, 1, 5)),

              new Armor("Captain Jack's Old Leather Hat", 2, Slot.Head, ArmorCat.Leather,
                                               new PrimaryAttribute(2, 5, 5)),
              new Armor("DragonLeather Pants", 7, Slot.Legs, ArmorCat.Leather,
                                               new PrimaryAttribute(7, 5, 7)),
              new Armor("Beggar's Pants", 1, Slot.Legs, ArmorCat.Cloth,
                                               new PrimaryAttribute(1, 1, 2)),
              new Armor("Sweaty Chainmail Pants", 3, Slot.Legs, ArmorCat.Mail,
                                               new PrimaryAttribute(4, 3, 3)),
              new Armor("Chainmail Helmet", 3, Slot.Head, ArmorCat.Mail,
                                               new PrimaryAttribute(2, 2, 4)),
              new Armor("Pristine Priest Hood Of Chastity", 1, Slot.Head, ArmorCat.Cloth,
                                               new PrimaryAttribute(1, 2, 3))
        };

        public Armor CreateArmor(string itemName)
        {
            Armor armor = (Armor)StandardItems.FirstOrDefault(weapon => string.Equals(weapon.Name, itemName, StringComparison.OrdinalIgnoreCase));

            if (armor != null) return armor.Duplicate();

            return null;
        }

        public Weapon CreateWeapon(string itemName)
        {
            Weapon weapon = (Weapon)StandardItems.FirstOrDefault(weapon => string.Equals(weapon.Name, itemName, StringComparison.OrdinalIgnoreCase));

            if (weapon != null) return weapon.Duplicate();

            return null;
        }
    }
}
