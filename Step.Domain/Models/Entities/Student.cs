using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Domain.Models.Entities
{
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
        public string Phone { get; set; }
        public bool StatusIsActive { get; set; }

        public override string? ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}, Email: {Email} ";
        }
    }
}
