using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Exceptions
{
    internal class InvalidGPAException : Exception
    {
        public InvalidGPAException() : base("Invalid GPA") { }
    

        public InvalidGPAException(string? message) : base(message)
        {
        }
    }
}
