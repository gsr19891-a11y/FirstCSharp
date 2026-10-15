using ATM.Core.Enums;
using ATM.Core.Models;
using ATM.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ATM.UI.Services
{
    public class MenuService
    {

        private readonly AtmService _atmService;
        private User _currentUser;

        public MenuService(AtmService atmService)
        {
            _atmService = atmService;
        }


        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("    WELCOME TO STEP BANK");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Register New User");
                Console.WriteLine("0. Log Out");
                Console.Write("Select an Action: ");

                switch (Console.ReadLine())
                {
                    case "1": Login(); break;
                    case "2": Register(); break;
                    case "0": return;
                    default: ShowError("Error Input."); break;
                }
            }
        }



        private void Login()
        {
            Console.Clear();
            Console.Write("Username: ");
            string u = Console.ReadLine()?.Trim();
            Console.Write("Password: ");
            string p = Console.ReadLine()?.Trim();

            _currentUser = _atmService.Login(u, p);
            if (_currentUser != null)
            {
                Console.WriteLine($"Welcome, {_currentUser.Username}!");
                Pause();
                UserSession();
            }
            else
            {
                ShowError("Invalid Password or Username!");
            }
        }



        private void Register()
        {
            Console.Clear();
            Console.WriteLine("=== NEW USER REGISTRATION ===");
            Console.Write("Input Username: ");
            string u = Console.ReadLine()?.Trim();

            Console.Write("Input Email: ");
            string e = Console.ReadLine()?.Trim();

            Console.Write("Input Password: ");
            string p = Console.ReadLine()?.Trim();

            var newClient = new ClientUser(
                id: 0,
                username: u,
                password: p,
                email: e,
                code: null, 
                balance: 0.00m,
                loanStatus: LoanStatus.None,
                loanAmount: 0.00m
            );

            try
            {
                _atmService.RegisterClient(newClient);
                Console.WriteLine("\n[Success] Registration completed!");
                Console.WriteLine($"Verification code sent to email: {e}");

                
                PromptVerification(e);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


        private void PromptVerification(string email)
        {
            Console.Write("\nEnter verification code from email: ");
            string code = Console.ReadLine()?.Trim();

            try
            {
                _atmService.VerifyUser(email, code);
                Console.WriteLine("\n[Success] Email verified successfully! Now you can login.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            Pause();
        }

        private void VerifyCodeManual()
        {
            Console.Clear();
            Console.WriteLine("=== MANUAL EMAIL VERIFICATION ===");
            Console.Write("Enter Email: ");
            string email = Console.ReadLine()?.Trim();
            PromptVerification(email);
        }




        private void UserSession()
        {
            while (_currentUser != null)
            {
                Console.Clear();
                _currentUser.DisplayMenu();
                string choice = Console.ReadLine();

                if (_currentUser is ClientUser client)
                    HandleClientMenu(client, choice);
                else if (_currentUser is AdminUser admin)
                    HandleAdminMenu(admin, choice);
            }
        }




        private void HandleClientMenu(ClientUser client, string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Your balance: {client.Balance:F2} GEL");
                    Pause();
                    break;
                case "2":
                    decimal dep = ReadDecimal("Enter deposit amount: ");
                    _atmService.Deposit(client, dep);
                    Console.WriteLine($"New balance: {client.Balance:F2} GEL");
                    Pause();
                    break;
                case "3":
                    decimal with = ReadDecimal("Enter withdrawal amount: ");
                    if (_atmService.Withdraw(client, with))
                        Console.WriteLine($"Success! Remaining balance: {client.Balance:F2} GEL");
                    else
                        ShowError("Insufficient funds.");
                    Pause();
                    break;
                case "4":
                    try
                    {
                        decimal loan = ReadDecimal("Enter desired loan amount: ");
                        _atmService.RequestLoan(client, loan);
                        Console.WriteLine("Loan request submitted to administrator.");
                    }
                    catch (Exception ex) { ShowError(ex.Message); }
                    Pause();
                    break;
                case "5":
                    Console.WriteLine($"Loan status: {client.LoanStatus} ({client.LoanAmount:F2} GEL)");
                    Pause();
                    break;
                case "0":
                    _currentUser = null;
                    break;
                default:
                    ShowError("Invalid option.");
                    break;
            }
        }



        private void HandleAdminMenu(AdminUser admin, string choice)
        {
            switch (choice)
            {
                case "1":
                    var pending = _atmService.GetPendingLoans();
                    Console.WriteLine("\n=== PENDING LOAN REQUESTS ===");
                    if (pending.Count == 0)
                    {
                        Console.WriteLine("No pending requests found.");
                    }
                    else
                    {
                        foreach (var req in pending)
                            Console.WriteLine($"[ID: {req.Id}] {req.Username} — {req.LoanAmount:F2} GEL");
                    }
                    Pause();
                    break;
                case "2":
                    Console.Write("Enter User ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("1 - Approve, 2 - Reject: ");
                        string dec = Console.ReadLine();
                        try
                        {
                            _atmService.ProcessLoan(id, dec == "1");
                            Console.WriteLine("Request status updated.");
                        }
                        catch (Exception ex) { ShowError(ex.Message); }
                    }
                    else
                    {
                        ShowError("Invalid ID format.");
                    }
                    Pause();
                    break;
                case "3":
                    Console.WriteLine("\n=== ALL USERS ===");
                    foreach (var u in _atmService.GetAllUsers())
                        Console.WriteLine($"ID: {u.Id} | Username: {u.Username} | Email: {u.Email} | Role: {u.Role} | Balance: {u.Balance:F2}");
                    Pause();
                    break;
                case "0":
                    _currentUser = null;
                    break;
                default:
                    ShowError("Invalid option.");
                    break;
            }
        }

        private decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val) && val > 0)
                    return val;
                Console.WriteLine("[Error] Please enter a valid positive number.");
            }
        }

        private void ShowError(string msg)
        {
            Console.WriteLine($"\n[Error] {msg}");
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }



    }
}
