using System;
using System.Collections.Generic;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;
using RPG_Game.IReadHero;
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
        public IReadHeroState ReadHeroState { get; set; }

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Inventory = new Inventory();
            EquipHandler = new EquipHandler();
        }
        #region ConstructorForFun
        protected Hero(string name, IReadHeroState log)
        {
            Name = name;
            Level = 1;
            Inventory = new Inventory();
            EquipHandler = new EquipHandler();
            ReadHeroState = log;
        }
        #endregion
        /// <summary>
        ///  Returns string with all the  hero's stats
        /// </summary>
        /// <returns></returns>
        public virtual string ShowHeroStats()
        {
            return $"\nName: {Name}\nLevel: {Level}\nStrength: {TotalAttribute.Strength}\nDexterity: {TotalAttribute.Dexterity}\nIntelligence: {TotalAttribute.Intelligence}\nDamage: {Damage}";
        }
    }
}




