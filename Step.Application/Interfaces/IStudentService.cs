using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Application.Interfaces
{
    public interface IStudentService
    {
        public void DisplayAllStudents();

        Student GetStudentById(int id);
    }
}
