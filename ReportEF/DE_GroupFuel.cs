namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_GroupFuel
    {
        [StringLength(50)]
        public string Title { get; set; }

        public int Id { get; set; }

        public int? SortOrder { get; set; }

        [StringLength(10)]
        public string GroupCode { get; set; }

        [StringLength(50)]
        public string MeasurementName { get; set; }
    }
}
