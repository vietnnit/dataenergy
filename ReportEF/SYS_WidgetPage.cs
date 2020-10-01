namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_WidgetPage
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string RegionId { get; set; }

        [StringLength(250)]
        public string WidgetName { get; set; }

        [Required]
        [StringLength(250)]
        public string WidgetControl { get; set; }

        [Required]
        [StringLength(250)]
        public string WidgetDir { get; set; }

        [Column(TypeName = "ntext")]
        public string WidgetInfo { get; set; }

        [Column(TypeName = "ntext")]
        public string WidgetHTML { get; set; }

        [StringLength(50)]
        public string WidgetIcon { get; set; }

        [StringLength(250)]
        public string WidgetTitle { get; set; }

        [StringLength(500)]
        public string WidgetValue { get; set; }

        public int? WidgetRecord { get; set; }

        [StringLength(500)]
        public string WidgetValue2 { get; set; }

        public int? WidgetRecord2 { get; set; }

        public bool? WidgetStatus { get; set; }

        public int? PageLayoutId { get; set; }

        public int? WidgetOrder { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
