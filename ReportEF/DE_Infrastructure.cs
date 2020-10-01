namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Infrastructure
    {
        public int Id { get; set; }

        public int? ProduceEmployeeNo { get; set; }

        public int? OfficeEmployeeNo { get; set; }

        public int? ProduceAreaNo { get; set; }

        public int? OfficeAreaNo { get; set; }

        public int? ReportId { get; set; }
    }
}
