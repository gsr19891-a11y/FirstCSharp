using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Exeptions
{
    internal class PaymentExeption : Exception
    {
        public PaymentExeption() : base("Error payment")
        {
        }

    

        public PaymentExeption(string? message) : base(message)
        {
        }

     
    }
}
