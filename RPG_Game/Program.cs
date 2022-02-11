
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

            Console.WriteLine($" warrior name: {gabriel.Name}");
            Console.WriteLine($" warrior level: {gabriel.Level}");
            Console.WriteLine($" warrior strength: {gabriel.PrimaryAttribute.Strength}");
            Console.WriteLine($" warrior dexterity: {gabriel.PrimaryAttribute.Dexterity}");
            Console.WriteLine($" warrior intelligence: {gabriel.PrimaryAttribute.Intelligence}");
            Console.WriteLine($"warrior dmg: {gabriel.Damage}"); 

            ItemFactory factory = new ItemFactory();
            var wep = factory.CreateWeapon("cryptodagger");
            var armor = factory.CreateArmor("potato sack");
            var wep2 = factory.CreateWeapon("nerfsword");
            
            gabriel.EquippedItems.Add(wep.Slot, wep);
            //gabriel.EquippedItems.Add(wep2.Slot, wep2);


        }
    }
}



