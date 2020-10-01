namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOfficialFile")]
    public partial class tblOfficialFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficialFileID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OfficialID { get; set; }

        [StringLength(1000)]
        public string FileName { get; set; }

        [StringLength(300)]
        public string Title { get; set; }
    }
}
