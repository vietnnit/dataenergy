namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsCate")]
    public partial class tblNewsCate
    {
        public int Id { get; set; }

        public int CateNewsID { get; set; }

        public int NewsGroupID { get; set; }
    }
}
