namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BC_SDNL_DS_TheoNam_Comment
    {
        [Key]
        public int AutoID { get; set; }

        public int ReportID { get; set; }

        [Required]
        [StringLength(255)]
        public string TaiKhoan { get; set; }

        [StringLength(2000)]
        public string NoiDung { get; set; }

        public DateTime? ThoiGian { get; set; }
    }
}
