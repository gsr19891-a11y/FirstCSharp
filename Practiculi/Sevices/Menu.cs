using Practiculi.Interfaces;
using Practiculi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Sevices
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("enter 1 - to view student");
            Console.WriteLine("enter 2 - to search best student");
            Console.WriteLine("enter 3 - to GPA calculate");
            Console.WriteLine("enter 4 - to to search student");
            Console.WriteLine("enter 5 - to students filter by GPA");
            Console.WriteLine("enter 6 - to add new student");
            Console.WriteLine("enter 7 - to delete student");
            Console.WriteLine("enter 8 - to exit");


        }


        public static void SelectMenuOptions()
        {


            string choose = "0";


            using (Logger logger = new Logger())
            {
                while (choose != "8")
                {
                    ShowMenu();
                    choose = Console.ReadLine() ?? "0";

                    logger.Log($"User selected option: {choose}");

                    switch (choose)
                    {
                        case "1":
                            var list = StudentService.GetStudents();
                            foreach (var item in list)
                            {

                                if (item is IPrintable printable)
                                {
                                    printable.Print();
                                }
                            }
                            break;


                        case "2":
                            var student = StudentService.GetStudentByBestGPA();
                            Console.WriteLine(student);

                            break;

                        case "3":
                            var average = StudentService.GetStudentsAverageGPA();
                            Console.WriteLine(average);
                            break;

                        case "4":
                            Console.WriteLine("Enter Last Name For Search");
                            var st1 = StudentService.GetStudentByLastName(Console.ReadLine());
                            Console.WriteLine(st1);
                            break;


                        case "5":
                            Console.WriteLine("Choose sorting order:");
                            Console.WriteLine("1. Ascending");
                            Console.WriteLine("2. Descending");
                            string sortChoose = Console.ReadLine() ?? "";

                            bool isAscending = (sortChoose == "1");


                            var sortedList = StudentService.GetSortedStudents(isAscending);


                            Console.WriteLine("\n=== Sorted Students ===");
                            foreach (var item in sortedList)
                            {
                                Console.WriteLine(item);
                            }
                            break;


                        case "6":
                            Console.WriteLine("=== Add New Student ===");

                            Console.Write("Input Name: ");
                            string firstName = Console.ReadLine() ?? "";

                            Console.Write("Input Last Name: ");
                            string lastName = Console.ReadLine() ?? "";

                            Console.Write("Input GPA: ");
                            double.TryParse(Console.ReadLine(), out double gpa);

                            Console.Write("Input Faculty: ");
                            string facultyInput = Console.ReadLine() ?? "";
                            Enum.TryParse(facultyInput, true, out Enums.Faculty parsedFaculty);

                            Student newStudent = new Student
                            {
                                Name = firstName,
                                LastName = lastName,
                                GPA = gpa,
                                Faculty = parsedFaculty
                            };

                            StudentService.AddStudent(newStudent);
                            break;

                        case "7":

                            Console.Write("Input Name: ");
                            string firstName1 = Console.ReadLine() ?? "";

                            Console.Write("Input Last Name: ");
                            string lastName1 = Console.ReadLine() ?? "";

                            Student newStudent1 = new Student
                            {
                                Name = firstName1,
                                LastName = lastName1,
                            };

                            StudentService.DeleteStudent(newStudent1);
                            break;

                        case "8":
                            Console.WriteLine("Goodbye!");
                            break;


                        default:
                            Console.WriteLine("Wrong Option");
                            break;

                    }





                }
            }






        }
    }
}
