namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ElectricSupplying
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceName { get; set; }

        public int? PlacingCapacity { get; set; }

        [StringLength(50)]
        public string VoltageLevel { get; set; }

        public decimal? Coefficient { get; set; }

        public bool? IsSelf { get; set; }

        public int? AuditReportId { get; set; }

        public int? Capacity { get; set; }

        public decimal? Performance { get; set; }

        public decimal? RateOfSystem { get; set; }

        public decimal? Cos { get; set; }
    }
}
