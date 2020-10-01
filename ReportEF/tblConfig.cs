namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblConfig")]
    public partial class tblConfig
    {
        [Key]
        [StringLength(5)]
        public string language { get; set; }

        [Required]
        [StringLength(200)]
        public string titleweb { get; set; }

        [StringLength(500)]
        public string google { get; set; }

        [Column(TypeName = "ntext")]
        public string introduction { get; set; }

        [Column(TypeName = "ntext")]
        public string infocompany { get; set; }

        [Required]
        [StringLength(3)]
        public string new_icon_w { get; set; }

        [Required]
        [StringLength(3)]
        public string new_icon_h { get; set; }

        [Required]
        [StringLength(3)]
        public string new_thumb_w { get; set; }

        [Required]
        [StringLength(3)]
        public string new_thumb_h { get; set; }

        [Required]
        [StringLength(3)]
        public string new_large_w { get; set; }

        [Required]
        [StringLength(3)]
        public string new_large_h { get; set; }

        [Required]
        [StringLength(3)]
        public string product_icon_w { get; set; }

        [Required]
        [StringLength(3)]
        public string product_icon_h { get; set; }

        [Required]
        [StringLength(3)]
        public string product_thumb_w { get; set; }

        [Required]
        [StringLength(3)]
        public string product_thumb_h { get; set; }

        [Required]
        [StringLength(3)]
        public string product_large_w { get; set; }

        [Required]
        [StringLength(3)]
        public string product_large_h { get; set; }

        [Required]
        [StringLength(3)]
        public string productNo { get; set; }

        [Required]
        [StringLength(3)]
        public string productNoPage { get; set; }

        [Required]
        [StringLength(10)]
        public string currency { get; set; }

        public bool status { get; set; }

        [Column(TypeName = "ntext")]
        public string closecomment { get; set; }

        [Column(TypeName = "ntext")]
        public string support { get; set; }

        [Column(TypeName = "ntext")]
        public string contact { get; set; }

        [Column(TypeName = "ntext")]
        public string intro_desc { get; set; }

        [StringLength(50)]
        public string email_from { get; set; }

        [StringLength(50)]
        public string email_to { get; set; }

        [Column(TypeName = "ntext")]
        public string counter { get; set; }

        [Column(TypeName = "ntext")]
        public string info1 { get; set; }

        [Column(TypeName = "ntext")]
        public string info2 { get; set; }

        [StringLength(100)]
        public string WebName { get; set; }

        [StringLength(100)]
        public string WebServerIP { get; set; }

        [StringLength(100)]
        public string WebMailServer { get; set; }

        [StringLength(200)]
        public string WebDomain { get; set; }

        public bool? IsPopup { get; set; }

        [Column(TypeName = "ntext")]
        public string Popup { get; set; }

        [Column(TypeName = "ntext")]
        public string Popup2 { get; set; }
    }
}
