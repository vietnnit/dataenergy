namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ReportFuelDetail
    {
        public int Id { get; set; }

        public int? FuelId { get; set; }

        public decimal? NoFuel { get; set; }

        public decimal? NoFuel_TOE { get; set; }

        public int? ReportId { get; set; }

        public int? EnterpriseId { get; set; }

        public int? Year { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        public bool? IsNextYear { get; set; }

        public int? GroupFuelId { get; set; }

        public int? MeasurementId { get; set; }

        public decimal? No_RateTOE { get; set; }

        public decimal? Price { get; set; }

        public DateTime? Created { get; set; }
    }
}
