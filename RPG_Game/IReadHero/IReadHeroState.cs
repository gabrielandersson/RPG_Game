using RPG_Game.HeroClasses;

namespace RPG_Game.IReadHero
{
    public interface IReadHeroState
    {
        void ReadState(Hero hero, string filename);
    }
}
