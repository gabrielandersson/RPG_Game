using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Inventory
    {
        private List<Item> InventoryList = new List<Item>();
        public bool AddItemToInventory(Item item)
        {
            if (InventoryList.Count < 10)
            {
                InventoryList.Add(item);
                return true;
            }
            else
            {
                Console.WriteLine("Sorry your inventory is full!");
                return false;
            }
        }

        public void DeleteItemFromInventory(string itemName)
        {
            InventoryList?.Remove(InventoryList.Find(x => x.Name == itemName));
        }

        public List<Item> GetInventory() => InventoryList;

        public Item GetItemFromInventory(string itemName)
        {
            return InventoryList.FirstOrDefault(x => x.Name == itemName);
        }

        public void DisplayInventory()
        {
            InventoryList.ForEach(item =>
            {
                if (item is Weapon weapon) Console.WriteLine($"\nName: {weapon.Name}\nRequired level: {weapon.RequiredLevel}" +
                $"\nCategory: {weapon.Category}\nBase dmg: {weapon.BaseDamage}\nAps: {weapon.AttacksPerSecond}\nWeaponDps:{weapon.DamagePerSecond}");

                if (item is Armor armor) Console.WriteLine($"\nName: {armor.Name}\nRequired level: {armor.RequiredLevel}" +
               $"\nCategory: {armor.Category}\nSlot:{armor.Slot}\nStrength: {armor.PrimaryAttribute.Strength} " +
               $"\nDexterity:{armor.PrimaryAttribute.Dexterity}\nIntelligence:{armor.PrimaryAttribute.Intelligence}");

            });
        }
    }
}
