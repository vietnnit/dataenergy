namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pr_ProType
    {
        public int Id { get; set; }

        public int? ProjectId { get; set; }

        public int? TypeId { get; set; }
    }
}
