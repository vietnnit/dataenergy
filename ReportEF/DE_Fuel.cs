namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Fuel
    {
        public int Id { get; set; }

        public int? MeasurementId { get; set; }

        public int? GroupFuelId { get; set; }

        [StringLength(50)]
        public string FuelName { get; set; }
        public int? FuelOrder { get; set; }
        public int? Denotation { get; set; }
    }
}
