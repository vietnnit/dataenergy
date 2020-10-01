namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_PlanTKNL
    {
        public int Id { get; set; }

        public int? IdGiaPhap { get; set; }

        public int? IdPlan { get; set; }

        [StringLength(1500)]
        public string GiaiDoan { get; set; }

        [StringLength(4000)]
        public string MucTieuGP { get; set; }

        [StringLength(4000)]
        public string MucTietKiemDuKien { get; set; }

        [StringLength(1000)]
        public string ChiPhiDuKien { get; set; }

        [StringLength(250)]
        public string HoanVon { get; set; }

        [StringLength(250)]
        public string MucCamKet { get; set; }

        [StringLength(150)]
        public string KhaNangThucHien { get; set; }

        public int? EnterpriseId { get; set; }

        public int? NamBatDau { get; set; }

        public int? NamKetThuc { get; set; }

        public bool? IsFiveYear { get; set; }

        [StringLength(50)]
        public string TuongDuong { get; set; }

        [StringLength(50)]
        public string ThanhTien { get; set; }

        [StringLength(200)]
        public string LoiIchKhac { get; set; }

        public bool? IsPlan { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public int? LoaiNhienLieu { get; set; }

        [StringLength(50)]
        public string MucTKThucTe { get; set; }

        [StringLength(50)]
        public string MucTKCPThucTe { get; set; }

        [StringLength(50)]
        public string CPThucTe { get; set; }

        [StringLength(50)]
        public string TKCPDuKien { get; set; }

        public bool? IsAdd { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsApplied { get; set; }

        public int? ReportId { get; set; }

        [StringLength(50)]
        public string TuongDuongTT { get; set; }

        [StringLength(200)]
        public string GhiChuTT { get; set; }

        [StringLength(200)]
        public string LoiIchKhacTT { get; set; }

        public int? MeasurementId { get; set; }
    }
}
