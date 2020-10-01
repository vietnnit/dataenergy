namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_PageLayout
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string PageName { get; set; }

        [StringLength(100)]
        public string SlugPageName { get; set; }

        public int? TemplateId { get; set; }

        public int? Orders { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
