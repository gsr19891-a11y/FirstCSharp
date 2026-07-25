using L23.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace L23.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVerfyed { get; set; }
        public string VerificationCode { get; set; }

    }
}
