namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMailContent")]
    public partial class tblMailContent
    {
        [Key]
        public int MailContentID { get; set; }

        [Required]
        [StringLength(100)]
        public string MailContentName { get; set; }

        [Column(TypeName = "ntext")]
        public string MailContentDesc { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }
    }
}
