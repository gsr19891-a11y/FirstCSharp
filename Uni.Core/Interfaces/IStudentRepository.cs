using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Uni.Core.Models;

namespace Uni.Core.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();

        Student GetStudentByEmail(string email);

        void SaveStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);








    }
}
