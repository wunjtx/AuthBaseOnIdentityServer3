using IS3.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.DataAccess
{
    public interface IBookStroreService: IDisposable
    {
         Book Create(Book book);
         List<Book> GetAllBooks();
         Book Modify(Book book);
        void AddBooksToShelf(IEnumerable<Book> books);
    }
}
