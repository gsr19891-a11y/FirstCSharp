using ATM.Core.Enums;
using ATM.Core.Exceptions;
using ATM.Core.Interfaces;
using ATM.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services
{
    public class AtmService
    {
        private readonly IUserRepository _userRepository;

        public AtmService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public User Login(string username, string password)
        {
            var user = _userRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
            {
                throw new UserNotFoundException("Invalid username or password.");
            }

            return user;
        }



        public ClientUser RegisterClient(string username, string password)
        {
            var users = _userRepository.GetAll();
            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))

                throw new UserAlreadyExistsException("Username is already taken.");


            int newId = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1001;
            var newUser = new ClientUser(newId, username, password, 0.00m, LoanStatus.None, 0.00m);

            _userRepository.Add(newUser);
            return newUser;
        }


        public void Deposit(User user, decimal amount)
        {
            user.Deposit(amount);
            SaveChanges(user);
        }



        public bool Withdraw(User user, decimal amount)
        {
          

            bool result = user.Withdraw(amount);
            if (result) SaveChanges(user);
            return result;
        }



        public void RequestLoan(ClientUser client, decimal amount)
        {
            if (client.LoanStatus == LoanStatus.Pending)
                throw new LoanException("You already have a pending loan request.");

            client.LoanStatus = LoanStatus.Pending;
            client.LoanAmount = amount;
            SaveChanges(client);
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



        public List<User> GetAllUsers() => _userRepository.GetAll();

        private void SaveChanges(User user)
        {
            var users = _userRepository.GetAll();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
                _userRepository.SaveAll(users);
            }
        }

    }
}
