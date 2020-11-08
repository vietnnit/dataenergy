namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Product
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Measurement { get; set; }

        public decimal? Quantity { get; set; }

        public int? YearStart { get; set; }

        public int? YearEnd { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public int? EnterpriseId { get; set; }

        public bool? IsProduct { get; set; }

        public int? ProductOrder { get; set; }
        public int? FuelId { get; set; }
        public int? MeasurementId { get; set; }
        public int? ProductGroup { get; set; }
        public int? GroupFuel { get; set; }
        public decimal? NhietTriThap { get; set; }
    }
}
