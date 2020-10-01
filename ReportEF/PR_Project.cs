namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_Project
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ProjectName { get; set; }

        public int? AreaId { get; set; }

        public int? ProjectTypeId { get; set; }

        [StringLength(300)]
        public string Place { get; set; }

        [StringLength(255)]
        public string P { get; set; }

        [StringLength(255)]
        public string Q { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Column(TypeName = "ntext")]
        public string FullDescription { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(255)]
        public string GoogleMaps { get; set; }

        [StringLength(255)]
        public string ImageThumb { get; set; }

        [StringLength(255)]
        public string ImageLarge { get; set; }

        public bool? IsNew { get; set; }

        [StringLength(255)]
        public string Technology { get; set; }

        [StringLength(255)]
        public string Investor { get; set; }
    }
}
