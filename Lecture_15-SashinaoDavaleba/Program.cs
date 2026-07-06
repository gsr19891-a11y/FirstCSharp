using Lecture_15_SashinaoDavaleba.Models;

namespace Lecture_15_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Book> myLibrary = new List<Book>();

            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");
            Book book3 = new Book("1984", "George Orwell");

            Book best = new Book("The Great Gatsby", "F. Scott Fitzgerald");

            myLibrary.AddRange(book1, book2, book3);
            myLibrary.Add(best);
            myLibrary.Insert(0, new Book("Book1", "George"));

            Console.WriteLine($"Books Count: {myLibrary.Count()}");

            foreach (var item in myLibrary)
            {
                Console.WriteLine(item);

            }

            myLibrary.RemoveAt(2);


            myLibrary.Clear();







        }
    }
}
