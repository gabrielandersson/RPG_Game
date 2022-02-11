using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public PrimaryAttribute PrimaryAttribute { get; set; }
        public int TotalAttribute { get; set; }
        public Dictionary<Slot, Item> EquippedItems { get; set; }
        public List<Item> Inventory { get; set; }

        public Hero(string name)
        {
            Name = name;
            EquippedItems = new Dictionary<Slot, Item>();
            Damage = 1;
            Level = 1;
        }
        public abstract void LevelUp();

    }
}
