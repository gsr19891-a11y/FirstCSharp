using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.DTOs
{
    public class LoanDTO
    {
        public int LoanId { get; set; }

        public int ClientId { get; set; }

        public string Username { get; set; }

        public decimal LoanAmount { get; set; }

        public LoanStatus LoanStatus { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
