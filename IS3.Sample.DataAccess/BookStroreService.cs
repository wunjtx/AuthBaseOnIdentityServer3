using IS3.Sample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IS3.Sample.DataAccess
{
    public class BookStroreService: IBookStroreService
    {
        private BookDbContext db;
        public BookStroreService()
        { 
            var context = CallContext.GetData("BookDbContext") as BookDbContext;
            if (context == null)
            {
                context = new BookDbContext();
                CallContext.SetData("BookDbContext",context);
            }
            db= context;
            
        }
        public Book Create(Book book)
        {
            db.Entry<Book>(book).State = EntityState.Added;
            if (db.SaveChanges()>0)
            {
                return book;
            }
            return default(Book);
            
        }
        public List<Book> GetAllBooks()
        {
            return db.Book.Where(b => true).ToList();
        }
        public Book Modify(Book book)
        {
            db.Entry<Book>(book).State = EntityState.Modified;
            if (db.SaveChanges()>0)
            {
                return book;
            }
            return default(Book);
        }
        public void AddBooksToShelf(IEnumerable<Book> books)
        {
            db.BulkInsert(books);
            db.BulkSaveChanges();
        }


        public void Dispose()
         {
            Dispose(true);
            GC.SuppressFinalize(this);
         }
 
         protected virtual void Dispose(bool disposing)
         {
            if (!m_disposed)
            {
                if (disposing)
                {
                   // Release managed resources
                }
  
                // Release unmanaged resources
  
                m_disposed = true;
            }
         }
  
         ~BookStroreService()
         {
            Dispose(false);
         }
  
         private bool m_disposed;
        }
}
