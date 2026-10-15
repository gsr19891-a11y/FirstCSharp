using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Exceptions
{
    public class InsufficientFundsException : Exception
    {
            public InsufficientFundsException(string message = "Insufficient funds for this transaction.")
                : base(message) { }
        }
    
}
