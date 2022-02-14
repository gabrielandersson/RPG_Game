
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
            var armorOne = new Armor("Chestplate of UwU", 1, Slot.Body, ArmorCat.Plate,
                new PrimaryAttribute(5, 2, 2));
            var armorTwo = new Armor("Sweaty Chainmail Pants", 1, Slot.Legs, ArmorCat.Mail,
                new PrimaryAttribute(4, 3, 3));

            newWarrior.Inventory.AddItemToInventory(armorOne);
            newWarrior.Inventory.AddItemToInventory(armorTwo);

            newWarrior.EquipItem(armorOne.Name);
            TotalAttribute expected = new TotalAttribute();
            expected.Strength = 9.0;
            expected.Dexterity = 5.0;
            expected.Intelligence = 4.0;          // base: str:5, dex:2 , int: 1  //after: 9, 5, 4

            newWarrior.EquipItem(armorTwo.Name);
            TotalAttribute actual = newWarrior.TotalAttribute;
            Console.WriteLine($"Expected: {expected.Strength} {expected.Dexterity} {expected.Intelligence}");

            Console.WriteLine($"Actual: {actual.Strength} {actual.Dexterity} {actual.Intelligence}");
        }
    }
}



