namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_TOE
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string TOEName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
