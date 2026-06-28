using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12.Models
{
    internal class Student

    {
        public Student(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age {  get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
