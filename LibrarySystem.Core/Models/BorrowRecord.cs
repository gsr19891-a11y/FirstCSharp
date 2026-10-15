using LibrarySystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Models
{
    public class BorrowRecord
    {
        public string BorrowId { get; set; }
        public int UserId { get; set; }
        public string Isbn { get; set; }
        public DateTime ReturnDate { get; set; }
        public BorrowStatus Status { get; set; }


        public BorrowRecord(string borrowId, int userId, string isbn, DateTime returnDate, BorrowStatus status)
        {
            BorrowId = borrowId;
            UserId = userId;
            Isbn = isbn;
            ReturnDate = returnDate;
            Status = status;
        }

        


    }
}
