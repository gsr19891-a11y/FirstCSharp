using ATM.Core.Enums;
using BankATM.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Domain.Models.Entities
{
    public class ClientUser : User
    {
        public override UserRole Role => UserRole.Client;

        public ClientUser(
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
