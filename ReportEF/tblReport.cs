namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblReport")]
    public partial class tblReport
    {
        public int Id { get; set; }

        [StringLength(1500)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Des { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        public int? EnterpriseId { get; set; }

        public bool? IsApproval { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? Createdate { get; set; }

        public int? CreateByUser { get; set; }

        public int? ModifileByUser { get; set; }

        public DateTime? ModifileDate { get; set; }

        public DateTime? ReportDate { get; set; }

        public int? OrganizationId { get; set; }
    }
}
