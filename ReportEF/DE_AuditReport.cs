namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_AuditReport
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string AuditConsultancyName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? ShiftNo { get; set; }

        [StringLength(50)]
        public string AuditingScope { get; set; }

        [StringLength(50)]
        public string AuditorName { get; set; }

        public int? AuditReportId { get; set; }

        public int? AuditYear { get; set; }

        public int? DataYear { get; set; }

        public int? EnterpriseId { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Sent { get; set; }

        public DateTime? Confirmed { get; set; }

        public int? Status { get; set; }

        [StringLength(200)]
        public string PathFile { get; set; }

        [StringLength(50)]
        public string TaxNo { get; set; }

        [StringLength(50)]
        public string AuditorCode { get; set; }
    }
}
