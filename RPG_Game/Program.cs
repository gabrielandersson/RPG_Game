
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 1, 2);
            var newArmor = new Armor("Sweaty Chainmail Pants", 1, Slot.Legs, ArmorCat.Mail,
                new PrimaryAttribute(4, 3, 3));

            newWarrior.Inventory.AddItemToInventory(newWeapon);
            newWarrior.Inventory.AddItemToInventory(newArmor);
            newWarrior.EquipItem(newWeapon.Name);
            newWarrior.EquipItem(newArmor.Name);
            double expected = 2.0 * (1 + (9 / 100)); // Strength Should be 9. Weapon Dps = 2. Calc= 2*(1+(9/100)) = 2.18 
            // Act
            double actual = newWarrior.Damage;
            // Assert
                      // Assert
            Console.WriteLine($"Expected: {expected}");

            Console.WriteLine($"Actual: {actual}");
        }
    }
}



