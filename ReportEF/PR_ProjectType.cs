namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_ProjectType
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string TypeName { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }

        public int? SortOrder { get; set; }
    }
}
