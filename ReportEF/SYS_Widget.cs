namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Widget
    {
        public int Id { get; set; }

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

        public bool? WidgetStatus { get; set; }

        public int? WidgetType { get; set; }
    }
}
