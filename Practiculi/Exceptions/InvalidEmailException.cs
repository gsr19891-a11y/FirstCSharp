using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Invalid Email!") { }
       

        public InvalidEmailException(string? message) : base(message)
        {
        }
    }
}
