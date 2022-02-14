﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Armor : Item
    {
        public ArmorCat Category { get; set; }
        public PrimaryAttribute PrimaryAttribute;
        public Armor(string name, int requiredLevel, Slot slot, ArmorCat category, PrimaryAttribute attribute)
                     : base(name, requiredLevel, slot)
        {
            Category = category;
            PrimaryAttribute = attribute;
            Slot = slot;

        }

        public override Armor Duplicate()
        {
            return new Armor(Name,RequiredLevel, Slot, Category, PrimaryAttribute);
        }

    }
}
