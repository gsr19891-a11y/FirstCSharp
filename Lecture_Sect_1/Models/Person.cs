using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_Sect_1.Models
{
    internal abstract class Person
    {
        protected Person()
        {
        }

        protected Person(string firsName, string lastName, byte age)
        {
            FirsName = firsName;
            LastName = lastName;
            Age = age;
        }

        public string FirsName { get; set; }

        public string LastName { get; set; }
        public byte Age { get; set; }

        public virtual void PrintAge()
        {
            Console.WriteLine($"Age: {Age}");
        }

    }
}


//object 