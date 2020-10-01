namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_EnterpriseYear
    {
        public int Id { get; set; }

        public int? Year { get; set; }

        public int? EnterpriseId { get; set; }

        public bool? IsDelete { get; set; }

        public decimal? No_TOE { get; set; }

        public bool? IsKey { get; set; }

        public decimal? NoTOE_Plan { get; set; }

        public int? ReportId { get; set; }
    }
}
