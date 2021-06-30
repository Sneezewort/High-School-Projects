using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Bob", "Smith", 3000);
            p.EyeColor = "Brown";
            Console.WriteLine(p.EyeColor);
            Console.WriteLine(p.YearsAlive);
            p.YearsAlive = 1;
            Console.WriteLine(p.YearsAlive);
        }
    }
}
