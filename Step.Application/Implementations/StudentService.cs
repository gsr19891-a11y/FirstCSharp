using Step.Application.Interfaces;
using Step.Domain.Interfaces;
using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Application.Implementations
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public void DisplayAllStudents()
        {
            var students = _studentRepository.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine(item);
                
            }
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }


    }
}
