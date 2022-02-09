using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public string Slot { get; set; }
    }
    class Candy : Item
    {
    }
}
