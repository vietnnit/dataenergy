namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCateNewsGroupPermission")]
    public partial class tblCateNewsGroupPermission
    {
        [Key]
        public int CateNewsGroupPermissionID { get; set; }

        public int RolesID { get; set; }

        public int CateNewsGroupID { get; set; }

        [StringLength(500)]
        public string Permission { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
