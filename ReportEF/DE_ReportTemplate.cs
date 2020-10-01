namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ReportTemplate
    {
        [StringLength(50)]
        public string ReportName { get; set; }

        [StringLength(255)]
        public string PathFile { get; set; }

        public int Id { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public byte? ReportType { get; set; }
    }
}
