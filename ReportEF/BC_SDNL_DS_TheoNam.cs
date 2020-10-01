namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BC_SDNL_DS_TheoNam
    {
        [Key]
        public int AutoID { get; set; }

        public int IdDN { get; set; }

        public int NamBaoCao { get; set; }

        public int TrangThai { get; set; }

        public DateTime? NgayLapBC { get; set; }

        public DateTime? NgayGuiBC { get; set; }

        public DateTime? NgayDuyetBC { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(1000)]
        public string MoTaBaoCao { get; set; }

        [StringLength(1000)]
        public string NoiDungPheDuyetSCT { get; set; }

        [StringLength(1000)]
        public string FilePath { get; set; }
    }
}
