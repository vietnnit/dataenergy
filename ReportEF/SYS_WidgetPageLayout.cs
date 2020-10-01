namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_WidgetPageLayout
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RegionID { get; set; }

        public int WidgetID { get; set; }

        [Column(TypeName = "ntext")]
        public string Info { get; set; }

        [Column(TypeName = "ntext")]
        public string HTML { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Value { get; set; }

        public int? Record { get; set; }

        [StringLength(500)]
        public string Value2 { get; set; }

        public int? Record2 { get; set; }

        public bool? Status { get; set; }

        public int? PageLayoutId { get; set; }

        public int? Orders { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
