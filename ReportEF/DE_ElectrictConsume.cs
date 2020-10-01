namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ElectrictConsume
    {
        public int Id { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public long? NormalNo { get; set; }

        public long? NormalCost { get; set; }

        public long? PeakNo { get; set; }

        public long? PeakCost { get; set; }

        public long? LowNo { get; set; }

        public long? LowCost { get; set; }

        public long? ElectrictTotal { get; set; }

        public long? CostTotal { get; set; }

        public int? AuditReportId { get; set; }

        public bool? IsSelf { get; set; }

        public int? FuelId { get; set; }
    }
}
