using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.Entities
{
    public class AdminUser : User
    {
        public override UserRole Role => UserRole.Admin;

        public AdminUser(
            int id,
            string username,
            string password,
            string email,
            string? verificationCode,
            bool isVerified)
            : base(
                id,
                username,
                password,
                email,
                verificationCode,
                isVerified)
        {
        }
    }
}
