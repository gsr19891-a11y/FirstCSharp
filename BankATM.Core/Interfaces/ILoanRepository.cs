using BankATM.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Interfaces
{
    public interface ILoanRepository
    {
        void Add(Loan loan);

        Loan? GetById(int loanId);

        ICollection<Loan> GetByClientId(int clientId);

        ICollection<Loan> GetPendingLoans();

        void Update(Loan loan);
    }
}
