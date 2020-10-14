namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BC_SDNL_HangNam
    {
        [Key]
        public int AutoId { get; set; }

        public int ReportId { get; set; }

        public int IdDN { get; set; }

        public int NamBaoCao { get; set; }

        public int FuelId { get; set; }

        public int MeasurementId { get; set; }

        public decimal MucTieuThu { get; set; }

        public decimal NangLuongQuyDoi { get; set; }

        public DateTime NgayCapNhat { get; set; }

        public int TrangThai { get; set; }
    }
}
