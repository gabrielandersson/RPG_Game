using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public abstract class Hero
    {
        protected readonly string Name;
        protected int Level { get; set; }
        protected int Damage { get; set; }
        protected int TotalAttribute { get; set; }
        protected PrimaryAttribute PrimaryAttribute { get; set; }
        protected HeroClass HeroClass { get; set; }
        private List<Item> Inventory { get; set; }

        public Hero(string name)
        {
            Name = name;
            Inventory = new List<Item>();
            Damage = 1;
            Level = 1;
        }
        public abstract void LevelUp();
        public void AddItemToInventory(Item item) => Inventory.Add(item);
        public void DeleteItemFromInventory(string itemName) => Inventory.Remove(Inventory.Find(x => string.Equals(x.Name, itemName, StringComparison.OrdinalIgnoreCase)));
        public List<Item> GetInventory() => Inventory;
        public Item GetItemFromInventory(string itemName) => Inventory.Find(x => string.Equals(x.Name, itemName, StringComparison.OrdinalIgnoreCase));
        public void DisplayInventory()
        {
            Inventory.ForEach(item =>
            {
                if (item is Weapon weapon) Console.WriteLine($"\nName: {weapon.Name}\nRequired level: {weapon.RequiredLevel}" +
                $"\nCategory: {weapon.Category}\nBase dmg: {weapon.BaseDamage}\nAps: {weapon.AttacksPerSecond}" +
                $"\nDmg: {weapon.Damage}");

                if(item is Armor armor) Console.WriteLine($"\nName: {armor.Name}\nRequired level: {armor.RequiredLevel}" +
              $"\nCategory: {armor.Category}\nSlot:{armor.Slot}\nStrength: {armor.PrimaryAttributes.Strength} " +
              $"\nDexterity:{armor.PrimaryAttributes.Dexterity}\nIntelligence:{armor.PrimaryAttributes.Intelligence}");

            });
        }
         
    }
}




