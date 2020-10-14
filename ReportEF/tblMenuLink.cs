namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMenuLink
    {
        [Key]
        public int MenuLinksID { get; set; }

        public int? MenuLinksParent { get; set; }

        [StringLength(250)]
        public string MenuLinksName { get; set; }

        [Required]
        [StringLength(250)]
        public string MenuLinksUrl { get; set; }

        public int? MenuLinksOrder { get; set; }

        [Column(TypeName = "ntext")]
        public string MenuLinksHelp { get; set; }

        [StringLength(1000)]
        public string MenuLinksIcon { get; set; }

        public bool? Status { get; set; }

        public bool? isView { get; set; }

        [StringLength(15)]
        public string Target { get; set; }

        public bool? isFlash { get; set; }

        [StringLength(1000)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        public int? width { get; set; }

        public int? height { get; set; }

        public int? hit { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
