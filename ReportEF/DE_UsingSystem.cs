namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_UsingSystem
    {
        [Key]
        public int SysId { get; set; }

        [Required]
        [StringLength(50)]
        public string SysGroup { get; set; }

        [Required]
        [StringLength(255)]
        public string SysName { get; set; }

        [Required]
        [StringLength(50)]
        public string SysCode { get; set; }

        public int SysState { get; set; }

        [StringLength(1000)]
        public string SysDesc { get; set; }
    }
}
