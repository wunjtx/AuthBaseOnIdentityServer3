namespace IS3.Sample.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookDbContext : DbContext
    {
        public BookDbContext()
            : base("name=Book")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Shelf> Shelf { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
