namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductGroup
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string GroupName { get; set; }

        [StringLength(50)]
        public string GroupCode { get; set; }
        public int? GroupOrder { get; set; }
    }
}
