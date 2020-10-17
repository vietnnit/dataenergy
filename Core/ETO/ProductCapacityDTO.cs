using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
    public class ProductCapacity
    {

        #region Constructor
        public ProductCapacity()
        { }

        public ProductCapacity(ProductCapacityBO productcapacityBO)
        {
            this.ProductId = productcapacityBO.ProductId;
            this.MaxQuantity = productcapacityBO.MaxQuantity;
            this.DesignQuantity = productcapacityBO.DesignQuantity;
            this.ReportId = productcapacityBO.ReportId;
            this.RateOfCost = productcapacityBO.RateOfCost;
            this.RateOfRevenue = productcapacityBO.RateOfRevenue;
            this.IsPlan = productcapacityBO.IsPlan;
            this.ReportYear = productcapacityBO.ReportYear;
            this.Id = productcapacityBO.Id;
            this.MucSXHienTai = productcapacityBO.MucSXHienTai;
            this.TieuThuNLTheoSP = productcapacityBO.TieuThuNLTheoSP;
            this.DoanhThuTheoSP = productcapacityBO.DoanhThuTheoSP;
        }
        #endregion

        #region Private Variables
        private int _ProductId;
        private decimal _MaxQuantity;
        private decimal _DesignQuantity;
        private int _ReportId;
        private decimal _RateOfCost;
        private decimal _RateOfRevenue;
        private bool _IsPlan;
        private int _ReportYear;
        private int _Id;
        private int _Total;

        private decimal _MucSXHienTai;
        private decimal _TieuThuNLTheoSP;
        private decimal _DoanhThuTheoSP;
        #endregion

        #region Public Properties

        public int ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        public decimal MaxQuantity
        {
            get { return _MaxQuantity; }
            set { _MaxQuantity = value; }
        }
        public decimal DesignQuantity
        {
            get { return _DesignQuantity; }
            set { _DesignQuantity = value; }
        }
        public int ReportId
        {
            get { return _ReportId; }
            set { _ReportId = value; }
        }
        public decimal RateOfCost
        {
            get { return _RateOfCost; }
            set { _RateOfCost = value; }
        }
        public decimal RateOfRevenue
        {
            get { return _RateOfRevenue; }
            set { _RateOfRevenue = value; }
        }
        public bool IsPlan
        {
            get { return _IsPlan; }
            set { _IsPlan = value; }
        }
        public int ReportYear
        {
            get { return _ReportYear; }
            set { _ReportYear = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public decimal MucSXHienTai
        {
            get { return _MucSXHienTai; }
            set { _MucSXHienTai = value; }
        }
        public decimal TieuThuNLTheoSP
        {
            get { return _TieuThuNLTheoSP; }
            set { _TieuThuNLTheoSP = value; }
        }
        public decimal DoanhThuTheoSP
        {
            get { return _DoanhThuTheoSP; }
            set { _DoanhThuTheoSP = value; }
        }
        #endregion Public Properties

    }
}
