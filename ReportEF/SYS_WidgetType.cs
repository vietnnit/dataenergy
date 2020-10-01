namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_WidgetType
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string WidgetTypeName { get; set; }

        [Required]
        [StringLength(250)]
        public string WidgetControl { get; set; }

        [Required]
        [StringLength(250)]
        public string WidgetDir { get; set; }

        [Column(TypeName = "ntext")]
        public string WidgetInfo { get; set; }

        public bool? WidgetStatus { get; set; }

        public int? Orders { get; set; }
    }
}
