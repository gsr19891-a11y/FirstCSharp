using Lecture_Sect_1.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_Sect_1.Models
{
    internal class Teacher : Person , IWorker, IComparable<Teacher>
    {

        public Teacher(string firsName, string lastName, byte age, int workExperience) : base(firsName, lastName, age)
        {
            WorkExperience = workExperience;
        }

        //public string FirsName { get; set; }

        //public string LastName { get; set; }

        //public byte Age { get; set; }

        public int WorkExperience { get; set; }

        public int CompareTo(Teacher? other)
        {
            return this.WorkExperience.CompareTo(other?.WorkExperience);
        }

        public override string? ToString()
        {
            return $"Teacher name: {FirsName} {LastName}, Age: {Age}, Work Experience: {WorkExperience}";
        }






    }
}
