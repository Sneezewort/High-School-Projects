using System;
using System.Collections.Generic;
using System.Text;

namespace Day2Demo
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int daysAlive;
        public string EyeColor { get; set; }
        public float YearsAlive
        {
            get { return (float)(daysAlive / 365.0); }
            set { daysAlive = (int)(value * 365);  }
        }
        public Person(string firstName, int daysAlive)
        {
            this.firstName = firstName;
            this.daysAlive = daysAlive;
        }
        public Person(string firstName, string lastName, int daysAlive)
            : this(firstName, daysAlive)
        {
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
