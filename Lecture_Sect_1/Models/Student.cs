using Lecture_Sect_1.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_Sect_1.Models
{
    internal class Student : Person , IWorker
    {

         public Student() { }
 
        public Student(string firstname, string lastname, byte age, decimal point, bool attend) : base(firstname, lastname, age)
        {
            Point = point;
            Attend = attend;
      
    
        }

        public Student(string firsName, string lastName, byte age) : base(firsName, lastName, age)
        {
        }


       

        //public string FirsName { get; set; }

        //public string LastName { get; set; }

        public decimal Point { get; set; }
        //public byte Age { get; set; }
        public bool Attend { get; set; }



        //----------------------------------------------
        public void Print(string name, string surename)
        {
            Console.WriteLine($"Student name: {name} {surename}");
        }


        public void Print(string name)
        {
            Console.WriteLine($"Student name: {name}");
        }

        //----------------------------------------------- ოვერლოადინგ overloading - იგივე მეთოდის სხვადასხვა ვერსია, განსხვავებული პარამეტრებით


        public override string? ToString()
        {
            return $"Student name: {FirsName} {LastName}, Age: {Age}, Point: {Point}, Attend: {Attend}";
        }

        public override void PrintAge()
        {
            Console.WriteLine($"My Age is: {Age}");
        }



        public override bool Equals(object? obj)
        {

            if(obj is Student student)
            {
               return FirsName == student.FirsName && LastName == student.LastName && Age == student.Age && Point == student.Point && Attend == student.Attend;
            }
            else
            {
                return false;
            }


           
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirsName, LastName, Age, Point, Attend);
        }
    }
}

//--------------------------------------------------------------------------

//virtual - მშობელს - შეუძლია გადააკეთოს შეუძლია არა
//override - შვილი


//abstract - მშობელი,შვილა მუეჭველი უნდა გადააკეთოს (თვითონ კლასიც უნდა იყოს abstract)


//--------------------------------------------------------------------------

