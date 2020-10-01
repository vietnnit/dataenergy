namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsRelation")]
    public partial class tblNewsRelation
    {
        public int Id { get; set; }

        public int NewsID { get; set; }

        public int NewsGroupID { get; set; }
    }
}
