using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public abstract class Hero
    {
        public readonly string Name;
        public int Level { get; set; }
        public double Damage { get; set; }
        public Dictionary<Slot, Item> EquippedItems = new Dictionary<Slot, Item>();
        public TotalAttribute TotalAttribute { get; set; }
        public PrimaryAttribute PrimaryAttribute { get; set; }
        protected HeroClass HeroClass { get; set; }
        public Inventory Inventory { get; set; }
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Inventory = new Inventory();
        }

         public abstract void LevelUp();
        
        public virtual string ShowHeroStats()
        {
            Console.WriteLine($"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}");
            return $"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}";
        }
    }
}




