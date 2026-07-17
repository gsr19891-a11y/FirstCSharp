using Practiculi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Sevices
{
    internal class StudentService
    {

        private readonly string path = @"../../../Data/StudentsData.txt";

        //private const string path1 = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\Practiculi\\Data\\StudentsData.txt";
        public static void SaveFileInfo(string text) {
            File.AppendAllText(@"../../../Data/StudentsData.txt", text.ToString());
        }



        public static List<Student> GetStudents()
        {

            string[] Lines = File.ReadAllLines(@"../../../Data/StudentsData.txt");


            List<Student> students = new List<Student>()
{
    new Student { Name = "George", LastName = "Beridze", Age = 20, Email = "g.beridze@example.com", Faculty = Enums.Faculty.It, Number = "+995555112233", GPA = 3.8 },
    new Student { Name = "Nino", LastName = "Kapanadze", Age = 21, Email = "n.kapanadze@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555445566", GPA = 3.9 },
    new Student { Name = "Luka", LastName = "Masurashvili", Age = 19, Email = "l.masurashvili@example.com", Faculty =Enums.Faculty.Marceting, Number = "+995555778899", GPA = 3.2 },
    new Student { Name = "Maria", LastName = "Ivanova", Age = 22, Email = "m.ivanova@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555114477", GPA = 3.5 },
    new Student { Name = "Alexander", LastName = "Smirnov", Age = 20, Email = "a.smirnov@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555225588", GPA = 2.8 },
    new Student { Name = "Ana", LastName = "Baratamidze", Age = 21, Email = "a.baratamidze@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555336699", GPA = 3.7 },
    new Student { Name = "David", LastName = "Kvirikashvili", Age = 23, Email = "d.kvirikashvili@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555998877", GPA = 4.0 },
    new Student { Name = "Elena", LastName = "Kuznetsova", Age = 19, Email = "e.kuznetsova@example.com", Faculty = Enums.Faculty.It, Number = "+995555665544", GPA = 3.1 },
    new Student { Name = "Teimuraz", LastName = "Shengelia", Age = 22, Email = "t.shengelia@example.com", Faculty = Enums.Faculty.Marceting, Number = "+995555332211", GPA = 3.4 },
    new Student { Name = "Sophia", LastName = "Dias", Age = 20, Email = "s.dias@example.com", Faculty = Enums.Faculty.Bussiness, Number = "+995555775533", GPA = 3.6 }


};
            return students;

            

        }



        public static Student GetStudentByBestGPA()
        {
            List<Student> students = new List<Student>();

            students = GetStudents();



            Student best = students[0];


            foreach (var item in students)
            {
                if (best.GPA < item.GPA)
                {
                    best = item;
                }

            }
            return best;
        }


       


        public static double GetStudentsAverageGPA()
        {
            List<Student> students = new List<Student>();
            students = GetStudents();

            double sum = 0;

            foreach (var item in students)
            {
                sum += item.GPA;


            }
            return sum / students.Count();
        }


        public static Student GetStudentByLastName(string lastName)
        {
            List<Student> students = new List<Student>();
            students = GetStudents();

            foreach (var item in students)
            {
                if (item.LastName == lastName)
                {
                    return item;
                }

            }
            return default;
        }

        public static List<Student> GetSortedStudents(bool asc)
        {
            List<Student> students = new List<Student>();
            students = GetStudents();


            var colection = new List<Student>();

            int n = students.Count;

            if (asc)
            {
                for (int i = 0; i < n -1; i++)
                {
                    int minIndex = i;

                    for (int j = 0; j < n; j++)
                    {
                        if (students[j].CompareTo(students[minIndex]) < 0)
                        {
                            minIndex = j;
                        }
                        if(minIndex != i)
                        {
                            Student temp = students[i];
                            students[i] = students[j];
                            students[minIndex] = temp;

                        }
                        
                    }

                }

            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;

                    for (int j = 0; j < n; j++)
                    {
                        if (students[j].CompareTo(students[minIndex]) > 0)
                        {
                            minIndex = j;
                        }
                        if (minIndex != i)
                        {
                            Student temp = students[i];
                            students[i] = students[j];
                            students[minIndex] = temp;

                        }

                    }

                }
               
            } 
            colection = students;
                return colection;





        }







        public static void AddStudent(Student student)
        {
            List<Student> students = new List<Student>();
            students = GetStudents();



            if (student is null)
            {
                Console.WriteLine("Student could not added its null");

            }
            else
            {
                Console.WriteLine($"Student added");
                students.Add(student);
                SaveFileInfo(student.ToString());
                //File.WriteAllText(@"../../../Data/StudentsData.txt", students.ToString());
                //File.AppendAllText(@"../../../Data/StudentsData.txt", student.ToString());
            }


        }



        public static void DeleteStudent(Student student)
        {
            List<Student> students = new List<Student>();
            students = GetStudents();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == student.Name && students[i].LastName == student.LastName)
                {
                    students.RemoveAt(i);
                }

            }


            students.Remove(student);
            File.WriteAllText(@"../../../Data/StudentsData.txt", students.ToString());


        }

















    }
}
