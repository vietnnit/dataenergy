namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_EnergyQuota
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? MeasurementId { get; set; }

        public decimal? Quantity { get; set; }

        public int? FuelId { get; set; }

        public int? PlanOfYear { get; set; }

        public int? AuditReportId { get; set; }
    }
}
