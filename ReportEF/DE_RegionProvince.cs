namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_RegionProvince
    {
        public int? ProvinceId { get; set; }

        public int Id { get; set; }

        public int? RegionId { get; set; }
    }
}
