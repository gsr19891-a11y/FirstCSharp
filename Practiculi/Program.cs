using Practiculi.Models;
using Practiculi.Sevices;

namespace Practiculi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //List<Student> students = StudentService.GetStudents();
          


            //while (true)
            //{
            //    Console.WriteLine("enter 1 - to view student");
            //    Console.WriteLine("enter 2 - to search best student");
            //    Console.WriteLine("enter 3 - to GPA calculate");
            //    Console.WriteLine("enter 4 - to to search student");
            //    Console.WriteLine("enter 5 - to students filter by GPA");
            //    Console.WriteLine("enter 6 - to add new student");
            //    Console.WriteLine("enter 7 - to delete student");
            //    Console.WriteLine("enter 8 - to exit");



            //    string choose = Console.ReadLine();

            //    switch (choose)
            //    {
            //        case "1":
            //            foreach (var student in students)
            //            {
            //                Console.WriteLine(student);

            //            }

            //        break;

            //        case "2":
            //            double maxGpa = 0;
            //            Student? bestStudent = null;

            //            foreach (var item in students)
            //            {


            //                if (item.GPA > maxGpa)
            //                {
            //                    maxGpa = item.GPA;
            //                    bestStudent = item;

            //                }


            //            }
            //            if(bestStudent != null)
            //            {
            //                Console.WriteLine($"Best student: {bestStudent.Name}, GPA: {bestStudent.GPA}");
            //            }

            //        break;

            //    }
            //}



            Menu.SelectMenuOptions();






        }
    }
}
