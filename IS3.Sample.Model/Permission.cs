namespace IS3.Sample.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [Key]
        [Column(Order = 0)]
        public int pId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string RoleName { get; set; }

        [StringLength(150)]
        public string ResourceName { get; set; }

        [StringLength(150)]
        public string ActionName { get; set; }
    }
}
