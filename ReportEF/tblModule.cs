namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblModule
    {
        [Key]
        [Column(Order = 0)]
        public int Modules_ID { get; set; }

        public int? Modules_Parent { get; set; }

        [StringLength(250)]
        public string Modules_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Modules_Dir { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string Modules_Url { get; set; }

        public int? Modules_Order { get; set; }

        [Column(TypeName = "ntext")]
        public string Modules_Help { get; set; }

        [StringLength(50)]
        public string Modules_Icon { get; set; }

        public bool? Status { get; set; }

        public bool? isMenu { get; set; }

        public bool? isView { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }
    }
}
