namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Plan
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string PlanName { get; set; }

        public DateTime? ReportDate { get; set; }

        public int? EnterpriseId { get; set; }

        public int? CreateByUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyByUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? IsDelete { get; set; }

        [Column(TypeName = "ntext")]
        public string Des { get; set; }

        public int? ReportId { get; set; }

        public int? BeginYear { get; set; }

        public int? EndYear { get; set; }
    }
}
