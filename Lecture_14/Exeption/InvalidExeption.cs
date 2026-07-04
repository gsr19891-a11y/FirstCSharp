using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14.Exeption
{
    internal class InvalidExeption : Exception
    {
        public InvalidExeption()
        {
        }

        public InvalidExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
