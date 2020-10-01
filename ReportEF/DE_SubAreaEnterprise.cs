namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_SubAreaEnterprise
    {
        public int Id { get; set; }

        public int? EnterpriseId { get; set; }

        public int? SubAreaId { get; set; }
    }
}
