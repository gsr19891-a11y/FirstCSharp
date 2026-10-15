using LibrarySystem.Core.Enums;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public User Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) { 
                throw new ArgumentException("Invalid username or password");
            }
            if (user.Password != password) { 
                throw new ArgumentException("Invalid username or password");
            }
            return user;
        }



        public User Register(string username, string password, UserRole role) {
            var user = _userRepository.GetByUsername(username);
            if (user != null) {
                throw new ArgumentException("Username already exists");
            }

            var allUsers = _userRepository.GetAll();
            int newId = allUsers.Max(u => u.Id) + 1;

            User newUser = role == UserRole.Admin
                ? new AdminUser(newId, username, password, role)
                : new ClientUser(newId, username, password, role);

            _userRepository.Add(newUser);

            return newUser;



        }




    }
}
