using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Models
{
    internal class CreditCardPayment : PaymentMethod
    {

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processed Credit Cart payment for {amount}");
        }


        private string _cardNumber;

        public string CardNumber { get { return _cardNumber; } set
            {

                char[] arr = value.ToCharArray();

                foreach (var item in arr)
                {
                    if (!char.IsDigit(item) || value != " ")
                    {
                        throw new ArgumentException();
                    }

                    
                }

               

            } }
        public string CardHolder { get; set; }


    }
}
