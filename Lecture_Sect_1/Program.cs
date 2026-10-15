using Lecture_Sect_1.Models;

namespace Lecture_Sect_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Student student = new Student("John", "Doe", 20, 85.5m, true);

            student.FirsName = "John";
            student.LastName = "Doe";
            student.Point = 85.5m;
            student.Attend = true;
            student.Age = 20;

            student.Print(student.FirsName, student.LastName);

            Console.WriteLine(student.ToString());


            Teacher teacher = new Teacher("Jane", "Smith", 35,10);

            Teacher teacher2 = new Teacher("jujua", "spin", 35,5);


            student.PrintAge();



                                //1                //-1
            Console.WriteLine(teacher.CompareTo(teacher2));








            string path = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\Lecture_Sect_1\\Models\\Data\\Data.txt";
                
            string[] lines = File.ReadAllLines(path);

            foreach (var item in lines)
            {
                string[] dataParts = item.Split(',');

                Console.WriteLine(dataParts[0]);
                
            }





            

            Student student2 = new Student();
            student2.Attend = true;
            student2.Point = 90.5m;
            student2.FirsName = "Alice";


            List<string> lines2 = new List<string>();


            File.AppendAllText(path, Environment.NewLine + student2.FirsName + "," + student2.LastName + "," + student2.Age + "," + student2.Point + "," + student2.Attend);


        }
    }
}
