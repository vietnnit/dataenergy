namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCateNewsPermission")]
    public partial class tblCateNewsPermission
    {
        [Key]
        [Column(Order = 0)]
        public int CateNewsPermissionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RolesID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CateNewsID { get; set; }

        [StringLength(500)]
        public string Permission { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(5)]
        public string Language { get; set; }
    }
}
