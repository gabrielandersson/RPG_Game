using System;
using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game.HeroClasses
{
    public abstract class Hero
    {
        public readonly string Name;
        public int Level { get; protected set; }
        public double Damage { get; set; }
        public Dictionary<Slot, Item>? EquippedItems { get; set; }
        public TotalAttribute? TotalAttribute { get; protected set; }
        public EquipHandler EquipHandler { get; protected set; }
        public PrimaryAttribute? PrimaryAttribute { get; protected set; }
        public Inventory Inventory { get; }
        protected Hero(string name)
        {
            Name = name;
            Level = 1;
            Inventory = new Inventory();
            EquipHandler = new EquipHandler();
        }

        public virtual string ShowHeroStats()
        {
            Console.WriteLine($"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}");
            return $"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}";
        }
    }
}




