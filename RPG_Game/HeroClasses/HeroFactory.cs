using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class HeroFactory
    {

        public Hero CreateHero(string heroClass, string name)
        {
            if (string.Equals(heroClass, "rogue", StringComparison.OrdinalIgnoreCase)) return new Rogue(name);

            if (string.Equals(heroClass, "warrior", StringComparison.OrdinalIgnoreCase)) return new Warrior(name);

            if (string.Equals(heroClass, "ranger", StringComparison.OrdinalIgnoreCase)) return new Ranger(name);

            if (string.Equals(heroClass, "mage", StringComparison.OrdinalIgnoreCase)) return new Mage(name);

            return null;
        }
    }
}
