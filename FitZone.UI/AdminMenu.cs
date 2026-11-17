
using System;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Models.DTOs.TrainersDTOs;

namespace FitZone.UI.Menus
{
    public class AdminMenu
    {
        private readonly ITrainerService _trainerService;
        private readonly IGymHallService _hallService;
        private readonly IWorkoutSessionService _sessionService;

        public AdminMenu(
            ITrainerService trainerService,
            IGymHallService hallService,
            IWorkoutSessionService sessionService)
        {
            _trainerService = trainerService;
            _hallService = hallService;
            _sessionService = sessionService;
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("=== FITZONE ADMIN MENU ===");
                Console.WriteLine("1. Create Workout Session");
                Console.WriteLine("2. View All Trainers");
                Console.WriteLine("3. Create Gym Hall");
                Console.WriteLine("4. Add New Trainer");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateWorkoutSession();
                        break;

                    case "2":
                        ViewAllTrainers();
                        break;

                    case "3":
                        CreateGymHall();
                        break;

                    case "4":
                        CreateTrainer();
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateTrainer()
        {
            try
            {
                Console.Clear();

                Console.Write("Full name: ");
                string fullName = Console.ReadLine();

                Console.Write("Specialization: ");
                string specialization = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                var dto = new CreateTrainerDTO
                {
                    FullName = fullName,
                    Specialization = specialization,
                    Email = email
                };

                _trainerService.CreateTrainerAsync(dto);

                Console.WriteLine("\nTrainer created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        private void ViewAllTrainers()
        {
            try
            {
                Console.Clear();

                var trainers = _trainerService.GetAllTrainersAsync();

                Console.WriteLine("=== ALL TRAINERS ===");

                if (trainers.Count == 0)
                {
                    Console.WriteLine("No trainers found.");
                }

                foreach (var trainer in trainers)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("ID: " + trainer.Id);
                    Console.WriteLine("Name: " + trainer.FullName);
                    Console.WriteLine("Specialization: " + trainer.Specialization);
                    Console.WriteLine("Email: " + trainer.Email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        private void CreateGymHall()
        {
            try
            {
                Console.Clear();

                Console.Write("Hall name: ");
                string name = Console.ReadLine();

                Console.Write("Capacity: ");
                if (!int.TryParse(Console.ReadLine(), out int capacity))
                {
                    Console.WriteLine("Invalid capacity!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Location: ");
                string location = Console.ReadLine();

                _hallService.CreateHall(name, capacity, location);

                Console.WriteLine("\nGym hall created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        private void CreateWorkoutSession()
        {
            try
            {
                Console.Clear();

                Console.Write("Session type: ");
                string type = Console.ReadLine();

                Console.Write("Start date and time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(
                    Console.ReadLine(),
                    out DateTime startDateTime))
                {
                    Console.WriteLine("Invalid date!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Duration in minutes: ");
                if (!int.TryParse(Console.ReadLine(), out int duration))
                {
                    Console.WriteLine("Invalid duration!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Capacity: ");
                if (!int.TryParse(Console.ReadLine(), out int capacity))
                {
                    Console.WriteLine("Invalid capacity!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Trainer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int trainerId))
                {
                    Console.WriteLine("Invalid trainer ID!");
                    Console.ReadKey();
                    return;
                }

                var halls = _hallService.GetAllHalls();

                Console.WriteLine("\n=== AVAILABLE HALLS ===");

                if (halls.Count == 0)
                {
                    Console.WriteLine("No halls found. Create a hall first.");
                    Console.ReadKey();
                    return;
                }

                foreach (var hall in halls)
                {
                    Console.WriteLine(
                        $"ID: {hall.Id} | Name: {hall.Name} | Capacity: {hall.Capacity} | Location: {hall.Location}");
                }

                Console.Write("\nHall ID: ");
                if (!int.TryParse(Console.ReadLine(), out int hallId))
                {
                    Console.WriteLine("Invalid hall ID!");
                    Console.ReadKey();
                    return;
                }

                _sessionService.CreateSession(
                    type,
                    startDateTime,
                    duration,
                    capacity,
                    trainerId,
                    hallId);

                Console.WriteLine("\nWorkout session created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("INNER ERROR: " + ex.InnerException?.Message);
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
