using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace IS3.Sample.Model
{
    public class InMemoryBook
    {
        private static ConcurrentBag<Book> books = new ConcurrentBag<Book>();

        static InMemoryBook()
        {
            books.Add(new Book { BookId = 1, Name = "c", Price = 11.00 });
            books.Add(new Book { BookId = 2, Name = "c+", Price = 12.00 });
            books.Add(new Book { BookId = 3, Name = "c++", Price = 13.00 });
            books.Add(new Book { BookId = 4, Name = "c+++", Price = 14.00 });
            books.Add(new Book { BookId = 5, Name = "c#", Price = 15.00 });
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return InMemoryBook.books;
        }
        public void CreateBook(Book book)
        {
            books.Add(book);
        }
    }
}
