
using ATM.Core.Enums;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using Microsoft.Data.SqlClient;
using Step.Domain.Models.Entities;
using System.Data;

namespace BankATM.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // =========================================
        // REGISTER CLIENT
        // =========================================

        public void RegisterClient(ClientUser user)
        {
            const string query = @"
                INSERT INTO Users
                    (Username, Password, Email, IsVerified, VerificationCode)
                VALUES
                    (@Username, @Password, @Email, @IsVerified, @VerificationCode);

                DECLARE @ClientId INT = SCOPE_IDENTITY();

                INSERT INTO ClientUsers (UserId)
                VALUES (@ClientId);

                INSERT INTO Accounts (ClientId, Balance)
                VALUES (@ClientId, 0.00);

                SELECT @ClientId;
            ";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand(query, connection, transaction);

                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50)
                    .Value = user.Username;

                command.Parameters.Add("@Password", SqlDbType.NVarChar, 255)
                    .Value = user.Password;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                    .Value = user.Email;

                command.Parameters.Add("@IsVerified", SqlDbType.Bit)
                    .Value = user.IsVerified;

                command.Parameters.Add("@VerificationCode", SqlDbType.NVarChar, 10)
                    .Value = (object?)user.VerificationCode ?? DBNull.Value;

                user.Id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // =========================================
        // ADD ADMIN
        // =========================================

        public void AddAdmin(AdminUser admin)
        {
            const string query = @"
                INSERT INTO Users
                    (Username, Password, Email, IsVerified, VerificationCode)
                VALUES
                    (@Username, @Password, @Email, @IsVerified, @VerificationCode);

                DECLARE @AdminId INT = SCOPE_IDENTITY();

                INSERT INTO AdminUsers (UserId)
                VALUES (@AdminId);

                SELECT @AdminId;
            ";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand(query, connection, transaction);

                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50)
                    .Value = admin.Username;

                command.Parameters.Add("@Password", SqlDbType.NVarChar, 255)
                    .Value = admin.Password;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                    .Value = admin.Email;

                command.Parameters.Add("@IsVerified", SqlDbType.Bit)
                    .Value = admin.IsVerified;

                command.Parameters.Add("@VerificationCode", SqlDbType.NVarChar, 10)
                    .Value = (object?)admin.VerificationCode ?? DBNull.Value;

                admin.Id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // =========================================
        // GET ALL USERS
        // =========================================

        public ICollection<User> GetAll()
        {
            const string query = @"
                SELECT
                    u.Id,
                    u.Username,
                    u.Password,
                    u.Email,
                    u.IsVerified,
                    u.VerificationCode,

                    CASE
                        WHEN a.UserId IS NOT NULL THEN 1
                        WHEN c.UserId IS NOT NULL THEN 0
                    END AS Role

                FROM Users u

                LEFT JOIN ClientUsers c
                    ON u.Id = c.UserId

                LEFT JOIN AdminUsers a
                    ON u.Id = a.UserId;
            ";

            var users = new List<User>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(MapUser(reader));
            }

            return users;
        }

        // =========================================
        // GET BY ID
        // =========================================

        public User? GetById(int id)
        {
            const string query = @"
                SELECT
                    u.Id,
                    u.Username,
                    u.Password,
                    u.Email,
                    u.IsVerified,
                    u.VerificationCode,

                    CASE
                        WHEN a.UserId IS NOT NULL THEN 1
                        WHEN c.UserId IS NOT NULL THEN 0
                    END AS Role

                FROM Users u

                LEFT JOIN ClientUsers c
                    ON u.Id = c.UserId

                LEFT JOIN AdminUsers a
                    ON u.Id = a.UserId

                WHERE u.Id = @Id;
            ";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            connection.Open();

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapUser(reader);
        }

        // =========================================
        // GET BY USERNAME
        // =========================================

        public User? GetByUsername(string username)
        {
            const string query = @"
                SELECT
                    u.Id,
                    u.Username,
                    u.Password,
                    u.Email,
                    u.IsVerified,
                    u.VerificationCode,

                    CASE
                        WHEN a.UserId IS NOT NULL THEN 1
                        WHEN c.UserId IS NOT NULL THEN 0
                    END AS Role

                FROM Users u

                LEFT JOIN ClientUsers c
                    ON u.Id = c.UserId

                LEFT JOIN AdminUsers a
                    ON u.Id = a.UserId

                WHERE u.Username = @Username;
            ";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@Username", SqlDbType.NVarChar, 50)
                .Value = username;

            connection.Open();

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapUser(reader);
        }

        // =========================================
        // GET BY EMAIL
        // =========================================

        public User? GetByEmail(string email)
        {
            const string query = @"
                SELECT
                    u.Id,
                    u.Username,
                    u.Password,
                    u.Email,
                    u.IsVerified,
                    u.VerificationCode,

                    CASE
                        WHEN a.UserId IS NOT NULL THEN 1
                        WHEN c.UserId IS NOT NULL THEN 0
                    END AS Role

                FROM Users u

                LEFT JOIN ClientUsers c
                    ON u.Id = c.UserId

                LEFT JOIN AdminUsers a
                    ON u.Id = a.UserId

                WHERE u.Email = @Email;
            ";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                .Value = email;

            connection.Open();

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapUser(reader);
        }

        // =========================================
        // UPDATE USER
        // =========================================

        public void Update(User user)
        {
            const string query = @"
                UPDATE Users
                SET
                    Username = @Username,
                    Password = @Password,
                    Email = @Email,
                    IsVerified = @IsVerified,
                    VerificationCode = @VerificationCode
                WHERE Id = @Id;
            ";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@Id", SqlDbType.Int)
                .Value = user.Id;

            command.Parameters.Add("@Username", SqlDbType.NVarChar, 50)
                .Value = user.Username;

            command.Parameters.Add("@Password", SqlDbType.NVarChar, 255)
                .Value = user.Password;

            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100)
                .Value = user.Email;

            command.Parameters.Add("@IsVerified", SqlDbType.Bit)
                .Value = user.IsVerified;

            command.Parameters.Add("@VerificationCode", SqlDbType.NVarChar, 10)
                .Value = (object?)user.VerificationCode ?? DBNull.Value;

            connection.Open();

            int rows = command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("User not found.");
        }

        // =========================================
        // MAP USER
        // =========================================

        private static User MapUser(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));

            string username = reader.GetString(reader.GetOrdinal("Username"));

            string password = reader.GetString(reader.GetOrdinal("Password"));

            string email = reader.GetString(reader.GetOrdinal("Email"));

            bool isVerified = reader.GetBoolean(reader.GetOrdinal("IsVerified"));

            string? verificationCode =
                reader.IsDBNull(reader.GetOrdinal("VerificationCode"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("VerificationCode"));

            UserRole role = (UserRole)reader.GetInt32(reader.GetOrdinal("Role"));

            if (role == UserRole.Admin)
            {
                return new AdminUser(
                    id,
                    username,
                    password,
                    email,
                    verificationCode,
                    isVerified
                );
            }

            return new ClientUser(
                id,
                username,
                password,
                email,
                verificationCode,
                isVerified
            );
        }
    }
}
