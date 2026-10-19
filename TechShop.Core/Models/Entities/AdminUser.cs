using System;
using System.Collections.Generic;
using System.Text;
using TechShop.Core.Enums;

namespace TechShop.Core.Models.Entities
{
    public class AdminUser : User
    {
        public UserRole Role => UserRole.Admin;
        public AdminUser(int id, string firstName, string lastName, int age, UserRole role, string email, string phone, string password, string verificationCode) :
            base(id, firstName, lastName, age, role, email, phone, password, verificationCode)
        {
        }

    }
}
