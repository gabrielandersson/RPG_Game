
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior gabriel = new Warrior("Gabriel");
            gabriel.LevelUp();
            Console.WriteLine($" warrior name: {gabriel.Name}");
            Console.WriteLine($" warrior level: {gabriel.Level}");
            Console.WriteLine($" warrior strength: {gabriel.PrimaryAttribute.Strength}");
            Console.WriteLine($" warrior dexterity: {gabriel.PrimaryAttribute.Dexterity}");
            Console.WriteLine($" warrior intelligence: {gabriel.PrimaryAttribute.Intelligence}");
            
            ItemFactory factory = new ItemFactory();
            var wep = factory.CreateWeapon("cryptodagger");

        }
    }
}



