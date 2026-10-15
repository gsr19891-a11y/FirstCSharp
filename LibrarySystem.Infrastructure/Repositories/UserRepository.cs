using LibrarySystem.Core.Enums;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Users.txt");


        public List<User> GetAll()
        {
            var users = new List<User>();

            var lines = File.ReadAllLines(_path);

            foreach (var line in lines)
            {
                var parts = line.Split('|').Select(x => x.Trim()).ToArray();

                int id = int.Parse(parts[0]);
                string username = parts[1];
                string password = parts[2];
                UserRole role = Enum.Parse<UserRole>(parts[3]);
                decimal fines = decimal.Parse(parts[4]);

                User user = role == UserRole.Admin
                    ? new AdminUser(id, username, password, role, fines)
                    : new ClientUser(id, username, password, role, fines);

                users.Add(user);

            }

            return users;
        }



        public User? GetById(int id)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Id == id);
        }



        public User? GetByUsername(string username)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }


        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            SaveAll(users);
        }



        public void Update(User user)
        {

            var users = GetAll();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
                SaveAll(users);
            }
        }



        private void SaveAll(List<User> users)
        {
            var lines = users.Select(u => $"{u.Id} | {u.Username} | {u.Password} | {u.Role} | {u.Fines}");
            File.WriteAllLines(_path, lines);



        }








    }
}