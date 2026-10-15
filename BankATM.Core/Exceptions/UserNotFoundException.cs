using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "User was not found or invalid credentials.")
            : base(message) { }
    }
}
