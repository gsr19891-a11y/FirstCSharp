using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Models
{
    internal abstract class PaymentMethod
    {

        public abstract void ProcessPayment(decimal amount);
    }
}
