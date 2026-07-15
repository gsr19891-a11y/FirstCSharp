using Practiculi.Enums;
using Practiculi.Exceptions;
using Practiculi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Models
{
    internal class Student : Person, IPrintable, IComparable<Student>
    {

        private double _gpa;
        public double GPA
        {
            get => _gpa; set
            {
                if (value < 0 || value > 4)
                {
                    throw new InvalidGPAException();
                }
                _gpa = value;

            }
        }

        public Faculty Faculty { get; set; }


        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string? ToString()
        {
            return $"Name: {Name}, GPA: {GPA}, Faculty: {Faculty}";
        }

        int IComparable<Student>.CompareTo(Student? other)
        {

                     //1      //0        //-1
            return this.GPA.CompareTo(other.GPA);
        }



        public static bool operator > (Student student, Student other)
        {
            if(student.GPA > other.GPA)
            {
                return true ;
            }
            return false;
        }

        public static bool operator < (Student student,  Student other)
        {
            if (student.GPA < other.GPA)
            {
                return true;
            }
            return false;
        }

        public static bool operator == (Student student, Student other)
        {
            if (student.GPA == other.GPA)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Student student, Student other)
        {
            if (student.GPA != other.GPA)
            {
                return true;
            }
            return false;
        }









    }
}
