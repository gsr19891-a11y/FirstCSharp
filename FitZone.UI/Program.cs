using FitZone.Application.Services.Implementations;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Infrastructure.Data;
using FitZone.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FitZone.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DI Container Setup
            var services = new ServiceCollection();

            services.AddLogging();

            services.AddDbContext<FitZoneDbContext>(options =>
                options.UseSqlServer("Server=ADMIN;Database=FitZoneAppDb;Trusted_Connection=True;TrustServerCertificate=True;"));

            // Repositories & Services Registration
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();

            // UI Menus Registration
            services.AddTransient<ClientMenu>();
            services.AddTransient<AdminMenu>();

            // AutoMapper Configuration
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(MemberService).Assembly);
                cfg.AddMaps(typeof(Program).Assembly);
            });

            var serviceProvider = services.BuildServiceProvider();

            // Main Application Loop
            bool programRunning = true;
            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("       WELCOME TO FITZONE        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Client Menu");
                Console.WriteLine("2. Manager (Admin) Menu");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect role: ");

                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        var clientMenu = serviceProvider.GetRequiredService<ClientMenu>();
                        clientMenu.Show();
                        break;

                    case "2":
                        var adminMenu = serviceProvider.GetRequiredService<AdminMenu>();
                        adminMenu.Show();
                        break;

                    case "0":
                        programRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}