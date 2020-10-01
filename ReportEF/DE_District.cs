namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_District
    {
        [StringLength(50)]
        public string DistrictName { get; set; }

        public int Id { get; set; }

        public int? SortOrder { get; set; }

        public int? ProvinceId { get; set; }

        [StringLength(50)]
        public string DistrictCode { get; set; }

        public bool? IsDelete { get; set; }
    }
}
