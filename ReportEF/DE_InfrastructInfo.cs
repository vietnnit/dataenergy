namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_InfrastructInfo
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Body { get; set; }

        public int? MeasurementId { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }
    }
}
