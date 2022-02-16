using System;
using System.IO;
using RPG_Game.HeroClasses;

namespace RPG_Game.IReadHero
{
    //A class that assumes responsibility for reading the state of a hero from a file
    // to be used in conjuction/after the use of StatsSaver to read from specified file
    public class FileReader : IReadHeroState
    {
        public void ReadState(Hero hero, string filename)
        {
            try
            {
                using (StreamReader sr = File.OpenText($"{Environment.CurrentDirectory}}}{@"..\..\..\..\..\"}{filename}"))
                {
                    string? s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
