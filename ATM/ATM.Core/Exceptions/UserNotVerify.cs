using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Exceptions
{
    public class UserNotVerify : Exception
    {
        public UserNotVerify()
        {
        }

        public UserNotVerify(string? message) : base(message)
        {
        }
    }
}
