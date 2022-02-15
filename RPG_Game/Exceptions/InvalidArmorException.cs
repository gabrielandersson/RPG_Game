using System;

namespace RPG_Game.Exceptions
{
    /// <summary>
    /// A nice little exception used for the assignment
    ///</summary>
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {
        }
    }
}
