namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            tblPictures = new HashSet<tblPicture>();
        }

        [Key]
        public int ProductID { get; set; }

        public int CateProductID { get; set; }

        public int? ParentProductID { get; set; }

        public int? BrandID { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Column(TypeName = "ntext")]
        public string ShortDescribe { get; set; }

        [Column(TypeName = "ntext")]
        public string FullDescribe { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(1000)]
        public string ImageThumb { get; set; }

        [StringLength(1000)]
        public string ImageLarge { get; set; }

        public int? Amount { get; set; }

        public bool? Store { get; set; }

        public double? OldPrice { get; set; }

        public double? NewPrice { get; set; }

        public bool? Status { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        public int? Isview { get; set; }

        public bool? Ishot { get; set; }

        [StringLength(50)]
        public string Field1 { get; set; }

        [StringLength(50)]
        public string Field2 { get; set; }

        [StringLength(50)]
        public string Field3 { get; set; }

        [StringLength(50)]
        public string Field4 { get; set; }

        [StringLength(50)]
        public string Field5 { get; set; }

        public bool? ishome { get; set; }

        public DateTime? PostDate { get; set; }

        public bool? IsApproval { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }

        public int? CommentTotal { get; set; }

        public bool? IsComment { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [StringLength(250)]
        public string Keyword { get; set; }

        [StringLength(250)]
        public string Tags { get; set; }

        [StringLength(50)]
        public string ApprovalUserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPicture> tblPictures { get; set; }
    }
}
