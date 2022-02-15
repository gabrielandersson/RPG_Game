
namespace RPG_Game.Shared
{
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
