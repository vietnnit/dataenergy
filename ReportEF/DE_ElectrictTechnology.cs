namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ElectrictTechnology
    {
        [Key]
        [StringLength(50)]
        public string TechKey { get; set; }

        [Required]
        [StringLength(255)]
        public string TechName { get; set; }

        [StringLength(1000)]
        public string TechDesc { get; set; }

        public int TechState { get; set; }
    }
}
