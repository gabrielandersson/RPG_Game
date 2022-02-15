using System;

namespace RPG_Game.Exceptions
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {
        }
    }
}
