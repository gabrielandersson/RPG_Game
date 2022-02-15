using System;

namespace RPG_Game.Exceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {
        }
    }
}
