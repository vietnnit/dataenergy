namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFaqsCate")]
    public partial class tblFaqsCate
    {
        [Key]
        public int FaqsCateID { get; set; }

        public int? FaqsCateParentID { get; set; }

        [Required]
        [StringLength(250)]
        public string FaqsCateName { get; set; }

        public int? FaqsCateOrder { get; set; }

        [StringLength(30)]
        public string Icon { get; set; }

        [StringLength(200)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? Created { get; set; }
    }
}
