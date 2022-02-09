using System;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Person gg = new Person();
            gg.Name = "lolita";
            Console.WriteLine(gg.Name);
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
}
