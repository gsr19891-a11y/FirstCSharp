
using ATM.Core.Enums;
using BankATM.Core.Models.DTOs;
using BankATM.Services;
using System.Globalization;

namespace ATM.UI.Services
{
    public class MenuService
    {
        private readonly BankService _bankService;
        private readonly LoanService _loanService;

        private UserDTO? _currentUser;

        public MenuService(
            BankService bankService,
            LoanService loanService)
        {
            _bankService = bankService;
            _loanService = loanService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=====================================");
                Console.WriteLine("       WELCOME TO STEP BANK");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Register New User");
                Console.WriteLine("0. Exit");
                Console.Write("Select an Action: ");

                switch (Console.ReadLine())
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
                        ShowError("Invalid input.");
                        break;
                }
            }
        }

        // LOGIN
        private void Login()
        {
            Console.Clear();

            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            try
            {
                var loginDTO = new LoginUserDTO
                {
                    Username = username,
                    Password = password
                };

                _currentUser = _bankService.Login(loginDTO);

                Console.WriteLine($"\nWelcome, {_currentUser.Username}!");

                Pause();

                UserSession();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // REGISTRATION
        private void Register()
        {
            Console.Clear();

            Console.WriteLine("=== NEW USER REGISTRATION ===");

            Console.Write("Input Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Input Email: ");
            string email = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Input Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            try
            {
                var registerDTO = new RegisterUserDTO
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                UserDTO registeredUser = _bankService.Register(registerDTO);

                Console.WriteLine("\n[Success] Registration completed!");
                Console.WriteLine($"Verification code sent to: {email}");

                PromptVerification(registeredUser.Id);

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // EMAIL VERIFICATION
        private void PromptVerification(int userId)
        {
            Console.Write("\nEnter verification code from email: ");

            string code = Console.ReadLine()?.Trim() ?? "";

            try
            {
                _bankService.VerifyUser(userId, code);

                Console.WriteLine(
                    "\n[Success] Email verified successfully! Now you can login.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            Pause();
        }

        // USER SESSION
        private void UserSession()
        {
            while (_currentUser != null)
            {
                Console.Clear();

                if (_currentUser.Role == UserRole.Client)
                {
                    ShowClientMenu();
                    string choice = Console.ReadLine() ?? "";

                    HandleClientMenu(choice);
                }
                else if (_currentUser.Role == UserRole.Admin)
                {
                    ShowAdminMenu();
                    string choice = Console.ReadLine() ?? "";

                    HandleAdminMenu(choice);
                }
                else
                {
                    _currentUser = null;
                }
            }
        }

        // CLIENT MENU
        private void ShowClientMenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"   WELCOME {_currentUser!.Username}");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Request Loan");
            Console.WriteLine("5. Check Loan Status");
            Console.WriteLine("0. Log Out");
            Console.Write("\nSelect an Action: ");
        }

        private void HandleClientMenu(string choice)
        {
            int clientId = _currentUser!.Id;

            try
            {
                switch (choice)
                {
                    case "1":
                        {
                            var account = _bankService.GetAccount(clientId);

                            Console.WriteLine(
                                $"Your balance: {account.Balance:F2} GEL");

                            Pause();
                            break;
                        }

                    case "2":
                        {
                            decimal amount = ReadDecimal("Enter deposit amount: ");

                            var account = _bankService.Deposit(clientId, amount);

                            Console.WriteLine(
                                $"Success! New balance: {account.Balance:F2} GEL");

                            Pause();
                            break;
                        }

                    case "3":
                        {
                            decimal amount = ReadDecimal("Enter withdrawal amount: ");

                            var account = _bankService.Withdraw(clientId, amount);

                            Console.WriteLine(
                                $"Success! Remaining balance: {account.Balance:F2} GEL");

                            Pause();
                            break;
                        }

                    case "4":
                        {
                            decimal amount = ReadDecimal("Enter desired loan amount: ");

                            _loanService.RequestLoan(clientId, amount);

                            Console.WriteLine(
                                "Loan request submitted to administrator.");

                            Pause();
                            break;
                        }

                    case "5":
                        {
                            var loans = _loanService.GetClientLoans(clientId);

                            Console.WriteLine("\n=== YOUR LOAN REQUESTS ===");

                            if (loans.Count == 0)
                            {
                                Console.WriteLine("No loan requests found.");
                            }
                            else
                            {
                                foreach (var loan in loans)
                                {
                                    Console.WriteLine(
                                        $"ID: {loan.LoanId} | " +
                                        $"Amount: {loan.LoanAmount:F2} GEL | " +
                                        $"Status: {loan.LoanStatus} | " +
                                        $"Date: {loan.CreatedAt}");
                                }
                            }

                            Pause();
                            break;
                        }

                    case "0":
                        _currentUser = null;
                        break;

                    default:
                        ShowError("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // ADMIN MENU
        private void ShowAdminMenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("          ADMIN PANEL");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. View Pending Loan Applications");
            Console.WriteLine("2. Process Loan Application");
            Console.WriteLine("3. View All Users");
            Console.WriteLine("0. Log Out");
            Console.Write("\nSelect an Action: ");
        }

        private void HandleAdminMenu(string choice)
        {
            try
            {
                switch (choice)
                {
                    case "1":
                        {
                            var pending = _loanService.GetPendingLoans();

                            Console.WriteLine("\n=== PENDING LOAN REQUESTS ===");

                            if (pending.Count == 0)
                            {
                                Console.WriteLine("No pending requests found.");
                            }
                            else
                            {
                                foreach (var loan in pending)
                                {
                                    Console.WriteLine(
                                        $"Loan ID: {loan.LoanId} | " +
                                        $"Client ID: {loan.ClientId} | " +
                                        $"Amount: {loan.LoanAmount:F2} GEL");
                                }
                            }

                            Pause();
                            break;
                        }

                    case "2":
                        {
                            Console.Write("Enter Loan ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int loanId))
                            {
                                ShowError("Invalid ID format.");
                                break;
                            }

                            Console.Write("1 - Approve, 2 - Reject: ");

                            string decision = Console.ReadLine() ?? "";

                            if (decision == "1")
                            {
                                _loanService.ApproveLoan(loanId);

                                Console.WriteLine("Loan approved successfully.");
                            }
                            else if (decision == "2")
                            {
                                _loanService.RejectLoan(loanId);

                                Console.WriteLine("Loan rejected successfully.");
                            }
                            else
                            {
                                ShowError("Invalid decision.");
                                break;
                            }

                            Pause();
                            break;
                        }

                    case "3":
                        {
                            var users = _bankService.GetAllUsers();

                            Console.WriteLine("\n=== ALL USERS ===");

                            foreach (var user in users)
                            {
                                Console.WriteLine(
                                    $"ID: {user.Id} | " +
                                    $"Username: {user.Username} | " +
                                    $"Email: {user.Email} | " +
                                    $"Role: {user.Role}");
                            }

                            Pause();
                            break;
                        }

                    case "0":
                        _currentUser = null;
                        break;

                    default:
                        ShowError("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // INPUT HELPERS
        private decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (decimal.TryParse(
                    Console.ReadLine(),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine(
                    "[Error] Please enter a valid positive number.");
            }
        }

        private void ShowError(string message)
        {
            Console.WriteLine($"\n[Error] {message}");
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
