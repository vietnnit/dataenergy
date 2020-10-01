namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_PlanTB
    {
        public int Id { get; set; }

        public int? IdPlan { get; set; }

        public int? EnterpriseId { get; set; }

        [StringLength(500)]
        public string NameTB { get; set; }

        [StringLength(4000)]
        public string TinhNang { get; set; }

        [StringLength(4000)]
        public string CachLapDat { get; set; }

        [StringLength(4000)]
        public string LyDo { get; set; }

        [StringLength(50)]
        public string KhaNang { get; set; }

        [StringLength(50)]
        public string CamKet { get; set; }

        public bool? IsFiveYear { get; set; }

        public bool? IsPlan { get; set; }

        [StringLength(200)]
        public string LyDoLapDat { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsExecuted { get; set; }

        public int? ReportId { get; set; }

        public bool? IsNew { get; set; }

        public int? Nam { get; set; }
    }
}
