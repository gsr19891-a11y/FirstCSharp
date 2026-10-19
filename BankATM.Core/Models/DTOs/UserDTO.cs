using ATM.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankATM.Core.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public bool IsVerified { get; set; }
    }
}
