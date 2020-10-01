namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsEventRelation")]
    public partial class tblNewsEventRelation
    {
        public int Id { get; set; }

        public int NewsEventID { get; set; }

        public int NewsGroupID { get; set; }
    }
}
