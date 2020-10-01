namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_GiaiPhap
    {
        public int Id { get; set; }

        [StringLength(1500)]
        public string TenGiaiPhap { get; set; }

        [StringLength(4000)]
        public string MoTa { get; set; }

        public int? EnterpriseId { get; set; }

        public bool? IsDelete { get; set; }
    }
}
