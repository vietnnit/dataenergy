namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsRegister")]
    public partial class tblNewsRegister
    {
        [Key]
        public int NewsRegisterID { get; set; }

        public int CateNewsID { get; set; }

        public int? ParentNewsID { get; set; }

        public int? GroupCate { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ShortDescribe { get; set; }

        [Column(TypeName = "ntext")]
        public string FullDescribe { get; set; }

        [StringLength(250)]
        public string ImageThumb { get; set; }

        [StringLength(250)]
        public string ImageLarge { get; set; }

        [StringLength(250)]
        public string FileName { get; set; }

        [StringLength(300)]
        public string Author { get; set; }

        public DateTime? PostDate { get; set; }

        public int? RelationTotal { get; set; }

        public bool? Status { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        public bool? Ishot { get; set; }

        public int? Isview { get; set; }

        public bool? Ishome { get; set; }

        public bool? TypeNews { get; set; }

        public bool? IsComment { get; set; }

        public bool? IsApproval { get; set; }

        [StringLength(50)]
        public string ApprovalUserName { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }

        public int? CommentTotal { get; set; }
    }
}
