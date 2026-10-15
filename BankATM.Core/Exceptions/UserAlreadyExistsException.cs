using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message = "User with this username already exists.")
            : base(message) { }
    }

}
