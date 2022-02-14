﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class PrimaryAttribute
    {
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Intelligence { get; set; }
        public PrimaryAttribute()
        {

        }
        public PrimaryAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
    }
}
