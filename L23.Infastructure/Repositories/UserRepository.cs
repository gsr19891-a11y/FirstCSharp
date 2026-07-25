using L23.Core.Interfaces;
using L23.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace L23.Infastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private string _path = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\L23.Infastructure\\Data\\UserList.txt";



        //GetUser----------------------------
        public List<User> GetUsers()
        {
            var users = new List<User>();
            var lines = File.ReadAllLines(_path);


            foreach (var line in lines)
            {
                var user = JsonSerializer.Deserialize<User>(line);

                if (user != null)
                {
                    users.Add(user);
                }
            }
            return users;

        }

        //GetUserByEmail----------------------------

        public User GetUserByEmail(string email)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(x => x.Email == email);

            return user;

        }


        //SaveUser-------------------------------
        public void SaveUser(User user)
        {
            var users = GetUsers();
            users.Add(user);

            File.WriteAllText(_path, string.Empty);

            foreach (var item in users)
            {
                var json = JsonSerializer.Serialize(item);

                File.AppendAllText(_path, json + Environment.NewLine);
                
            }
        }

        //UpdateUser-------------------------------
        
        public void UpdateUser(User user)
        {
            var users = GetUsers();
            var existingUser = users.FirstOrDefault(s => s.Id == user.Id);

            if (existingUser != null) {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.IsVerfyed = user.IsVerfyed;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
            }

            File.WriteAllText(_path, string.Empty);

            foreach (var item in users)
            {
                var json = JsonSerializer.Serialize(item);
                File.AppendAllText(_path, json + Environment.NewLine);
            }

        }


        //DeleteUser-------------------------------

        public void DeleteUser(int id)
        {
            var users = GetUsers();
            var userToDelete = users.FirstOrDefault(x => x.Id == id);

            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                File.WriteAllText(_path, string.Empty);


                foreach (var item in users)
                {
                    var json = JsonSerializer.Serialize(item);
                    File.AppendAllText(_path, json + Environment.NewLine);
                }

            }
        }







    }
}


