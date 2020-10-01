namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Measurement
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string MeasurementName { get; set; }
    }
}
