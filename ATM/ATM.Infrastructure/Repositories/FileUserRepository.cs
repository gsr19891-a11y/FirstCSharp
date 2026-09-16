using ATM.Core.Enums;
using ATM.Core.Interfaces;
using ATM.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ATM.Infrastructure.Repositories
{
    public class FileUserRepository : IUserRepository
    {

        private const string FilePath = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\ATM.Infrastructure\\Data\\Users.txt";

        public List<User> GetAll()
        {
            var users = new List<User>();

            if (!File.Exists(FilePath))
            {
                users.Add(new AdminUser(1002, "admin_giorgi", "secureAdmin", 0.00m, LoanStatus.None, 0.00m));
                users.Add(new ClientUser(1001, "alex99", "pass123", 550.50m, LoanStatus.Pending, 200.00m));
                users.Add(new ClientUser(1003, "nino_k", "koba777", 1200.00m, LoanStatus.Approved, 500.00m));
                SaveAll(users);
                return users;
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                        continue;

                    string[] parts = line.Split('|');

                    if (parts.Length >= 7)
                    {
                        int id = int.Parse(parts[0].Trim());
                        string username = parts[1].Trim();
                        string password = parts[2].Trim();
                        Enum.TryParse(parts[3].Trim(), true, out UserRole role);
                        decimal balance = decimal.Parse(parts[4].Trim(), CultureInfo.InvariantCulture);
                        Enum.TryParse(parts[5].Trim(), true, out LoanStatus loanStatus);
                        decimal loanAmount = decimal.Parse(parts[6].Trim(), CultureInfo.InvariantCulture);

                        if (role == UserRole.Admin)
                            users.Add(new AdminUser(id, username, password, balance, loanStatus, loanAmount));
                        else
                            users.Add(new ClientUser(id, username, password, balance, loanStatus, loanAmount));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return users;
        }




        public User GetByUsernameAndPassword(string username, string password)
        {
            return GetAll().FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }


        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            SaveAll(users);
        }



        public void SaveAll(List<User> users)
        {
            try
            {
                using (var writer = new StreamWriter(FilePath, false))
                {
                    writer.WriteLine("// ID | Username | Password | Role | Balance | LoanStatus | LoanAmount");
                    foreach (var u in users)
                    {
                        writer.WriteLine($"{u.Id} | {u.Username} | {u.Password} | {u.Role} | {u.Balance.ToString("F2", CultureInfo.InvariantCulture)} | {u.LoanStatus} | {u.LoanAmount.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Save: {ex.Message}");
            }
        }













    }
}













