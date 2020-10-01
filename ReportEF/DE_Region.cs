namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Region
    {
        [StringLength(50)]
        public string RegionName { get; set; }

        public int Id { get; set; }

        public int? SortOrder { get; set; }
    }
}
