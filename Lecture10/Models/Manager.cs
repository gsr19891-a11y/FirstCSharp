using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    internal class Manager : Employee
    {
        public Manager()
        {
        }

        public Manager(string name, int age, decimal salary) : base(name, age, salary)
        {
            Salary = salary;
        }

        //public string Name { get; set; }
        //public int Age { get; set; }
        //public decimal Salary { get; set; }
        

        public Lesson[] Lessons { get; set; }

        public override decimal GetSalary()
        {
            return Salary * 2;
        }
    }


}
