using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    internal abstract class Employee : Person
    {
        public Employee()
        {
        }

        public Employee(string name, int age, decimal salary) : base(name, age)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public virtual decimal GetSalary() {

            return Salary; 
        }
    }
}
