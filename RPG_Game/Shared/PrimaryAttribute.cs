namespace RPG_Game.Shared
{
    /// <summary>
    /// Encapsulation of a hero's primary attributes gained from lvl up, default constructor omitted
    /// since it didn't feel necessary for my purposes at this point in time.
    /// </summary>
    public class PrimaryAttribute
    {
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Intelligence { get; set; }

        public PrimaryAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
    }
}
