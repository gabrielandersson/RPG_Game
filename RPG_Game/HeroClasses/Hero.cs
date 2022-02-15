using System;
using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;

namespace RPG_Game.HeroClasses
{
    /// <summary>
    /// Base class for all hero classes, made the choice to make the name unchangeable,
    /// who knows - at some point maybe someone will pay for getting it changed - blizzard style?
    /// Future endeavors might entail some kind of decoupling for the EquipHandler.
    /// </summary>
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
        /// <summary>
        /// Writes out a hero's stats to the standard output stream, only reason i made this virtual is if
        /// some future hero might have new stats they want to display. 
        /// </summary>
        /// <returns></returns>
        public virtual string ShowHeroStats()
        {
            Console.WriteLine($"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}");
            return $"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}";
        }
    }
}




