namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Compressor
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CompressorName { get; set; }

        public decimal? Pressure { get; set; }

        public decimal? Capacity { get; set; }

        public decimal? PressureLV { get; set; }

        public int? OperationHours { get; set; }

        public int? Quantity { get; set; }

        public int? AuditReportId { get; set; }
    }
}
