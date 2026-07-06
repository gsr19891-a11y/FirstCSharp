using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15.Exeptions
{
    internal class InvalidIbanExeption : Exception
    {

 

        public InvalidIbanExeption() : base("Invalid IBAN!")
        {
        }

        public InvalidIbanExeption(string? message) : base(message)
        {
        }

      
    }
}
