namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCateNewsGroup")]
    public partial class tblCateNewsGroup
    {
        [Key]
        public int CateNewsGroupID { get; set; }

        public int GroupCate { get; set; }

        [Required]
        [StringLength(50)]
        public string CateNewsGroupName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int? Order { get; set; }

        public bool? IsView { get; set; }

        public bool? IsHome { get; set; }

        public bool? IsMenu { get; set; }

        public bool? IsNew { get; set; }

        [StringLength(1000)]
        public string Icon { get; set; }

        public bool? IsUrl { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        public bool? IsPage { get; set; }

        public int? Position { get; set; }

        public bool? IsRegister { get; set; }

        public int? Menu { get; set; }

        public bool? IsFaq { get; set; }

        public bool? isOfficial { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        public int? PageLayoutID { get; set; }
    }
}
