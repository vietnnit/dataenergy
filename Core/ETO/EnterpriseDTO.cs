using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
    public class Enterprise
    {

        #region Constructor
        public Enterprise()
        { }

        public Enterprise(EnterpriseBO enterpriseBO)
        {
            this.Id = enterpriseBO.Id;
            this.Title = enterpriseBO.Title;
            this.ProvinceId = enterpriseBO.ProvinceId;
            this.DistrictId = enterpriseBO.DistrictId;
            this.Phone = enterpriseBO.Phone;
            this.Email = enterpriseBO.Email;
            this.Fax = enterpriseBO.Fax;
            this.Address = enterpriseBO.Address;
            this.Info = enterpriseBO.Info;
            this.IsActive = enterpriseBO.IsActive;
            this.IsDelete = enterpriseBO.IsDelete;
            this.ManProvinceId = enterpriseBO.ManProvinceId;
            this.ManDistrictId = enterpriseBO.ManDistrictId;
            this.ManPhone = enterpriseBO.ManPhone;
            this.ManEmail = enterpriseBO.ManEmail;
            this.ManAddress = enterpriseBO.ManAddress;
            this.ManPerson = enterpriseBO.ManPerson;
            this.AreaId = enterpriseBO.AreaId;
            this.ManFax = enterpriseBO.ManFax;
            this.SubAreaId = enterpriseBO.SubAreaId;
            this.TaxCode = enterpriseBO.TaxCode;
            this.OrganizationId = enterpriseBO.OrganizationId;
            this.IsConfirm = enterpriseBO.IsConfirm;
            this.ShortName = enterpriseBO.ShortName;
            this.IsImportant = enterpriseBO.IsImportant;
            this.ParentName = enterpriseBO.ParentName;
            this.OwnerId = enterpriseBO.OwnerId;
            this.ProduceEmployeeNo = enterpriseBO.ProduceEmployeeNo;
            this.OfficeEmployeeNo = enterpriseBO.OfficeEmployeeNo;
            this.ProduceAreaNo = enterpriseBO.ProduceAreaNo;
            this.OfficeAreaNo = enterpriseBO.OfficeAreaNo;
            this.ActiveYear = enterpriseBO.ActiveYear;
            this.CustomerCode = enterpriseBO.CustomerCode;
            this.MoHinhQLNL = enterpriseBO.MoHinhQLNL;
            this.ReportTemplate = enterpriseBO.ReportTemplate;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private string _Title;
        private int _ProvinceId;
        private int _DistrictId;
        private string _Phone;
        private string _Email;
        private string _Fax;
        private string _Address;
        private string _Info;
        private bool _IsActive;
        private bool _IsDelete;
        private int _ManProvinceId;
        private int _ManDistrictId;
        private string _ManPhone;
        private string _ManEmail;
        private string _ManAddress;
        private string _ManPerson;
        private int _AreaId;
        private string _ManFax;
        private int _SubAreaId;
        private string _TaxCode;
        private int _OrganizationId;
        private bool _IsConfirm;
        private string _ShortName;
        private bool _IsImportant;
        private string _ParentName;
        private int _OwnerId;
        private int _ProduceEmployeeNo;
        private int _OfficeEmployeeNo;
        private int _ProduceAreaNo;
        private int _OfficeAreaNo;
        private int _ActiveYear;
        private string _CustomerCode;
        private int _Total;
        private int _MoHinhQLNL;
        private int _ReportTemplate;
        #endregion

        #region Public Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public int ProvinceId
        {
            get { return _ProvinceId; }
            set { _ProvinceId = value; }
        }
        public int DistrictId
        {
            get { return _DistrictId; }
            set { _DistrictId = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Info
        {
            get { return _Info; }
            set { _Info = value; }
        }
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
        public int ManProvinceId
        {
            get { return _ManProvinceId; }
            set { _ManProvinceId = value; }
        }
        public int ManDistrictId
        {
            get { return _ManDistrictId; }
            set { _ManDistrictId = value; }
        }
        public string ManPhone
        {
            get { return _ManPhone; }
            set { _ManPhone = value; }
        }
        public string ManEmail
        {
            get { return _ManEmail; }
            set { _ManEmail = value; }
        }
        public string ManAddress
        {
            get { return _ManAddress; }
            set { _ManAddress = value; }
        }
        public string ManPerson
        {
            get { return _ManPerson; }
            set { _ManPerson = value; }
        }
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; }
        }
        public string ManFax
        {
            get { return _ManFax; }
            set { _ManFax = value; }
        }
        public int SubAreaId
        {
            get { return _SubAreaId; }
            set { _SubAreaId = value; }
        }
        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; }
        }
        public int OrganizationId
        {
            get { return _OrganizationId; }
            set { _OrganizationId = value; }
        }
        public bool IsConfirm
        {
            get { return _IsConfirm; }
            set { _IsConfirm = value; }
        }
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }
        public bool IsImportant
        {
            get { return _IsImportant; }
            set { _IsImportant = value; }
        }
        public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; }
        }
        public int OwnerId
        {
            get { return _OwnerId; }
            set { _OwnerId = value; }
        }
        public int ProduceEmployeeNo
        {
            get { return _ProduceEmployeeNo; }
            set { _ProduceEmployeeNo = value; }
        }
        public int OfficeEmployeeNo
        {
            get { return _OfficeEmployeeNo; }
            set { _OfficeEmployeeNo = value; }
        }
        public int ProduceAreaNo
        {
            get { return _ProduceAreaNo; }
            set { _ProduceAreaNo = value; }
        }
        public int OfficeAreaNo
        {
            get { return _OfficeAreaNo; }
            set { _OfficeAreaNo = value; }
        }
        public int ActiveYear
        {
            get { return _ActiveYear; }
            set { _ActiveYear = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public int MoHinhQLNL
        {
            get { return _MoHinhQLNL; }
            set { _MoHinhQLNL = value; }
        } public int ReportTemplate
        {
            get { return _ReportTemplate; }
            set { _ReportTemplate = value; }
        }
        #endregion Public Properties

    }
}
