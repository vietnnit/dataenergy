namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_TOEYear
    {
        public int Id { get; set; }

        public int? TOEId { get; set; }

        public int? Year { get; set; }
    }
}
