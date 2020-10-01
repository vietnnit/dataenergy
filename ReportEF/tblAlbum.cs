namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAlbum
    {
        [Key]
        public int AlbumsID { get; set; }

        public int AlbumsCateID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(1000)]
        public string ImageThumb { get; set; }

        [StringLength(1000)]
        public string ImageLarge { get; set; }

        [StringLength(30)]
        public string Author { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PostDate { get; set; }

        public bool? Status { get; set; }

        public bool? Ishot { get; set; }

        public int? Isview { get; set; }

        public bool? Ishome { get; set; }

        public bool? IsComment { get; set; }

        public bool? IsApproval { get; set; }

        [StringLength(50)]
        public string ApprovalUserName { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }

        public int? CommentTotal { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
