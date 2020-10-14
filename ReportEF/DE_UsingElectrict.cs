namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_UsingElectrict
    {
        public int Id { get; set; }

        public int? ReportYear { get; set; }

        public bool? IsPlan { get; set; }

        public int? ReportId { get; set; }

        public int? FuelId { get; set; }

        public decimal? BuyCost { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Capacity { get; set; }

        public decimal? InstalledCapacity { get; set; }

        public decimal? ProduceQty { get; set; }

        public decimal? PriceProduce { get; set; }

        [StringLength(1000)]
        public string Technology { get; set; }

        public decimal? PriceBuy { get; set; }

        public decimal? AvgPrice { get; set; }

        public decimal? CongSuatBan { get; set; }

        public decimal? SanLuongBan { get; set; }
    }
}
