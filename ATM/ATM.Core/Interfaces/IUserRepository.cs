using ATM.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByUsername(string username);
        User GetByEmail(string email);
        void Add(User user);
        void SaveAll(List<User> users);
    }
}
