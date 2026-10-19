using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        public int ClientId { get; set; }

        public decimal Balance { get; private set; }

        public Account(int accountId, int clientId, decimal balance)
        {
            AccountId = accountId;
            ClientId = clientId;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (amount > Balance)
                return false;

            Balance -= amount;
            return true;
        }
    }
}
