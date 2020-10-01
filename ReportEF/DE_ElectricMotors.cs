namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ElectricMotors
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ElectricMotorsName { get; set; }

        public decimal? Capacity { get; set; }

        public decimal? CapacityUsed { get; set; }

        public int? OperationHours { get; set; }

        public int? Quantity { get; set; }

        public int? AuditReportId { get; set; }
    }
}
