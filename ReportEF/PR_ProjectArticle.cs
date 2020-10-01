namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_ProjectArticle
    {
        public int Id { get; set; }

        public int? ArticleId { get; set; }

        public int? ProjectId { get; set; }
    }
}
