using LibrarySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Models
{
    public class AdminUser : User

    {
        public AdminUser(int id, string username, string password, UserRole role, decimal fines = 0)
     : base(id, username, password, role, fines)
        {
        }





        public override void DisplayMenu()
        {
            throw new NotImplementedException();
        }


        public override bool Equals(object? obj)
        {
            if(obj is AdminUser user)
            {
                return Username == user.Username && Password == user.Password && Role == user.Role && Fines == user.Fines;
            }
            return false;
            
        }



        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password, Role, Fines);
        }



        public override string? ToString()
        {
            return $"AdminUser: Id={Id}, Username={Username}, Password={Password}, Role={Role}, Fines={Fines}";
        }
    }
}
