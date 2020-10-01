namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBrand")]
    public partial class tblBrand
    {
        [Key]
        public int BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string ShortDescribe { get; set; }

        [StringLength(100)]
        public string BrandUrl { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
