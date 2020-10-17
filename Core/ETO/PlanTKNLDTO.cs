using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
    public class PlanTKNL
    {

        #region Constructor
        public PlanTKNL()
        { }

        public PlanTKNL(PlanTKNLBO plantknlBO)
        {
            this.Id = plantknlBO.Id;
            this.IdGiaPhap = plantknlBO.IdGiaPhap;
            this.IdPlan = plantknlBO.IdPlan;
            this.GiaiDoan = plantknlBO.GiaiDoan;
            this.MucTieuGP = plantknlBO.MucTieuGP;
            this.MucTietKiemDuKien = plantknlBO.MucTietKiemDuKien;
            this.ChiPhiDuKien = plantknlBO.ChiPhiDuKien;
            this.HoanVon = plantknlBO.HoanVon;
            this.MucCamKet = plantknlBO.MucCamKet;
            this.KhaNangThucHien = plantknlBO.KhaNangThucHien;
            this.EnterpriseId = plantknlBO.EnterpriseId;
            this.NamBatDau = plantknlBO.NamBatDau;
            this.NamKetThuc = plantknlBO.NamKetThuc;
            this.IsFiveYear = plantknlBO.IsFiveYear;
            this.TuongDuong = plantknlBO.TuongDuong;
            this.ThanhTien = plantknlBO.ThanhTien;
            this.LoiIchKhac = plantknlBO.LoiIchKhac;
            this.IsPlan = plantknlBO.IsPlan;
            this.GhiChu = plantknlBO.GhiChu;
            this.LoaiNhienLieu = plantknlBO.LoaiNhienLieu;
            this.MucTKThucTe = plantknlBO.MucTKThucTe;
            this.MucTKCPThucTe = plantknlBO.MucTKCPThucTe;
            this.CPThucTe = plantknlBO.CPThucTe;
            this.TKCPDuKien = plantknlBO.TKCPDuKien;
            this.IsAdd = plantknlBO.IsAdd;
            this.IsApproved = plantknlBO.IsApproved;
            this.IsApplied = plantknlBO.IsApplied;
            this.ReportId = plantknlBO.ReportId;
            this.TuongDuongTT = plantknlBO.TuongDuongTT;
            this.GhiChuTT = plantknlBO.GhiChuTT;
            this.LoiIchKhacTT = plantknlBO.LoiIchKhacTT;
            this.MeasurementId = plantknlBO.MeasurementId;
            this.HeThongSuDung = plantknlBO.HeThongSuDung;
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
        private int _Total;
        private string _HeThongSuDung;
        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int IdGiaPhap
        {
            get { return _IdGiaPhap; }
            set { _IdGiaPhap = value; }
        }
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        public string GiaiDoan
        {
            get { return _GiaiDoan; }
            set { _GiaiDoan = value; }
        }
        public string MucTieuGP
        {
            get { return _MucTieuGP; }
            set { _MucTieuGP = value; }
        }
        public string MucTietKiemDuKien
        {
            get { return _MucTietKiemDuKien; }
            set { _MucTietKiemDuKien = value; }
        }
        public string ChiPhiDuKien
        {
            get { return _ChiPhiDuKien; }
            set { _ChiPhiDuKien = value; }
        }
        public string HoanVon
        {
            get { return _HoanVon; }
            set { _HoanVon = value; }
        }
        public string MucCamKet
        {
            get { return _MucCamKet; }
            set { _MucCamKet = value; }
        }
        public string KhaNangThucHien
        {
            get { return _KhaNangThucHien; }
            set { _KhaNangThucHien = value; }
        }
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; }
        }
        public int NamBatDau
        {
            get { return _NamBatDau; }
            set { _NamBatDau = value; }
        }
        public int NamKetThuc
        {
            get { return _NamKetThuc; }
            set { _NamKetThuc = value; }
        }
        public bool IsFiveYear
        {
            get { return _IsFiveYear; }
            set { _IsFiveYear = value; }
        }
        public string TuongDuong
        {
            get { return _TuongDuong; }
            set { _TuongDuong = value; }
        }
        public string ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
        public string LoiIchKhac
        {
            get { return _LoiIchKhac; }
            set { _LoiIchKhac = value; }
        }
        public bool IsPlan
        {
            get { return _IsPlan; }
            set { _IsPlan = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        public int LoaiNhienLieu
        {
            get { return _LoaiNhienLieu; }
            set { _LoaiNhienLieu = value; }
        }
        public string MucTKThucTe
        {
            get { return _MucTKThucTe; }
            set { _MucTKThucTe = value; }
        }
        public string MucTKCPThucTe
        {
            get { return _MucTKCPThucTe; }
            set { _MucTKCPThucTe = value; }
        }
        public string CPThucTe
        {
            get { return _CPThucTe; }
            set { _CPThucTe = value; }
        }
        public string TKCPDuKien
        {
            get { return _TKCPDuKien; }
            set { _TKCPDuKien = value; }
        }
        public bool IsAdd
        {
            get { return _IsAdd; }
            set { _IsAdd = value; }
        }
        public bool IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        public bool IsApplied
        {
            get { return _IsApplied; }
            set { _IsApplied = value; }
        }
        public int ReportId
        {
            get { return _ReportId; }
            set { _ReportId = value; }
        }
        public string TuongDuongTT
        {
            get { return _TuongDuongTT; }
            set { _TuongDuongTT = value; }
        }
        public string GhiChuTT
        {
            get { return _GhiChuTT; }
            set { _GhiChuTT = value; }
        }
        public string LoiIchKhacTT
        {
            get { return _LoiIchKhacTT; }
            set { _LoiIchKhacTT = value; }
        }
        public int MeasurementId
        {
            get { return _MeasurementId; }
            set { _MeasurementId = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public string HeThongSuDung
        {
            get { return _HeThongSuDung; }
            set { _HeThongSuDung = value; }
        }
        #endregion Public Properties

    }
}
