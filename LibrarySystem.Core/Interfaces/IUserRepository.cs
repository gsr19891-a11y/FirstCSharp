using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User? GetByUsername(string username);
        void Add(User user);
        void Update(User user);
    }
}
