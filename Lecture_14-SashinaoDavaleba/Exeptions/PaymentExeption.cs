using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14_SashinaoDavaleba.Exeption
{
    internal class PaymentExeption : Exception
    {
        public PaymentExeption()
        {
        }

        public PaymentExeption(string? message) : base("error payment!")
        {
        }
    }
}
