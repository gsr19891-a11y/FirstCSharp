using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Uni.Core.Interfaces;
using Uni.Core.Models;

namespace Uni.Infastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {



        private readonly string _path = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\Uni.Infastructure\\Data\\Students.txt";



        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            var lines = File.ReadAllLines(_path);

            foreach (var line in lines)
            {

                var student = JsonSerializer.Deserialize<Student>(line);
                if (student != null)
                {
                    students.Add(student);
                }
            }
            return students;

        }





        public Student GetStudentByEmail(string email)
        {
            var students = GetStudents();
            var student = students.FirstOrDefault(x => x.Email == email);

            return student;

        }



        public void SaveStudent(Student student)
        {
            var students = GetStudents();
            students.Add(student);

            File.WriteAllText(_path, string.Empty);
            foreach (var item in students)
            {

                var json = JsonSerializer.Serialize(item);


                File.AppendAllText(_path, json + Environment.NewLine);
            }




        }


        public void UpdateStudent(Student student)
        {
            var students = GetStudents();
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {

                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Age = student.Age;
                existingStudent.Subjects = student.Subjects;
                existingStudent.Gender = student.Gender;
                existingStudent.IsVerified = student.IsVerified;
                existingStudent.Password = student.Password;


            }

            int index = students.IndexOf(existingStudent);
            students[index] = existingStudent;



            File.WriteAllText(_path, string.Empty);
            foreach (var item in students)
            {

                var json = JsonSerializer.Serialize(item);

                File.AppendAllText(_path, json + Environment.NewLine);
            }



        }


        public void DeleteStudent(int id)
        {
            var students = GetStudents();
            var studentToDelete = students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
                File.WriteAllText(_path, string.Empty);
                foreach (var item in students)
                {

                    var json = JsonSerializer.Serialize(item);

                    File.AppendAllText(_path, json + Environment.NewLine);
                }
            }
        }
















    }
}
