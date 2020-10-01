namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_SaveSolution
    {
        public int Id { get; set; }

        public int? SolutionId { get; set; }

        [StringLength(4000)]
        public string Purpose { get; set; }

        public int? EnterpriseId { get; set; }

        public int? FuelId { get; set; }

        public int? AuditReportId { get; set; }

        public int? MeasurementFuelId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Cost { get; set; }

        public decimal? Budget { get; set; }

        public decimal? TimeExecuted { get; set; }
    }
}
