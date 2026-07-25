using System;
using System.Collections.Generic;
using System.Text;
using Uni.Core.Interfaces;
using Uni.Core.Models;

namespace Uni.Services
{
    public class StudentService
    {


        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //----------------------------------------------------------------

        public void StudentRegister(Student student)
        {
            var students = _studentRepository.GetStudents();



            if (!student.Email.Contains("@"))
            {
                throw new ArgumentException("Invalid Email Address.");
            }

            int idCounter;

            if (students.Count == 0)
            {

                idCounter = 0;
            }
            else
            {
                idCounter = students.Max(x => x.Id);
            }



            //id and password

            student.Id = idCounter + 1;

            student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password); //Todo method

            Random random = new Random();
            student.VerificationCode = random.Next(1000, 9999).ToString();


            EmailService.SendEmail(student.Email, "Email Verification", $"Your verification code is: {student.VerificationCode}");
           

            _studentRepository.SaveStudent(student);



        }

        //----------------------------------------------------------------


        public void Login(string email, string password){
           Student student = _studentRepository.GetStudentByEmail(email);

            if (student == null) {

                throw new ArgumentException("Invalid Email ");
            
            }

            if(!BCrypt.Net.BCrypt.Verify(password, student.Password))
            {
                throw new ArgumentException("Invalid Password");
            }

            if(student.IsVerified == false)
            {
                throw new ArgumentException("Please Verify your account ");
            }

            Console.WriteLine("Welcome!");

        }


        //----------------------------------------------------------------
        public void VerifyStudent(string email, string verificationcode)
        {
            Student student = _studentRepository.GetStudentByEmail(email);

            if (student == null)
            {

                throw new ArgumentException("Invalid Email ");

            }

            if(student.VerificationCode != verificationcode)
            {
                throw new ArgumentException("Invalid verification code ");
            }
            Console.WriteLine("Verification succsessful");

            student.IsVerified = true;

            UpdateStudent(student);

        

        }

        //----------------------------------------------------------------



        public void UpdateStudent(Student student)
        {

            //todo შემოწმდეს პაროლი თუ იცვლება და თუ კი მაშნ აქაც გვინა ჰეშირება


            if (!student.Email.Contains("@"))
            {
                throw new ArgumentException("Invalid Email");
            }



            _studentRepository.UpdateStudent(student);

        }
        //----------------------------------------------------------------

        public void DeleteStudent(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            _studentRepository.DeleteStudent(id);

        }







    }
}

//rnqq ifez spzt usri