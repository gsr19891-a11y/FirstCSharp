using BankATM.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();

        User? GetByUsername(string username);

        User? GetByEmail(string email);

        void Add(User user);

        void SaveAll(ICollection<User> users);
    }
}
