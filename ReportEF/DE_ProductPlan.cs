namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductPlan
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public decimal? Qty { get; set; }

        public decimal? RateCost { get; set; }

        public decimal? RateRevenue { get; set; }

        public int? ReportId { get; set; }
    }
}
