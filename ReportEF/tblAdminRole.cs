namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAdminRole
    {
        [Key]
        public int AdminRolesID { get; set; }

        public int RolesID { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_UserName { get; set; }

        [StringLength(500)]
        public string Permission { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
    }
}
