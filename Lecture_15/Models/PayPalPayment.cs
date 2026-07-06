using Lecture_15.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Models
{
    internal class PayPalPayment : PaymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            if(amount < 0)
            {
                throw new PaymentExeption("Payment Filed! ");
            }


            Console.WriteLine($"Processed PayPal payment for {amount}");
        }

        public string Email { get; set; }











    }
}
