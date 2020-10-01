namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Province
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ProvinceName { get; set; }

        public int? RegionId { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        [StringLength(50)]
        public string ProvinceCode { get; set; }
    }
}
