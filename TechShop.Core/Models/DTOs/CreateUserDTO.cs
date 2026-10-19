using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.DTOs
{
    internal class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationCode { get; set; }



    }
}
