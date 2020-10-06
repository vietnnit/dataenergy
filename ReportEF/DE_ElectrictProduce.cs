namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ElectrictProduce
    {
        [Key]
        public int AutoId { get; set; }

        public int? ReportId { get; set; }

        public int? ReportYear { get; set; }

        public int? ElectrictTechId { get; set; }

        public decimal? InstalledCapacity { get; set; }

        public decimal? ProduceQty { get; set; }

        public int State { get; set; }
    }
}
