namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEmail")]
    public partial class tblEmail
    {
        [Key]
        [Column(Order = 0)]
        public int EmailID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
