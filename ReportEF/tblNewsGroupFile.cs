namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsGroupFile")]
    public partial class tblNewsGroupFile
    {
        [Key]
        public int NewsGroupFileID { get; set; }

        public int NewsGroupID { get; set; }

        [StringLength(1000)]
        public string FileName { get; set; }

        [StringLength(300)]
        public string Title { get; set; }
    }
}
