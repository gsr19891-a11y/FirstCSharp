using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetByIsbn(string isbn);
        void Add(Book book);
        void Update(Book book);
        void Delete(string isbn);
    }
}
