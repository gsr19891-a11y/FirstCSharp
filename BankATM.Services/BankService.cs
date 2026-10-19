
using ATM.Services;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.DTOs;
using BankATM.Core.Models.Entities;
using BCrypt.Net;
using Step.Domain.Models.Entities;

namespace BankATM.Services
{
    public class BankService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public BankService(
            IUserRepository userRepository,
            IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        // Регистрация клиента
        public UserDTO Register(RegisterUserDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new ArgumentException("All fields are required.");
            }

            if (_userRepository.GetByUsername(dto.Username) != null)
                throw new Exception("Username already exists.");

            if (_userRepository.GetByEmail(dto.Email) != null)
                throw new Exception("Email already exists.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            string verificationCode =
                Random.Shared.Next(1000, 10000).ToString();

            ClientUser client = new ClientUser(
                id: 0,
                username: dto.Username,
                password: hashedPassword,
                email: dto.Email,
                verificationCode: verificationCode,
                isVerified: false
            );

            _userRepository.RegisterClient(client);

            EmailService.SendEmail(
                client.Email,
                "STEP BANK - Email Verification",
                $"Your verification code is: {client.VerificationCode}"
            );

            return new UserDTO
            {
                Id = client.Id,
                Username = client.Username,
                Email = client.Email,
                Role = client.Role,
                IsVerified = client.IsVerified
            };
        }


        public ICollection<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                IsVerified = user.IsVerified
            }).ToList();
        }


        // Авторизация
        public UserDTO Login(LoginUserDTO dto)
        {
            var user = _userRepository.GetByUsername(dto.Username);

            if (user == null)
                throw new Exception("User not found.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("Incorrect password.");

            if (!user.IsVerified)
                throw new Exception("Please verify your email first.");

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                IsVerified = user.IsVerified
            };
        }

        // Подтверждение email
        public void VerifyUser(int userId, string code)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                throw new Exception("User not found.");

            if (user.IsVerified)
                throw new Exception("User is already verified.");

            if (user.VerificationCode != code)
                throw new Exception("Invalid verification code.");

            user.IsVerified = true;
            user.VerificationCode = null;

            _userRepository.Update(user);
        }

        // Получение счёта клиента
        public AccountDTO GetAccount(int clientId)
        {
            var account = _accountRepository.GetByClientId(clientId);

            if (account == null)
                throw new Exception("Account not found.");

            return new AccountDTO
            {
                AccountId = account.AccountId,
                ClientId = account.ClientId,
                Balance = account.Balance
            };
        }

        // Пополнение счёта
        public AccountDTO Deposit(int clientId, decimal amount)
        {
            var account = _accountRepository.GetByClientId(clientId);

            if (account == null)
                throw new Exception("Account not found.");

            account.Deposit(amount);

            _accountRepository.Update(account);

            return new AccountDTO
            {
                AccountId = account.AccountId,
                ClientId = account.ClientId,
                Balance = account.Balance
            };
        }

        // Снятие денег
        public AccountDTO Withdraw(int clientId, decimal amount)
        {
            var account = _accountRepository.GetByClientId(clientId);

            if (account == null)
                throw new Exception("Account not found.");

            bool success = account.Withdraw(amount);

            if (!success)
                throw new Exception("Insufficient balance.");

            _accountRepository.Update(account);

            return new AccountDTO
            {
                AccountId = account.AccountId,
                ClientId = account.ClientId,
                Balance = account.Balance
            };
        }
    }
}
