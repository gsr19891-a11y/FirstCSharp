using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14_SashinaoDavaleba.Models
{
    internal class PayPalPayment : PaymentMethod
    {
        public string Email { get; set; }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processed PayPal payment for {Email}");
        }
    }
}
