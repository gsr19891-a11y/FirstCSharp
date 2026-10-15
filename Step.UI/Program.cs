using Microsoft.Extensions.Configuration;
using Step.Application.Implementations;
using Step.Domain.Interfaces;
using Step.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

namespace Step.UI
{
    internal class Program

    {
        //private static readonly string _connectionString = "Data Source=ADMIN;Initial Catalog=StepDB;Database=StepDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";

        private static readonly string _connectionString = "Server=ADMIN;Database=StepDB;Trusted_Connection=True;TrustServerCertificate=True;";
        static void Main(string[] args)
        {


            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnection");



            IStudentRepository repository = new StudentRepository(_connectionString);
            var StudentService = new StudentService(repository);



            StudentService.DisplayAllStudents();


            Console.WriteLine("/////////////////////////////////////////////// ");
            Console.WriteLine("Enter student ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(StudentService.GetStudentById(id));









        }

    }
}