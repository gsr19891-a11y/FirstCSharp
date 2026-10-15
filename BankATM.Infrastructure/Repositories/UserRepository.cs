using ATM.Core.Enums;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using Microsoft.Data.SqlClient;
using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<User> GetAll()
        {
            List<User> users = new List<User>();
            const string query = "SELECT Id, Username, Password, Email, Role, LoanStatus, LoanAmount, IsVerified, VerificationCode, Balance FROM Users";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string username = reader.GetString(reader.GetOrdinal("Username"));
                string password = reader.GetString(reader.GetOrdinal("Password"));
                string email = reader.GetString(reader.GetOrdinal("Email"));
                UserRole role = (UserRole)reader.GetInt32(reader.GetOrdinal("Role"));
                LoanStatus loanStatus = (LoanStatus)reader.GetInt32(reader.GetOrdinal("LoanStatus"));
                decimal loanAmount = reader.GetDecimal(reader.GetOrdinal("LoanAmount"));
                bool isVerified = reader.GetBoolean(reader.GetOrdinal("IsVerified"));


                string verificationCode = reader.IsDBNull(reader.GetOrdinal("VerificationCode"))
                    ? string.Empty
                    : reader.GetString(reader.GetOrdinal("VerificationCode"));

                decimal balance = reader.GetDecimal(reader.GetOrdinal("Balance"));

                User user;
                if (role == UserRole.Admin)
                {
                    user = new AdminUser(id, username, password, email, verificationCode, balance, loanStatus, loanAmount);
                }
                else
                {
                    user = new ClientUser(id, username, password, email, verificationCode, balance, loanStatus, loanAmount);
                }

                user.IsVerfyed = isVerified;
                users.Add(user);
            }
            return users;
        }




        public User? GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }




        public void Add(User user)
        {
            const string query = @"
        INSERT INTO Users
        (
            Username,
            Password,
            Email,
            Role,
            LoanStatus,
            LoanAmount,
            IsVerified,
            VerificationCode,
            Balance
        )
        OUTPUT INSERTED.Id
        VALUES
        (
            @Username,
            @Password,
            @Email,
            @Role,
            @LoanStatus,
            @LoanAmount,
            @IsVerified,
            @VerificationCode,
            @Balance
        );";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Role", (int)user.Role);
            command.Parameters.AddWithValue("@LoanStatus", (int)user.LoanStatus);
            command.Parameters.AddWithValue("@LoanAmount", user.LoanAmount);
            command.Parameters.AddWithValue("@IsVerified", user.IsVerfyed);
            command.Parameters.AddWithValue(
                "@VerificationCode",
                (object?)user.VerificationCode ?? DBNull.Value
            );
            command.Parameters.AddWithValue("@Balance", user.Balance);

            connection.Open();

            user.Id = Convert.ToInt32(command.ExecuteScalar());
        }


        public void SaveAll(ICollection<User> users)
        {
            const string updateQuery = @"
        UPDATE Users 
        SET Username = @Username, 
            Password = @Password, 
            Email = @Email, 
            Role = @Role, 
            LoanStatus = @LoanStatus, 
            LoanAmount = @LoanAmount, 
            IsVerified = @IsVerified, 
            VerificationCode = @VerificationCode, 
            Balance = @Balance 
        WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            foreach (var user in users)
            {
                using var updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Id", user.Id);
                updateCommand.Parameters.AddWithValue("@Username", user.Username);
                updateCommand.Parameters.AddWithValue("@Password", user.Password);
                updateCommand.Parameters.AddWithValue("@Email", user.Email);
                updateCommand.Parameters.AddWithValue("@Role", (int)user.Role);
                updateCommand.Parameters.AddWithValue("@LoanStatus", (int)user.LoanStatus);
                updateCommand.Parameters.AddWithValue("@LoanAmount", user.LoanAmount);
                updateCommand.Parameters.AddWithValue("@IsVerified", user.IsVerfyed);
                updateCommand.Parameters.AddWithValue("@VerificationCode", user.VerificationCode ?? (object)DBNull.Value);
                updateCommand.Parameters.AddWithValue("@Balance", user.Balance);

                updateCommand.ExecuteNonQuery();
            }
        }


        public User? GetByEmail(string email)
        {
            return GetAll().FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        }










    }
}
