namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductMeasurement
    {
        public int Id { get; set; }

        public int? MeasuamentId { get; set; }

        public int? ProductId { get; set; }
    }
}
