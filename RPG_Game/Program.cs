using System;
using RPG_Game.Enums;
using RPG_Game.HeroClasses;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game
{
    internal class Program
    {
        //just some test data for another class, main() looked lonely..
        static void Main(string[] args)
        {
          
            var rogue = new Rogue("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 1, 2);
            var newArmor = new Armor("Sweaty Chainmail Pants", 1, Slot.Legs, ArmorCat.Mail,
                new PrimaryAttribute(4, 3, 3));

            rogue.Inventory.AddItemToInventory(newWeapon);
            rogue.Inventory.AddItemToInventory(newArmor);
            rogue.EquipHandler.EquipItem(newWeapon.Name, rogue);
            rogue.EquipHandler.EquipItem(newArmor.Name, rogue);
            double expected = 2.18;

            double actual = rogue.Damage;

            Console.WriteLine($"exp: {expected}");
            Console.WriteLine($"act: {actual}");
            rogue.Inventory.DisplayInventory();
            foreach (var item in rogue.EquippedItems)
            {
                Console.WriteLine(item.Value.Name);
            }
            Console.WriteLine($"str:{rogue.TotalAttribute.Strength} dex: {rogue.TotalAttribute.Dexterity} int:{rogue.TotalAttribute.Intelligence}");
        }
    }
}



