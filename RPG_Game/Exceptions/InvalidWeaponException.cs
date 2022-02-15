using System;

namespace RPG_Game.Exceptions
{
    /// <summary>
    /// A nice little exception used for the assignment
    ///</summary>
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {
        }
    }
}
