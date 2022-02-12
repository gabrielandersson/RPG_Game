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
        public Inventory Inventory { get; set; }
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Inventory = new Inventory();
        }

         public abstract void LevelUp();
    }
}




