using Lecture_10.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    internal class Student : Person
    {
        public Student()
        {
        }

        public Student(string name, int age, double gpa,Subject[] subjects) : base(name, age)
        {
            GPA = gpa;
      
            Subjects = subjects;
        }

        //public string Name { get; set; }
        //public int Age { get; set; }
        public double GPA { get; set; }

        public Subject[] Subjects { get; set; }
    }




}
