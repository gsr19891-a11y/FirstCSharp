using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Books.txt");

        public List<Book> GetAll()
        {
            var books = new List<Book>();

            var lines = File.ReadAllLines(_path);
            foreach (var line in lines)
            {
                var parts = line.Split('|').Select(x => x.Trim()).ToArray();
                string isbn = parts[0];
                string title = parts[1];
                string author = parts[2];
                int quantity = int.Parse(parts[3]);

                books.Add(new Book(isbn, title, author, quantity));
            }
            return books;
        }


        public Book? GetByIsbn(string isbn)
        {
            var books = GetAll();
            return books.FirstOrDefault(b => b.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }


        public void Add(Book book)
        {
            var books = GetAll();
            books.Add(book);
            SaveAll(books);
        }

        public void Update(Book book)
        {
            var books = GetAll();
            var existingBook = books.FirstOrDefault(b => b.Isbn.Equals(book.Isbn, StringComparison.OrdinalIgnoreCase));
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Quantity = book.Quantity;
                SaveAll(books);
            }
        }

        public void Delete(string isbn)
        {
            var books = GetAll();
            books.RemoveAll(b => b.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            SaveAll(books);
        }


        private void SaveAll(List<Book> books)
        {
            var lines = books.Select(b => $"{b.Isbn} | {b.Title} | {b.Author} | {b.Quantity}");
            File.WriteAllLines(_path, lines);
        }














    }
}
