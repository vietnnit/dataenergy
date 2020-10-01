namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_TemplatePage
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TemplateName { get; set; }

        [StringLength(50)]
        public string TemplateControl { get; set; }

        [StringLength(500)]
        public string Info { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        [StringLength(50)]
        public string MasterControl { get; set; }
    }
}
