using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Models
{
    public abstract class User
    {
        private decimal _balance; 

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public decimal LoanAmount { get; set; }
        public abstract UserRole Role { get; }


        public bool IsVerfyed { get; set; }
        public string VerificationCode { get; set; }



        public decimal Balance {
            get => _balance;
            protected set => _balance = value;
        }

        protected User(int id, string username, string password, string email, string verificationCode, decimal balance, LoanStatus loanStatus, decimal loanAmount)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            VerificationCode = verificationCode;
            _balance = balance;
            LoanStatus = loanStatus;
            LoanAmount = loanAmount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("The amount must be greater than 0");
            _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("The amount must be greater than 0");
            if (amount > _balance) return false;

            _balance -= amount;
            return true;
        }

        public abstract void DisplayMenu();


    }
}
