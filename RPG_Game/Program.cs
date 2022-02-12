
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemFactory itemFactory = new ItemFactory();
            var weapon = itemFactory.CreateWeapon("legolas bow");
            var armor = itemFactory.CreateArmor("chainmail of gimli");

            HeroFactory heroFactory = new HeroFactory();
            var adam = heroFactory.CreateHero("Rogue", "adam");

        }
    }
}



