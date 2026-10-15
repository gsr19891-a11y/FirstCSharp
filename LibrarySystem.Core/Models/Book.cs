using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core.Models
{
    public class Book
    {

        public string Isbn { get; set; } 
        public string Title { get; set; } 
        public string Author { get; set; }
        public int Quantity { get; set; }

        public Book(string isbn, string title, string author, int quantity)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Quantity = quantity;
        }


    }

}

