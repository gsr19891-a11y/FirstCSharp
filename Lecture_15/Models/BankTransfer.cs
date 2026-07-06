using Lecture_15.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Models
{
    internal class BankTransfer : PaymentMethod
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processed Bank Transfer payment for {amount}");
        }


        private string _iban;

        public BankTransfer(string iBAN, string bankName)
        {
            IBAN = iBAN;

            BankName = bankName;
        }

        public string IBAN
        {
            get { return _iban; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidIbanExeption("IBAN cannot by empty!");
                }

                _iban = value;
            }
        }



        public string BankName { get; set; }
    }
}
