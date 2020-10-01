namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Area
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string AreaName { get; set; }

        public int? ParentId { get; set; }

        public int? IsStatus { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsDelete { get; set; }
    }
}
