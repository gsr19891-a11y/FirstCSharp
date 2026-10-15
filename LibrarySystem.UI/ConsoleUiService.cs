using LibrarySystem.Core.Enums;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.UI
{
    public class ConsoleUiService
    {

        private readonly AuthService _authService;
        private readonly LibraryService _libraryService;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;


        private User _currentUser;


        public ConsoleUiService(AuthService authService, LibraryService libraryService, IBookRepository bookRepository, IBorrowRepository borrowRepository)
        {
            _authService = authService;
            _libraryService = libraryService;
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
        }





        public void Run()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Library System ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }

        }



        private void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = _authService.Login(username, password);
            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                Console.ReadLine();
                return;
            }
            _currentUser = user;

            if (_currentUser.Role == UserRole.Admin)
            {
                ShowAdminMenu();
            }
            else
            {
                ShowClientMenu();
            }

        }







        private void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Role: 1 or 2 ");
            string roleChoice = Console.ReadLine();
            UserRole role = roleChoice == "1" ? UserRole.Admin : UserRole.Client;


            try
            {
                _authService.Register(username, password, role);
                Console.WriteLine("Registration successful. You can now log in.");

            }
            catch (Exception ex) {
                Console.WriteLine($"error: {ex.Message}"); 
            }

            Console.ReadLine();


        }


        private void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Admin Menu ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. View All Borrow Records");
                Console.WriteLine("6. Process Borrow Requests");
                Console.WriteLine("0. Logout");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DeleteBook();
                        break;
                    case "3":
                        ViewAllBooks();
                        break;
                    case "5":
                        ViewAllBorrowRecords();
                        break;
                    case "6":
                        ProcessBorrowRequests();
                        break;
                    case "0":
                        _currentUser = null;
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }








        }



        }
}