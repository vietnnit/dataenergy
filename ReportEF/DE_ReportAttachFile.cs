namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ReportAttachFile
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string PathFile { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public int? ReportId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int? UserId { get; set; }

        public int? ReportType { get; set; }
    }
}
