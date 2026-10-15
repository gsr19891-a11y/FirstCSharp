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

            IUserRepository repository = new UserRepository(connectionString);

            var bankService = new BankService(repository);

            var menuService = new MenuService(bankService);

            menuService.Run();




        }
    }
}
