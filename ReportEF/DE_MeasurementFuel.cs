namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_MeasurementFuel
    {
        public int Id { get; set; }

        public int? FuelId { get; set; }

        public decimal? TOE { get; set; }

        public decimal? From_TOE { get; set; }

        public decimal? To_TOE { get; set; }

        public int? MeasurementId { get; set; }

        public int? TOEId { get; set; }

        public decimal? NoCO2 { get; set; }
    }
}
