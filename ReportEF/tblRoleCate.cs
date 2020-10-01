namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRoleCate")]
    public partial class tblRoleCate
    {
        public int Id { get; set; }

        public int? CateId { get; set; }

        public int? GroupId { get; set; }
    }
}
