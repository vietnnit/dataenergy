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
        public int TagsID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
