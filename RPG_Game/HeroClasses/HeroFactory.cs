using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class HeroFactory
    {

        public Hero CreateHero(string heroClass)
        {
            if (string.Equals(heroClass, "rogue", StringComparison.OrdinalIgnoreCase)) return new Rogue();

            if (string.Equals(heroClass, "warrior", StringComparison.OrdinalIgnoreCase)) return new Warrior();

            if (string.Equals(heroClass, "ranger", StringComparison.OrdinalIgnoreCase)) return new Ranger();

            if (string.Equals(heroClass, "mage", StringComparison.OrdinalIgnoreCase)) return new Mage();

            return null;
        }
    }
}
