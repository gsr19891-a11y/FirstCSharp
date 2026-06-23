using Lecture_10.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    internal class Teacher : Employee
    {
        public Teacher()
        {
        }

        public Teacher(string name, int age, decimal salary) : base(name, age, salary)
        {
        }

        //public string Name { get; set; }
        //public int Age { get; set; }
        //public decimal Salary { get; set; }

        public Subject[] Subjects { get; set; }
        public Lesson[] Lessons { get; set; }

        public override decimal GetSalary()
        {
            return Salary * 1.5m;
        }
       
    }
}
