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
        public void AddItemToInventory(Item item)
        {
            if(InventoryList.Count < 10) InventoryList.Add(item);
            else { Console.WriteLine("Sorry your inventory is full!");}
        }
        public void DeleteItemFromInventory(string itemName) => InventoryList.Remove(InventoryList.Find(x => string.Equals(x.Name, itemName, StringComparison.OrdinalIgnoreCase)));
        public List<Item> GetInventory() => InventoryList;
        public Item GetItemFromInventory(string itemName) => InventoryList.Find(x => string.Equals(x.Name, itemName, StringComparison.OrdinalIgnoreCase));
        public void DisplayInventory()
        {
            InventoryList.ForEach(item =>
            {
                if (item is Weapon weapon) Console.WriteLine($"\nName: {weapon.Name}\nRequired level: {weapon.RequiredLevel}" +
                $"\nCategory: {weapon.Category}\nBase dmg: {weapon.BaseDamage}\nAps: {weapon.AttacksPerSecond}" +
                $"\nDmg: {weapon.Damage}");

                if (item is Armor armor) Console.WriteLine($"\nName: {armor.Name}\nRequired level: {armor.RequiredLevel}" +
               $"\nCategory: {armor.Category}\nSlot:{armor.Slot}\nStrength: {armor.PrimaryAttributes.Strength} " +
               $"\nDexterity:{armor.PrimaryAttributes.Dexterity}\nIntelligence:{armor.PrimaryAttributes.Intelligence}");

            });
        }
    }
}
