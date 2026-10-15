using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Domain.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAll();

        Student? GetById(int id);

    }
}
