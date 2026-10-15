using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Interfaces
{
    public interface IBorrowRepository
    {
        List<BorrowRecord> GetAll();
        List<BorrowRecord> GetByUserId(int userId);

        BorrowRecord GetById(string borrowId);
        void Add(BorrowRecord record);
        void Update(BorrowRecord record);
    }
}
