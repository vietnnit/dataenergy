namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAlbumsCate")]
    public partial class tblAlbumsCate
    {
        [Key]
        public int AlbumsCateID { get; set; }

        public int? ParentCateID { get; set; }

        [Required]
        [StringLength(200)]
        public string AlbumsCateName { get; set; }

        public int? AlbumsCateTotal { get; set; }

        public int? AlbumsCateOrder { get; set; }

        [StringLength(1000)]
        public string ImageThumb { get; set; }

        [StringLength(1000)]
        public string ImageLarge { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
