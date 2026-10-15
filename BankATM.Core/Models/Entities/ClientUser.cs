using ATM.Core.Enums;
using BankATM.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step.Domain.Models.Entities
{
    public class ClientUser : User
    {
        public override UserRole Role => UserRole.Client;

        public ClientUser(int id, string username, string password, string email, string code, decimal balance, LoanStatus loanStatus, decimal loanAmount)
            : base(id, username, password, email, code, balance, loanStatus, loanAmount) { }

        public override void DisplayMenu()
        {
            Console.WriteLine("\n=== Client Menu ===");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4.  Request Loan");
            Console.WriteLine("5. Loan Status");
            Console.WriteLine("0. Log Out");
            Console.Write("Select an option: ");
        }
    }
}
