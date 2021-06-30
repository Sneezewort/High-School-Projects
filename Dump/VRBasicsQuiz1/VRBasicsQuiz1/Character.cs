using System;
using System.Collections.Generic;
using System.Text;

namespace VRBasicsQuiz1
{
    class Character
    {
        private string name;
        private string cClass;
        private int exp = 0;
        public int getLevel
        {
            get { return (exp / 1000) + 1; }
        }
        public void addExp(int add)
        {
            exp += add;
        }
        public Character(Tuple<string, string> tuple)
        {
            this.name = tuple.Item1;
            this.cClass = tuple.Item2;
        }
        public override string ToString()
        {
            return "Name: " + name + " Class: " + cClass + " Level: " + getLevel;
        }
    }
}
