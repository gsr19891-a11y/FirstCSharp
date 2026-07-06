using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_15_SashinaoDavaleba.Models
{
    internal class Book
    {
        public Book( string title, string author)
        {
            Title = title; 
            Author = author;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public override string? ToString()
        {
            return $"Title: {Title}, Author: {Author}";
        }
    }
}
