namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductCapacity
    {
        public int? ProductId { get; set; }

        public decimal? MaxQuantity { get; set; }

        public decimal? DesignQuantity { get; set; }

        public int? ReportId { get; set; }

        public decimal? RateOfCost { get; set; }

        public decimal? RateOfRevenue { get; set; }

        public bool? IsPlan { get; set; }

        public int? ReportYear { get; set; }

        public int Id { get; set; }
    }
}
