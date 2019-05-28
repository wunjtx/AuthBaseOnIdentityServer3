namespace IS3.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public int? ShelfId { get; set; }

        public virtual Shelf Shelf { get; set; }
    }
}
