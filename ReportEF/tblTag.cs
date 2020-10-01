namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblTag
    {
        [Key]
        [Column(Order = 0)]
        public int TagsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
