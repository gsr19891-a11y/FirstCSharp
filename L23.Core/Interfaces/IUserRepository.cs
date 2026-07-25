using L23.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace L23.Core.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();

        public User GetUserByEmail(string email);

        public void SaveUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(int id);
    }
}
