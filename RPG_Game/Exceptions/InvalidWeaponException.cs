using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Exceptions
{
    internal class InvalidWeaponException : Exception
    {
        public override string Message => base.Message;
    }
}
