namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_OperationArea
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        public int? OperationHours { get; set; }

        public int? AuditReportId { get; set; }
    }
}
