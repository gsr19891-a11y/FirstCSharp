using ATM.Core.Enums;
using ATM.Core.Interfaces;
using ATM.Core.Models;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ATM.Infrastructure.Repositories
{
    public class FileUserRepository : IUserRepository
    {

        private const string FilePath = @"../../../../ATM.Infrastructure/Data/Users.txt";




        public List<User> GetAll()
        {
            var users = new List<User>();

            if (!File.Exists(FilePath))
            {
                users.Add(new AdminUser(1002, "admin_giorgi", BCrypt.Net.BCrypt.HashPassword("secureAdmin"), "admin@atm.ge", "3333", 0.00m, LoanStatus.None, 0.00m));
                users.Add(new ClientUser(1001, "alex99", BCrypt.Net.BCrypt.HashPassword("pass123"), "alex@gmail.com","1234", 550.50m, LoanStatus.Pending, 200.00m));
                users.Add(new ClientUser(1003, "nino_k", BCrypt.Net.BCrypt.HashPassword("koba777"), "nino@gmail.com","2222", 1200.00m, LoanStatus.Approved, 500.00m));
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

                    if (parts.Length >= 9)
                    {
                        int id = int.Parse(parts[0].Trim());
                        string username = parts[1].Trim();
                        string password = parts[2].Trim();
                        string email = parts[3].Trim();
                        string code = parts[4].Trim();
                        Enum.TryParse(parts[5].Trim(), true, out UserRole role);
                        decimal balance = decimal.Parse(parts[6].Trim(), CultureInfo.InvariantCulture);
                        Enum.TryParse(parts[7].Trim(), true, out LoanStatus loanStatus);
                        decimal loanAmount = decimal.Parse(parts[8].Trim(), CultureInfo.InvariantCulture);
                        bool isVerified = parts.Length >= 10 && bool.TryParse(parts[9].Trim(), out bool parsedIsVerified) && parsedIsVerified;

                        if (role == UserRole.Admin)
                        {
                            var admin = new AdminUser(
                                id,
                                username,
                                password,
                                email,
                                code,
                                balance,
                                loanStatus,
                                loanAmount);

                            admin.IsVerfyed = isVerified;

                            users.Add(admin);
                        }
                        else
                        {
                            var client = new ClientUser(
                                id,
                                username,
                                password,
                                email,
                                code,
                                balance,
                                loanStatus,
                                loanAmount);

                            client.IsVerfyed = isVerified;

                            users.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return users;
        }




        public User GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
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
                var directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var writer = new StreamWriter(FilePath, false))
                {
              
                    writer.WriteLine("// ID | Username | Password | Email | Code | Role | Balance | LoanStatus | LoanAmount | IsVerfyed");
                    foreach (var u in users)
                    {
                        writer.WriteLine($"{u.Id} | {u.Username} | {u.Password} | {u.Email} | {u.VerificationCode} | {u.Role} | {u.Balance.ToString("F2", CultureInfo.InvariantCulture)} | {u.LoanStatus} | {u.LoanAmount.ToString("F2", CultureInfo.InvariantCulture)} | {u.IsVerfyed}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Save: {ex.Message}");
            }
        }



        public User GetByEmail(string email)
        {
            return GetAll().FirstOrDefault(u =>
                u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }









    }
}













