using ATM.Core.Enums;
using ATM.Core.Exceptions;
using ATM.Services;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using BCrypt.Net;
using Step.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Services
{
    public class BankService
    {

        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;

        public BankService(IUserRepository userRepository, EmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public BankService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }





        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new UserNotFoundException("Invalid username or password.");
            }

            var user = _userRepository.GetByUsername(username.Trim());

            if (user == null || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new UserNotFoundException("Invalid username or password.");
            }

            bool isPasswordValid;

            try
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(
                    password.Trim(),
                    user.Password.Trim()
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BCrypt Error] {ex.Message}");
                throw new UserNotFoundException("Invalid username or password.");
            }

            if (!isPasswordValid)
            {
                Console.WriteLine($"[Debug] Password mismatch: {username}");
                throw new UserNotFoundException("Invalid username or password.");
            }

            if (!user.IsVerfyed)
            {
                throw new UserNotVerify("User is not verified!");
            }

            SendEmailLoginNotification(user.Email);

            return user;
        }




        public void RegisterClient(ClientUser user)
        {
            var users = _userRepository.GetAll();

            if (users.Any(u =>
                u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new UserAlreadyExistsException("Username is already taken.");
            }

            if (users.Any(u =>
                u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new UserAlreadyExistsException("Email is already registered.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            Random random = new Random();
            user.VerificationCode = random.Next(1000, 10000).ToString();

            user.IsVerfyed = false;

            _userRepository.Add(user);

            EmailService.SendEmail(
                user.Email,
                "Email Verification",
                $"Your verification code is: {user.VerificationCode}"
            );
        }



        public void VerifyUser(string email, string verificationCode)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(verificationCode))
            {
                throw new ArgumentException("Email and verification code cannot be empty.");
            }

            User client = _userRepository.GetByEmail(email);

            if (client == null)
            {
                throw new UserNotFoundException("User not found with provided email.");
            }

            if (client.VerificationCode == null || client.VerificationCode.Trim() != verificationCode.Trim())
            {
                throw new UserNotVerify("Invalid verification code.");
            }

            client.IsVerfyed = true;
            client.VerificationCode = null;

            SaveChanges(client);

            Console.WriteLine("Verify Successful");

            SendEmailRegisterNotification(email);
        }

        public void Deposit(User user, decimal amount)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));

            user.Deposit(amount);
            SaveChanges(user);

            SendEmailNotification(user.Email, amount);
        }

        private void SendEmailNotification(string email, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                EmailService.SendEmail(
                    email,
                    "Deposit Successful",
                    $"Your deposit of {amount:F2} GEL was processed successfully."
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Warning] Failed to send email to {email}: {ex.Message}");
            }
        }

        public bool Withdraw(User user, decimal amount)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));

            bool result = user.Withdraw(amount);
            if (result)
            {
                SaveChanges(user);

                SendEmailLoanNotification(
                    user.Email,
                    "Withdrawal Successful",
                    $"You have successfully withdrawn {amount:F2} GEL. Remaining balance: {user.Balance:F2} GEL"
                );
            }

            return result;
        }

        public void RequestLoan(ClientUser client, decimal amount)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Loan amount must be greater than zero.", nameof(amount));

            if (client.LoanStatus == LoanStatus.Pending)
                throw new LoanException("You already have a pending loan request.");

            if (client.LoanStatus == LoanStatus.Approved)
                throw new LoanException("You already have an active loan.");

            client.LoanStatus = LoanStatus.Pending;
            client.LoanAmount = amount;
            SaveChanges(client);

            SendEmailLoanNotification(
                client.Email,
                "Loan Request Submitted",
                $"Your loan request for {amount:F2} GEL has been received and is under review."
            );
        }

        private void SendEmailLoanNotification(string email, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                EmailService.SendEmail(email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Warning] Email notification failed: {ex.Message}");
            }
        }

        public List<User> GetPendingLoans()
        {
            return _userRepository.GetAll().Where(u => u.LoanStatus == LoanStatus.Pending).ToList();
        }

        public void ProcessLoan(int userId, bool approve)
        {
            var users = _userRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Id == userId && u.LoanStatus == LoanStatus.Pending);

            if (user == null)
                throw new UserNotFoundException("Such ID Not Found!");

            if (approve)
            {
                user.LoanStatus = LoanStatus.Approved;
                user.Deposit(user.LoanAmount);
            }
            else
            {
                user.LoanStatus = LoanStatus.Rejected;
            }

            _userRepository.SaveAll(users);
        }

        public List<User> GetAllUsers() => _userRepository.GetAll().ToList();

        private void SaveChanges(User user)
        {
            var users = _userRepository.GetAll().ToList();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
                _userRepository.SaveAll(users);
            }
        }



        private void SendEmailLoginNotification(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                EmailService.SendEmail(
                    email,
                    "Login Successful",
                    $"You have successfully logged into your account."
                );
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[Warning] Failed to send email to {email}: {ex.Message}");
            }
        }

        private void SendEmailRegisterNotification(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                EmailService.SendEmail(
                    email,
                    "Register Successful",
                    $"You have successfully registered your account."
                );
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[Warning] Failed to send email to {email}: {ex.Message}");
            }
        }









    }
}
