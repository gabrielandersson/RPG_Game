using RPG_Game.HeroClasses;

namespace RPG_Game.IReadHero
{
    // A neat little interface for all those that would like to see a hero's stats in various ways
    public interface IReadHeroState
    {
        void ReadState(Hero hero, string filename);
    }
}
