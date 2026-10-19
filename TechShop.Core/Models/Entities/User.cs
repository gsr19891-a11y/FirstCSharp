using System;
using System.Collections.Generic;
using System.Text;
using TechShop.Core.Enums;

namespace TechShop.Core.Models.Entities
{
    public abstract class User
    {
        private string username;

        protected User(int id, string firstName, string lastName, int age, UserRole role, string email, string phone, string password,string verificationCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Role = role;
            Email = email;
            Phone = phone;
            Password = password;
            VerificationCode = verificationCode;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationCode { get; set; }
    }
}
