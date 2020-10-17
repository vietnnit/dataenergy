using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class PlanTKNLBO : BaseEntity
    {

        #region Constructor
        public PlanTKNLBO()
        { }


        public PlanTKNLBO(PlanTKNL plantknlDTO)
        {
            this.Id = plantknlDTO.Id;
            this.IdGiaPhap = plantknlDTO.IdGiaPhap;
            this.IdPlan = plantknlDTO.IdPlan;
            this.GiaiDoan = plantknlDTO.GiaiDoan;
            this.MucTieuGP = plantknlDTO.MucTieuGP;
            this.MucTietKiemDuKien = plantknlDTO.MucTietKiemDuKien;
            this.ChiPhiDuKien = plantknlDTO.ChiPhiDuKien;
            this.HoanVon = plantknlDTO.HoanVon;
            this.MucCamKet = plantknlDTO.MucCamKet;
            this.KhaNangThucHien = plantknlDTO.KhaNangThucHien;
            this.EnterpriseId = plantknlDTO.EnterpriseId;
            this.NamBatDau = plantknlDTO.NamBatDau;
            this.NamKetThuc = plantknlDTO.NamKetThuc;
            this.IsFiveYear = plantknlDTO.IsFiveYear;
            this.TuongDuong = plantknlDTO.TuongDuong;
            this.ThanhTien = plantknlDTO.ThanhTien;
            this.LoiIchKhac = plantknlDTO.LoiIchKhac;
            this.IsPlan = plantknlDTO.IsPlan;
            this.GhiChu = plantknlDTO.GhiChu;
            this.LoaiNhienLieu = plantknlDTO.LoaiNhienLieu;
            this.MucTKThucTe = plantknlDTO.MucTKThucTe;
            this.MucTKCPThucTe = plantknlDTO.MucTKCPThucTe;
            this.CPThucTe = plantknlDTO.CPThucTe;
            this.TKCPDuKien = plantknlDTO.TKCPDuKien;
            this.IsAdd = plantknlDTO.IsAdd;
            this.IsApproved = plantknlDTO.IsApproved;
            this.IsApplied = plantknlDTO.IsApplied;
            this.ReportId = plantknlDTO.ReportId;
            this.TuongDuongTT = plantknlDTO.TuongDuongTT;
            this.GhiChuTT = plantknlDTO.GhiChuTT;
            this.LoiIchKhacTT = plantknlDTO.LoiIchKhacTT;
            this.MeasurementId = plantknlDTO.MeasurementId;
            this.HeThongSuDung = plantknlDTO.HeThongSuDung;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private int _IdGiaPhap;
        private int _IdPlan;
        private string _GiaiDoan;
        private string _MucTieuGP;
        private string _MucTietKiemDuKien;
        private string _ChiPhiDuKien;
        private string _HoanVon;
        private string _MucCamKet;
        private string _KhaNangThucHien;
        private int _EnterpriseId;
        private int _NamBatDau;
        private int _NamKetThuc;
        private bool _IsFiveYear;
        private string _TuongDuong;
        private string _ThanhTien;
        private string _LoiIchKhac;
        private bool _IsPlan;
        private string _GhiChu;
        private int _LoaiNhienLieu;
        private string _MucTKThucTe;
        private string _MucTKCPThucTe;
        private string _CPThucTe;
        private string _TKCPDuKien;
        private bool _IsAdd;
        private bool _IsApproved;
        private bool _IsApplied;
        private int _ReportId;
        private string _TuongDuongTT;
        private string _GhiChuTT;
        private string _LoiIchKhacTT;
        private int _MeasurementId;
        private string _HeThongSuDung;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_PlanTKNL"; }
            set { base.TableName = "DE_PlanTKNL"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("IdGiaPhap", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int IdGiaPhap
        {
            get { return _IdGiaPhap; }
            set { _IdGiaPhap = value; SetDirty("IdGiaPhap"); }
        }
        [FieldName("IdPlan", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; SetDirty("IdPlan"); }
        }
        [FieldName("GiaiDoan", FieldAccessMode.ReadWrite, FieldType.String)]
        public string GiaiDoan
        {
            get { return _GiaiDoan; }
            set { _GiaiDoan = value; SetDirty("GiaiDoan"); }
        }
        [FieldName("MucTieuGP", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MucTieuGP
        {
            get { return _MucTieuGP; }
            set { _MucTieuGP = value; SetDirty("MucTieuGP"); }
        }
        [FieldName("MucTietKiemDuKien", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MucTietKiemDuKien
        {
            get { return _MucTietKiemDuKien; }
            set { _MucTietKiemDuKien = value; SetDirty("MucTietKiemDuKien"); }
        }
        [FieldName("ChiPhiDuKien", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ChiPhiDuKien
        {
            get { return _ChiPhiDuKien; }
            set { _ChiPhiDuKien = value; SetDirty("ChiPhiDuKien"); }
        }
        [FieldName("HoanVon", FieldAccessMode.ReadWrite, FieldType.String)]
        public string HoanVon
        {
            get { return _HoanVon; }
            set { _HoanVon = value; SetDirty("HoanVon"); }
        }
        [FieldName("MucCamKet", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MucCamKet
        {
            get { return _MucCamKet; }
            set { _MucCamKet = value; SetDirty("MucCamKet"); }
        }
        [FieldName("KhaNangThucHien", FieldAccessMode.ReadWrite, FieldType.String)]
        public string KhaNangThucHien
        {
            get { return _KhaNangThucHien; }
            set { _KhaNangThucHien = value; SetDirty("KhaNangThucHien"); }
        }
        [FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; SetDirty("EnterpriseId"); }
        }
        [FieldName("NamBatDau", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int NamBatDau
        {
            get { return _NamBatDau; }
            set { _NamBatDau = value; SetDirty("NamBatDau"); }
        }
        [FieldName("NamKetThuc", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int NamKetThuc
        {
            get { return _NamKetThuc; }
            set { _NamKetThuc = value; SetDirty("NamKetThuc"); }
        }
        [FieldName("IsFiveYear", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsFiveYear
        {
            get { return _IsFiveYear; }
            set { _IsFiveYear = value; SetDirty("IsFiveYear"); }
        }
        [FieldName("TuongDuong", FieldAccessMode.ReadWrite, FieldType.String)]
        public string TuongDuong
        {
            get { return _TuongDuong; }
            set { _TuongDuong = value; SetDirty("TuongDuong"); }
        }
        [FieldName("ThanhTien", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; SetDirty("ThanhTien"); }
        }
        [FieldName("LoiIchKhac", FieldAccessMode.ReadWrite, FieldType.String)]
        public string LoiIchKhac
        {
            get { return _LoiIchKhac; }
            set { _LoiIchKhac = value; SetDirty("LoiIchKhac"); }
        }
        [FieldName("IsPlan", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsPlan
        {
            get { return _IsPlan; }
            set { _IsPlan = value; SetDirty("IsPlan"); }
        }
        [FieldName("GhiChu", FieldAccessMode.ReadWrite, FieldType.String)]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; SetDirty("GhiChu"); }
        }
        [FieldName("LoaiNhienLieu", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int LoaiNhienLieu
        {
            get { return _LoaiNhienLieu; }
            set { _LoaiNhienLieu = value; SetDirty("LoaiNhienLieu"); }
        }
        [FieldName("MucTKThucTe", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MucTKThucTe
        {
            get { return _MucTKThucTe; }
            set { _MucTKThucTe = value; SetDirty("MucTKThucTe"); }
        }
        [FieldName("MucTKCPThucTe", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MucTKCPThucTe
        {
            get { return _MucTKCPThucTe; }
            set { _MucTKCPThucTe = value; SetDirty("MucTKCPThucTe"); }
        }
        [FieldName("CPThucTe", FieldAccessMode.ReadWrite, FieldType.String)]
        public string CPThucTe
        {
            get { return _CPThucTe; }
            set { _CPThucTe = value; SetDirty("CPThucTe"); }
        }
        [FieldName("TKCPDuKien", FieldAccessMode.ReadWrite, FieldType.String)]
        public string TKCPDuKien
        {
            get { return _TKCPDuKien; }
            set { _TKCPDuKien = value; SetDirty("TKCPDuKien"); }
        }
        [FieldName("IsAdd", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsAdd
        {
            get { return _IsAdd; }
            set { _IsAdd = value; SetDirty("IsAdd"); }
        }
        [FieldName("IsApproved", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; SetDirty("IsApproved"); }
        }
        [FieldName("IsApplied", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsApplied
        {
            get { return _IsApplied; }
            set { _IsApplied = value; SetDirty("IsApplied"); }
        }
        [FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ReportId
        {
            get { return _ReportId; }
            set { _ReportId = value; SetDirty("ReportId"); }
        }
        [FieldName("TuongDuongTT", FieldAccessMode.ReadWrite, FieldType.String)]
        public string TuongDuongTT
        {
            get { return _TuongDuongTT; }
            set { _TuongDuongTT = value; SetDirty("TuongDuongTT"); }
        }
        [FieldName("GhiChuTT", FieldAccessMode.ReadWrite, FieldType.String)]
        public string GhiChuTT
        {
            get { return _GhiChuTT; }
            set { _GhiChuTT = value; SetDirty("GhiChuTT"); }
        }
        [FieldName("LoiIchKhacTT", FieldAccessMode.ReadWrite, FieldType.String)]
        public string LoiIchKhacTT
        {
            get { return _LoiIchKhacTT; }
            set { _LoiIchKhacTT = value; SetDirty("LoiIchKhacTT"); }
        }
        [FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int MeasurementId
        {
            get { return _MeasurementId; }
            set { _MeasurementId = value; SetDirty("MeasurementId"); }
        }
        [FieldName("HeThongSuDung", FieldAccessMode.ReadWrite, FieldType.String)]
        public string HeThongSuDung
        {
            get { return _HeThongSuDung; }
            set { _HeThongSuDung = value; SetDirty("HeThongSuDung"); }
        }
        #endregion

    }
}
