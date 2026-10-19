using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public int ClientId { get; set; }

        public decimal Balance { get; set; }
    }
}
