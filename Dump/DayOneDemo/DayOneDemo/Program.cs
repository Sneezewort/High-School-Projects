using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DayOneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a string : ");
            string str = Console.ReadLine();
            Console.Write("Please enter a second string : ");
            var str2 = Console.ReadLine();
            Console.WriteLine(str);
            Console.WriteLine(str2);
            int total = 0;
            do
            {
                Console.Write("Please enter a number - 0 to stop : ");
                try
                {
                    str = Console.ReadLine();
                    total += Int32.Parse(str);
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
          
            } while (!str.Equals("0"));
            Console.WriteLine(total);
            List<int> list = new List<int>();
            int x = 1;
            while (x<=10)
            {
                list.Add(x);
                x++;
            }
            Console.WriteLine(list);
            for(int i = 1; i<list.Count; i++)
            {
                Console.WriteLine(list.ElementAt(i) + " or " + list[i]);
            }
            foreach (int number in list)
                Console.WriteLine("Num : {0} is a number and {1} is the string we used b4 ", number, str);
            // Tuples - Named and Unnamed
            var tupleOne = (1, "apple", 2);
            var tupleTwo = (firstName: "bob", secondName: "smith");
            Console.WriteLine(tupleOne.Item1);
            Console.WriteLine(tupleTwo.firstName);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("E302", "Schiff");
            dictionary.Add("100", "Miller");
            dictionary.Add("205", "Hayston");
            string name = "";
            dictionary.TryGetValue("100", out name);
            Console.WriteLine(name);
           
        }
        public static (string, string) NamePairs(string first, string second)
        {
            var NamePairs = ("1", "2");
            return NamePairs;
        }
    }
}
