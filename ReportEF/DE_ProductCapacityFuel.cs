namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductCapacityFuel
    {
        [Key]
        public int AutoId { get; set; }

        public int ProductCapacityId { get; set; }


        public int? FuelId { get; set; }

        public int? MeasurementId { get; set; }

        public decimal? ConsumeQty { get; set; }
    }
}
