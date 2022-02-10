
using System;
using System.Collections.Generic;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HeroFactory factory = new HeroFactory();
            var gabriel = factory.CreateHero("RaNgeR");
            Console.WriteLine(gabriel.Name);
            Console.WriteLine(gabriel.GetType());
        }
    }

}



