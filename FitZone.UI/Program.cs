
using AutoMapper;
using FitZone.Application.Services.Implementations;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Infrastructure.Data;
using FitZone.Infrastructure.Repositories;
using FitZone.UI.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitZone.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();

            services.AddLogging();

            var configuration = new ConfigurationBuilder()

.SetBasePath(AppContext.BaseDirectory)

.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)

.Build();


            services.AddDbContext<FitZoneDbContext>(options =>
                options.UseSqlServer(
                    "Server=ADMIN;Database=FitZoneAppDb;Trusted_Connection=True;TrustServerCertificate=True;"));

            // Repositories
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
            services.AddScoped<IGymHallRepository, GymHallRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();

            // Services
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IWorkoutSessionService, WorkoutSessionService>();
            services.AddScoped<IGymHallService, GymHallService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IBookingService, BookingService>();

            // AutoMapper
            services.AddAutoMapper(cfg => { }, typeof(MemberService).Assembly);

            // Menus
            services.AddTransient<AdminMenu>();
            services.AddTransient<ClientMenu>();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var adminMenu = scope.ServiceProvider
                    .GetRequiredService<AdminMenu>();

                var clientMenu = scope.ServiceProvider
                    .GetRequiredService<ClientMenu>();

                Console.WriteLine("=== FITZONE ===");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Client");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":

                        string secretWord = Console.ReadLine();
                        if (secretWord == configuration["AdminSecretWord"])
                        {
                            adminMenu.Show();
                        }
                        else
                        {
                            Console.WriteLine("Invalid secret word!");
                        }
                        break;

                    case "2":
                        clientMenu.Show();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}
