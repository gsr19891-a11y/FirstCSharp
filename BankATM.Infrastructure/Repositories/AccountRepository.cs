
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using Microsoft.Data.SqlClient;

namespace BankATM.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public Account? GetByClientId(int clientId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"
                SELECT AccountId, ClientId, Balance
                FROM Accounts
                WHERE ClientId = @ClientId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientId", clientId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Account(
                reader.GetInt32(reader.GetOrdinal("AccountId")),
                reader.GetInt32(reader.GetOrdinal("ClientId")),
                reader.GetDecimal(reader.GetOrdinal("Balance"))
            );
        }

        public void Add(Account account)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"
                INSERT INTO Accounts (ClientId, Balance)
                VALUES (@ClientId, @Balance)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientId", account.ClientId);
            command.Parameters.AddWithValue("@Balance", account.Balance);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Update(Account account)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"
                UPDATE Accounts
                SET Balance = @Balance
                WHERE AccountId = @AccountId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Balance", account.Balance);
            command.Parameters.AddWithValue("@AccountId", account.AccountId);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
                throw new Exception("Account not found.");
        }
    }
}
