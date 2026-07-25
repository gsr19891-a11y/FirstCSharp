using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Uni.Core.Enums;

namespace Uni.Core.Models
{
    public class Student : Subject
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public bool IsVerified { get; set; } = false;


        public List<Subject> Subjects { get; set; }
        public Gender Gender { get; set; }




    }
}
