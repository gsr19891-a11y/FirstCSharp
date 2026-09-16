using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Models
{
    public class AdminUser : User
    {
        public override UserRole Role => UserRole.Admin;

        public AdminUser(int id, string username, string password, decimal balance, LoanStatus loanStatus, decimal loanAmount)
            : base(id, username, password, balance, loanStatus, loanAmount) { }

        public override void DisplayMenu()
        {
            Console.WriteLine("\n=== Admin Menmu ===");
            Console.WriteLine("1. View all loan applications");
            Console.WriteLine("2. Manage applications (Approve / Reject");
            Console.WriteLine("3. View list of all users");
            Console.WriteLine("0. Log out");
            Console.Write("Select an option: ");
        }
    }
}
