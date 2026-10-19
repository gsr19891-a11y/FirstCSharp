using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }

        public int ClientId { get; set; }

        public LoanStatus LoanStatus { get; set; }

        public decimal LoanAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public Loan(
            int loanId,
            int clientId,
            LoanStatus loanStatus,
            decimal loanAmount,
            DateTime createdAt)
        {
            LoanId = loanId;
            ClientId = clientId;
            LoanStatus = loanStatus;
            LoanAmount = loanAmount;
            CreatedAt = createdAt;
        }
    }
}
