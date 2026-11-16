using System;

namespace FitZone.UI
{
    public class AdminMenu
    {
        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== FITZONE: ADMIN MENU ===");
                Console.WriteLine("1. Manage Workout Sessions (Under Development)");
                Console.WriteLine("2. View Reports & Statistics (Under Development)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("\nSelect an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nFeature coming soon...");
                        break;
                    case "2":
                        Console.WriteLine("\nFeature coming soon...");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}