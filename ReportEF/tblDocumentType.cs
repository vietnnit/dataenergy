namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDocumentType")]
    public partial class tblDocumentType
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string TypeName { get; set; }

        public bool? IsDelete { get; set; }

        public int? SortOrder { get; set; }
    }
}
