using LibrarySystem.Core.Enums;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services
{
    public class LibraryService
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;
        private readonly IUserRepository _userRepository;


        private const decimal DailyFineRate = 1.50m;


        public LibraryService(IBookRepository bookRepository, IBorrowRepository borrowRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
            _userRepository = userRepository;
        }


        public void RequestBook(int userId, string isbn, int daysToBorrow = 14)
        {
            var book = _bookRepository.GetByIsbn(isbn);
            if (book == null) {
                throw new ArgumentException("Book not found");
            }

            var borrow = _borrowRepository.GetAll();

            int nextId = borrow.Count + 1;

            string borrowId = nextId.ToString();

            var record = new BorrowRecord(
                borrowId,
                userId,
                isbn,
                DateTime.Now.AddDays(daysToBorrow),
                BorrowStatus.Pending
            );
            _borrowRepository.Add(record);
        }



        public void ProcessBorrowRequest(string borrowId, bool approve)
        {
            var record = _borrowRepository.GetById(borrowId);
            if (record == null)
            {
                throw new ArgumentException("Borrow record not found");
         
            }

            if (approve)
            {
                var book = _bookRepository.GetByIsbn(record.Isbn);
                if (book == null || book.Quantity <= 0)
                {
                    record.Status = BorrowStatus.Rejected;
                    _borrowRepository.Update(record);
                    throw new InvalidOperationException("Borrow record not found");
                }

                book.Quantity--;
                _bookRepository.Update(book);
                record.Status = BorrowStatus.Approved;
            }
            else
            {
                record.Status = BorrowStatus.Rejected;
            }

            _borrowRepository.Update(record);


        }















        public decimal ReturnBook(string borrowId)
        {
            var record = _borrowRepository.GetById(borrowId);
            if (record == null)
            {
                throw new ArgumentException("Borrow record not found");
            }

            var book = _bookRepository.GetByIsbn(record.Isbn);
            if(book != null)
            {
                book.Quantity++;
                _bookRepository.Update(book);
            }

            decimal fine = 0;
            if (DateTime.Now > record.ReturnDate)
            {
                int overdueDays = (DateTime.Now - record.ReturnDate).Days;
                fine = overdueDays * DailyFineRate;


                var user = _userRepository.GetById(record.UserId);
                if (user != null)
                {
                    user.Fines += fine;
                    _userRepository.Update(user);
                }
            }

            return fine;
          
        }

















    }
}
