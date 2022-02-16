using System;
using System.IO;
using RPG_Game.HeroClasses;

namespace RPG_Game.IReadHero
{
    //A little class that assumes the responsibiity of writing the state/stats of a hero to a textfile
    //If you want to try it out i left a little example in the Main() in Region-ForFun
    public class StatsSaver
    {
        public void LogStats(Hero hero, string fileName)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\", fileName);
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Name: {hero.Name}\nLevel: {hero.Level}\nStrength: {hero.TotalAttribute.Strength}");
                    sw.WriteLine($"Dexterity: {hero.TotalAttribute.Dexterity}");
                    sw.WriteLine($"Intelligence: {hero.TotalAttribute.Intelligence}\nDamage: {hero.Damage}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
