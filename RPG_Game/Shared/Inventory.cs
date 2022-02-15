using System;
using System.Collections.Generic;
using System.Linq;
using RPG_Game.Items;

namespace RPG_Game.Shared
{
    public class Inventory
    {
        private readonly List<Item> _inventoryList = new();
        /// <summary>
        /// Takes an Item and returns a bool if the item was added
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItemToInventory(Item item)
        {
            if (_inventoryList.Count < 10)
            {
                _inventoryList.Add(item);
                return true;
            }
            Console.WriteLine("Sorry your inventory is full!");
            return false;
        }

        public int GetCount()
        {
            return _inventoryList.Count;
        }

        public void DeleteItemFromInventory(string itemName)
        {
            _inventoryList.Remove(_inventoryList.Find(x => x.Name == itemName)
                                  ?? throw new NullReferenceException("Item to delete did not exist!"));
        }

        public List<Item> GetInventory() => _inventoryList;

        public Item GetItemFromInventory(string itemName)
        {
            return _inventoryList.FirstOrDefault(x => x.Name == itemName)!;
        }

            
        public void DisplayInventory()
        {
            _inventoryList.ForEach(item =>
            {
                switch (item)
                {
                    case Weapon weapon:
                        Console.WriteLine($"\nName: {weapon.Name}\nRequired level: {weapon.RequiredLevel}" +
                                          $"\nCategory: {weapon.Category}\nBase dmg: {weapon.BaseDamage}\nAps: {weapon.AttacksPerSecond}\nWeaponDps:{weapon.DamagePerSecond}");
                        break;
                    case Armor armor:
                        Console.WriteLine($"\nName: {armor.Name}\nRequired level: {armor.RequiredLevel}" +
                                          $"\nCategory: {armor.Category}\nSlot:{armor.Slot}\nStrength: {armor.PrimaryAttribute.Strength} " +
                                          $"\nDexterity:{armor.PrimaryAttribute.Dexterity}\nIntelligence:{armor.PrimaryAttribute.Intelligence}");
                        break;
                }
            });
        }
    }
}
