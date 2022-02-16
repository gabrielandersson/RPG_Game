using System;
using RPG_Game.HeroClasses;

namespace RPG_Game.IReadHero
{
    // A class that assumes responsibility for outputting the hero's stats directly to the console
    public class RealConsoleLogger : IReadHeroState
    {
        public void ReadState(Hero hero, string filename)
        {
            Console.WriteLine($"\nName: {hero.Name}\nLevel: {hero.Level}\nStrength: {hero.TotalAttribute.Strength}\nDexterity: {hero.TotalAttribute.Dexterity}\nIntelligence: {hero.TotalAttribute.Intelligence}\nDamage: {hero.Damage}");
        }
    }
}
