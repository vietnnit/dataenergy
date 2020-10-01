namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPicture")]
    public partial class tblPicture
    {
        [Key]
        public int PictureID { get; set; }

        public int ProductID { get; set; }

        [StringLength(1000)]
        public string PictureThumb { get; set; }

        [StringLength(1000)]
        public string PictureLarge { get; set; }

        public int? Orders { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
