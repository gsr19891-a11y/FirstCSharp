using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Exceptions
{
    public class LoanException : Exception
    {
        public LoanException(string message) : base(message) { }
    }
}
