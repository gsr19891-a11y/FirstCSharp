using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Domain.Models.DTOs
{
    public class UpdateStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool StatusIsActive { get; set; }
    }
}
