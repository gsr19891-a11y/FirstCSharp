using BankATM.Core.Models.Entities;
using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Interfaces
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);

        User? GetByEmail(string email);

        User? GetById(int id);

        ICollection<User> GetAll();

        void RegisterClient(ClientUser user);

        void AddAdmin(AdminUser admin);

        void Update(User user);
    }
}
