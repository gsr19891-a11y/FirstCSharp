using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool IsVerified { get; set; }
        public string? VerificationCode { get; set; }

        public abstract UserRole Role { get; }

        protected User(
            int id,
            string username,
            string password,
            string email,
            string? verificationCode,
            bool isVerified)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            VerificationCode = verificationCode;
            IsVerified = isVerified;
        }
    }
}
