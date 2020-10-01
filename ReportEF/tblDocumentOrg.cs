namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDocumentOrg")]
    public partial class tblDocumentOrg
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string OrgName { get; set; }

        public bool? IsDelete { get; set; }

        public int? SortOrder { get; set; }
    }
}
