using System;
using System.Collections.Generic;
using System.Linq;

namespace TuplePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            var name1 = Tuple.Create("a", "b");
            var name2 = Tuple.Create("c", "d");
            var name3 = Tuple.Create("e", "f");
            var name4 = Tuple.Create("g", "h");
            var name5 = Tuple.Create("i", "j");
            list.Add(name1);
            list.Add(name2);
            list.Add(name3);
            list.Add(name4);
            list.Add(name5);
            for(int i = 0; i<list.Count; i++)
            {
                Console.WriteLine(list.ElementAt(i).Item1 + " " + list.ElementAt(i).Item2);
            }
        }
    }
}
