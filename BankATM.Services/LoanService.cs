using ATM.Core.Enums;
using BankATM.Core.Interfaces;
using BankATM.Core.Models.Entities;
using BankATM.Core.Models.DTOs;

namespace BankATM.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IAccountRepository _accountRepository;

        public LoanService(
            ILoanRepository loanRepository,
            IAccountRepository accountRepository)
        {
            _loanRepository = loanRepository;
            _accountRepository = accountRepository;
        }

        // Создание заявки на кредит
        public void RequestLoan(int clientId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Loan amount must be greater than zero.");

            Loan loan = new Loan(
                loanId: 0,
                clientId: clientId,
                loanStatus: LoanStatus.Pending,
                loanAmount: amount,
                createdAt: DateTime.Now
            );

            _loanRepository.Add(loan);
        }

        // Получение заявок клиента
        public ICollection<LoanDTO> GetClientLoans(int clientId)
        {
            var loans = _loanRepository.GetByClientId(clientId);

            return loans.Select(loan => new LoanDTO
            {
                LoanId = loan.LoanId,
                ClientId = loan.ClientId,
                LoanAmount = loan.LoanAmount,
                LoanStatus = loan.LoanStatus,
                CreatedAt = loan.CreatedAt
            }).ToList();
        }

        // Получение всех ожидающих заявок
        public ICollection<LoanDTO> GetPendingLoans()
        {
            var loans = _loanRepository.GetPendingLoans();

            return loans.Select(loan => new LoanDTO
            {
                LoanId = loan.LoanId,
                ClientId = loan.ClientId,
                LoanAmount = loan.LoanAmount,
                LoanStatus = loan.LoanStatus,
                CreatedAt = loan.CreatedAt
            }).ToList();
        }

        // Одобрение заявки
        public void ApproveLoan(int loanId)
        {
            var loan = _loanRepository.GetById(loanId);

            if (loan == null)
                throw new Exception("Loan not found.");

            if (loan.LoanStatus != LoanStatus.Pending)
                throw new Exception("This loan has already been processed.");

            var account = _accountRepository.GetByClientId(loan.ClientId);

            if (account == null)
                throw new Exception("Client account not found.");

            loan.LoanStatus = LoanStatus.Approved;

            account.Deposit(loan.LoanAmount);

            _loanRepository.Update(loan);
            _accountRepository.Update(account);
        }

        // Отклонение заявки
        public void RejectLoan(int loanId)
        {
            var loan = _loanRepository.GetById(loanId);

            if (loan == null)
                throw new Exception("Loan not found.");

            if (loan.LoanStatus != LoanStatus.Pending)
                throw new Exception("This loan has already been processed.");

            loan.LoanStatus = LoanStatus.Rejected;

            _loanRepository.Update(loan);
        }
    }
}