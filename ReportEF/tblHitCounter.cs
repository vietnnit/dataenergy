namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHitCounter")]
    public partial class tblHitCounter
    {
        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        public long? HitCounter { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdate { get; set; }
    }
}
