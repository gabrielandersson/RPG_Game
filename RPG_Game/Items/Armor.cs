using RPG_Game.Enums;
using RPG_Game.Shared;

namespace RPG_Game.Items
{
    public class Armor : Item
    {
        public ArmorCat Category { get; protected set; }
        public PrimaryAttribute PrimaryAttribute;

        /// <summary>
        /// Constructor method for Armor
        /// </summary>
        public Armor(string name, int requiredLevel, Slot slot, ArmorCat category, PrimaryAttribute attribute)
               : base(name, requiredLevel)
        {
            Category = category;
            PrimaryAttribute = attribute;
            Slot = slot;
        }

    }
}
