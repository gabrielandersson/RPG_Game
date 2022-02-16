using RPG_Game.HeroClasses;
using RPG_Game.IReadHero;

namespace RPG_Game
{
    internal class Program
    {
        //just something to try out for fun if you want, also - main() looked lonely..
        static void Main(string[] args)
        {
            var rogue = new Rogue("gabriel", new FileReader());
            var warrior = new Warrior("the mountain", new RealConsoleLogger());

            #region ForFun
            // creates a file with the rogue hero obj stats with the specified name
            // should be placed in root of project folder 
                //var saver = new StatsSaver();
                //saver.LogStats(rogue, "examplefile");

               // Reads from the file itself
               // rogue.ReadHeroState.ReadState(rogue, "examplefile");

               // Reads directly from hero and output the stats to the console
                //warrior.ReadHeroState.ReadState(rogue, "examplefile");
            #endregion
        }
    }
}



