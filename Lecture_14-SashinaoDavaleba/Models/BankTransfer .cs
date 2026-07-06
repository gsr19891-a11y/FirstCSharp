using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14_SashinaoDavaleba.Models
{
    internal class BankTransfer : PaymentMethod
    {
        public string IBAN { get; set; }
        public string BankName { get; set; }


        public override void ProcessPayment()
        {
            Console.WriteLine($"Processed Bank Transfer payment for {IBAN} at {BankName}");
        }


    }
}
