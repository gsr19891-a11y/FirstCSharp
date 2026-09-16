using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Models
{
    public class ClientUser : User
    {

        public override UserRole Role => UserRole.Client;

        public ClientUser(int id, string username, string password, decimal balance, LoanStatus loanStatus, decimal loanAmount)
            : base(id, username, password, balance, loanStatus, loanAmount) { }

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
