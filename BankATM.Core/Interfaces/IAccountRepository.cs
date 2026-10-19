using BankATM.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Interfaces
{
    public interface IAccountRepository
    {
        Account? GetByClientId(int clientId);

        void Add(Account account);

        void Update(Account account);
    }
}
