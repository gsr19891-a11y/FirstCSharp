
using ATM.Core.Enums;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using Microsoft.Data.SqlClient;

namespace BankATM.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly string _connectionString;

        public LoanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

     
        public void Add(Loan loan)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            string query = @"
                INSERT INTO Loans (ClientId, LoanStatusId, LoanAmount)
                VALUES (@ClientId, @LoanStatusId, @LoanAmount)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientId", loan.ClientId);
            command.Parameters.AddWithValue("@LoanStatusId", (int)loan.LoanStatus);
            command.Parameters.AddWithValue("@LoanAmount", loan.LoanAmount);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public Loan? GetById(int loanId)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            string query = @"
                SELECT LoanId, ClientId, LoanStatusId,
                       LoanAmount, CreatedAt
                FROM Loans
                WHERE LoanId = @LoanId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LoanId", loanId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapLoan(reader);
        }


        public ICollection<Loan> GetByClientId(int clientId)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            string query = @"
                SELECT LoanId, ClientId, LoanStatusId,
                       LoanAmount, CreatedAt
                FROM Loans
                WHERE ClientId = @ClientId
                ORDER BY CreatedAt DESC";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientId", clientId);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<Loan> loans = new List<Loan>();

            while (reader.Read())
            {
                loans.Add(MapLoan(reader));
            }

            return loans;
        }

        public ICollection<Loan> GetPendingLoans()
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            string query = @"
                SELECT LoanId, ClientId, LoanStatusId,
                       LoanAmount, CreatedAt
                FROM Loans
                WHERE LoanStatusId = @StatusId
                ORDER BY CreatedAt";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@StatusId", (int)LoanStatus.Pending);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<Loan> loans = new List<Loan>();

            while (reader.Read())
            {
                loans.Add(MapLoan(reader));
            }

            return loans;
        }


        public void Update(Loan loan)
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            string query = @"
                UPDATE Loans
                SET LoanStatusId = @LoanStatusId
                WHERE LoanId = @LoanId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LoanStatusId", (int)loan.LoanStatus);

            command.Parameters.AddWithValue("@LoanId", loan.LoanId);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
                throw new Exception("Loan not found.");
        }

       
        private Loan MapLoan(SqlDataReader reader)
        {
            return new Loan(
                reader.GetInt32(reader.GetOrdinal("LoanId")),
                reader.GetInt32(reader.GetOrdinal("ClientId")),
                (LoanStatus)reader.GetInt32(
                    reader.GetOrdinal("LoanStatusId")),
                reader.GetDecimal(reader.GetOrdinal("LoanAmount")),
                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            );
        }
    }
}
