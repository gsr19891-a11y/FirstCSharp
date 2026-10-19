using System;
using System.Collections.Generic;
using System.Text;
using TechShop.Core.Enums;

namespace TechShop.Core.Models.Entities
{
    public class ClientUser : User
    {
        public UserRole Role => UserRole.Client;

        public ClientUser(int id, string firstName, string lastName, int age, string email, string phone, string password, string verificationCode)
            : base(id, firstName, lastName, age, UserRole.Client, email, phone, password, verificationCode)
        {
        }
    }
}
