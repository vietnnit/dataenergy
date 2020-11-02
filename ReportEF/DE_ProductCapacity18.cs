namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ProductCapacity18
    {
        [Key]
        public int ProductId18 { get; set; }

        public int? ReportId { get; set; }

        public bool? IsPlan { get; set; }

        public decimal? DienTichPhucVu { get; set; }

        public int? SoTramBom { get; set; }

        public int? SoLuongBom { get; set; }

        public decimal? TongCSSuDungDien { get; set; }

        public decimal? KhoiLuongNuocBomHangNgay { get; set; }
    }
}
