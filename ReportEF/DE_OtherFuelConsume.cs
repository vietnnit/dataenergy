namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_OtherFuelConsume
    {
        public int Id { get; set; }

        public int? FuelId { get; set; }

        public int? MeasurementId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Cost { get; set; }

        public int? AuditReportId { get; set; }

        public int? MonthUsed { get; set; }

        public int? YearUsed { get; set; }
    }
}
