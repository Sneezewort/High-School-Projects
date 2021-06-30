using System;

namespace VRBasicsQuiz1
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = Tuple.Create("Eric", "Peasant");
            Character c = new Character(character);
            Console.WriteLine(c.ToString());
            c.addExp(500);
            Console.WriteLine(c.ToString());
            c.addExp(500);
            Console.WriteLine(c.ToString());
            c.addExp(3000);
            Console.WriteLine(c.ToString());
        }
    }
}
