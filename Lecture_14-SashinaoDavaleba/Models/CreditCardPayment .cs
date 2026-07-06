using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14_SashinaoDavaleba.Models
{
    internal class CreditCardPayment : PaymentMethod
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }


        public override void ProcessPayment()
        {
            Console.WriteLine($"Processed Credit Card payment for {CardNumber} held by {CardHolder}");
        }

    }
}
