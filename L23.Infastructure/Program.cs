using Uni.Core.Interfaces;
using Uni.Core.Models;
using Uni.Infastructure.Repositories;
using Uni.Services;

namespace Uni.UII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //Student student = new Student();
            //// student.Id = 1; //todo
            //student.Name = "John";
            //student.Age = 20;
            //student.Email = "rame@gmail.or";
            //student.Gender = Core.Enums.Gender.Male;
            //student.Password = "1234";//salt
            //student.Subjects = new List<Subject>
            //{
            //    new Subject {Id = 1, Title = "Math", Grade = 3},
            //    new Subject {Id = 2, Title = "Science", Grade = 5}
            //};

          



            IStudentRepository studentRepository = new StudentRepository();
            //StudentService studentService = new StudentService(studentRepository);

            //test data 
            IStudentRepository studentRepositoryTest = new StudentRepositoryTest();

            StudentService studentService = new StudentService(studentRepositoryTest);

            //studentService.StudentRegister(student);





            //try
            //{

            //    Console.WriteLine("Enter Email:");
            //    string email = Console.ReadLine();
            //    Console.WriteLine("Enter Password:");
            //    string password = Console.ReadLine();

            //    studentService.Login(email, password);


            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}






            //-----------------------------

            //Student student2 = new Student();
            //student2.Id = 1; //todo
            //student2.Name = "Lince";
            //student2.Age = 20;
            //student2.Email = "rame123@gmail.or";
            //student2.Gender = Core.Enums.Gender.Male;
            //student2.Subjects = new List<Subject>
            //{
            //    new Subject {Id = 1, Title = "Math", Grade = 3},
            //    new Subject {Id = 2, Title = "Science", Grade = 5}
            //};

            //studentService.UpdateStudent(student2);


            //Student student2 = new Student();
            //// student.Id = 1; //todo
            //student2.Name = "Giorgi";
            //student2.Age = 22;
            //student2.Email = "gsr19891@gmail.com";
            //student2.Gender = Core.Enums.Gender.Male;
            //student2.Password = "pass1234";//salt
            //student2.Subjects = new List<Subject>
            //{
            //    new Subject {Id = 1, Title = "Math", Grade = 3},
            //    new Subject {Id = 2, Title = "Science", Grade = 5}
            //};

            //studentService.StudentRegister(student2);



            try
            {

                Console.WriteLine("Enter Email for verify:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Code:");
                string verificationCode = Console.ReadLine();

                studentService.VerifyStudent(email, verificationCode);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




            //studentService.DeleteStudent(1);




        }
    }
}
