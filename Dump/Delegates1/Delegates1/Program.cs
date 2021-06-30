using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates1
{
    public delegate void isEven(List<int> nums);
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            isEven del = Program.DelegateMethod;
            del(list);
        }
        static void DelegateMethod(List<int> nums)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                if(nums.ElementAt(i) % 2 == 0)
                    Console.WriteLine(nums.ElementAt(i) + " is even");
                else if (nums.ElementAt(i) % 2 == 1)
                    Console.WriteLine(nums.ElementAt(i) + " is odd");
            }
        }
    }
    
}
