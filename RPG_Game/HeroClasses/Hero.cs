﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public  abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PrimaryAttribute PrimaryAttribute { get; set; }

        public Dictionary<Slot, Item> Equipment { get; set; }


        public void PrintStats()
        {
            Console.WriteLine($"{Name} {PrimaryAttribute.Strength} {PrimaryAttribute.Dexterity} {PrimaryAttribute.Intelligence}");
        }

    }
}
