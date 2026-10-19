using ATM.UI.Services;
using BankATM.Core.Interfaces;
using BankATM.Infrastructure.Repositories;
using BankATM.Services;
using Microsoft.Extensions.Configuration;

namespace BankATM.UI
{
    internal class Program
    {

        private static readonly string _connectionString = "Server=ADMIN;Database=AtmDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {


            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            var userRepository = new UserRepository(connectionString);
            var accountRepository = new AccountRepository(connectionString);
            var loanRepository = new LoanRepository(connectionString);

            var bankService = new BankService(
                userRepository,
                accountRepository
            );

            var loanService = new LoanService(
                loanRepository,
                accountRepository
            );

            var menuService = new MenuService(
                bankService,
                loanService
            );

            menuService.Run();




        }
    }
}
