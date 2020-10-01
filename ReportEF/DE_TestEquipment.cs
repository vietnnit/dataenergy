namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_TestEquipment
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string DeviceName { get; set; }

        [StringLength(50)]
        public string Measurement { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string MadeIn { get; set; }

        public int? AuditReportId { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }
    }
}
