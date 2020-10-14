namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblNewsTag
    {
        [Key]
        public int NewsTagsID { get; set; }

        public int TagsID { get; set; }

        public int NewsGroupID { get; set; }
    }
}
