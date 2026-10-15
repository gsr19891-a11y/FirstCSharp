using LibrarySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public decimal Fines { get; set; }


        public User(int id, string username, string password, UserRole role, decimal fines = 0)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
            Fines = fines;
        }


        public abstract void DisplayMenu();


    }
}
