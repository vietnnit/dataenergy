namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Boiler
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string BoilerName { get; set; }

        public int? FuelId { get; set; }

        public decimal? CapacityInstalled { get; set; }

        public int? OperationHours { get; set; }

        public int? Quantity { get; set; }

        public int? AuditReportId { get; set; }
    }
}
