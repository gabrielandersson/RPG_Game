using RPG_Game.Enums;

namespace RPG_Game.Items
{
    /// <summary>
    /// Item is the base class for Weapon and Armor
    /// </summary>
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }
        protected Item(string name, int requiredLevel)
        {
            Name = name;
            RequiredLevel = requiredLevel;
        }
    }
}


