using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.DTOs
{
    public class WithdrawDTO
    {
        public int ClientId { get; set; }

        public decimal Amount { get; set; }
    }
}
