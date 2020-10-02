using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class EnterpriseHistoryBO : BaseEntity
    {

        #region Constructor
        public EnterpriseHistoryBO()
        { }


        public EnterpriseHistoryBO(EnterpriseHistory enterprisehistoryDTO)
        {
            this.Id = enterprisehistoryDTO.Id;
            this.Title = enterprisehistoryDTO.Title;
            this.ProvinceId = enterprisehistoryDTO.ProvinceId;
            this.DistrictId = enterprisehistoryDTO.DistrictId;
            this.Phone = enterprisehistoryDTO.Phone;
            this.Email = enterprisehistoryDTO.Email;
            this.Fax = enterprisehistoryDTO.Fax;
            this.Address = enterprisehistoryDTO.Address;
            this.Info = enterprisehistoryDTO.Info;
            this.IsActive = enterprisehistoryDTO.IsActive;
            this.IsDelete = enterprisehistoryDTO.IsDelete;
            this.ManProvinceId = enterprisehistoryDTO.ManProvinceId;
            this.ManDistrictId = enterprisehistoryDTO.ManDistrictId;
            this.ManPhone = enterprisehistoryDTO.ManPhone;
            this.ManEmail = enterprisehistoryDTO.ManEmail;
            this.ManAddress = enterprisehistoryDTO.ManAddress;
            this.ManPerson = enterprisehistoryDTO.ManPerson;
            this.AreaId = enterprisehistoryDTO.AreaId;
            this.ManFax = enterprisehistoryDTO.ManFax;
            this.SubAreaId = enterprisehistoryDTO.SubAreaId;
            this.MST = enterprisehistoryDTO.MST;
            this.OrganizationId = enterprisehistoryDTO.OrganizationId;
            this.IsConfirm = enterprisehistoryDTO.IsConfirm;
            this.ShortName = enterprisehistoryDTO.ShortName;
            this.IsImportant = enterprisehistoryDTO.IsImportant;
            this.ParentName = enterprisehistoryDTO.ParentName;
            this.MoHinhQLNL = enterprisehistoryDTO.MoHinhQLNL;
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
        private string _MST;
        private int _OrganizationId;
        private bool _IsConfirm;
        private string _ShortName;
        private bool _IsImportant;
        private string _ParentName;
        private int _MoHinhQLNL;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_EnterpriseHistory"; }
            set { base.TableName = "DE_EnterpriseHistory"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("Title", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; SetDirty("Title"); }
        }
        [FieldName("ProvinceId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProvinceId
        {
            get { return _ProvinceId; }
            set { _ProvinceId = value; SetDirty("ProvinceId"); }
        }
        [FieldName("DistrictId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int DistrictId
        {
            get { return _DistrictId; }
            set { _DistrictId = value; SetDirty("DistrictId"); }
        }
        [FieldName("Phone", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; SetDirty("Phone"); }
        }
        [FieldName("Email", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; SetDirty("Email"); }
        }
        [FieldName("Fax", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; SetDirty("Fax"); }
        }
        [FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; SetDirty("Address"); }
        }
        [FieldName("Info", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Info
        {
            get { return _Info; }
            set { _Info = value; SetDirty("Info"); }
        }
        [FieldName("IsActive", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; SetDirty("IsActive"); }
        }
        [FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; SetDirty("IsDelete"); }
        }
        [FieldName("ManProvinceId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ManProvinceId
        {
            get { return _ManProvinceId; }
            set { _ManProvinceId = value; SetDirty("ManProvinceId"); }
        }
        [FieldName("ManDistrictId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ManDistrictId
        {
            get { return _ManDistrictId; }
            set { _ManDistrictId = value; SetDirty("ManDistrictId"); }
        }
        [FieldName("ManPhone", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ManPhone
        {
            get { return _ManPhone; }
            set { _ManPhone = value; SetDirty("ManPhone"); }
        }
        [FieldName("ManEmail", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ManEmail
        {
            get { return _ManEmail; }
            set { _ManEmail = value; SetDirty("ManEmail"); }
        }
        [FieldName("ManAddress", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ManAddress
        {
            get { return _ManAddress; }
            set { _ManAddress = value; SetDirty("ManAddress"); }
        }
        [FieldName("ManPerson", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ManPerson
        {
            get { return _ManPerson; }
            set { _ManPerson = value; SetDirty("ManPerson"); }
        }
        [FieldName("AreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; SetDirty("AreaId"); }
        }
        [FieldName("ManFax", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ManFax
        {
            get { return _ManFax; }
            set { _ManFax = value; SetDirty("ManFax"); }
        }
        [FieldName("SubAreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int SubAreaId
        {
            get { return _SubAreaId; }
            set { _SubAreaId = value; SetDirty("SubAreaId"); }
        }
        [FieldName("MST", FieldAccessMode.ReadWrite, FieldType.String)]
        public string MST
        {
            get { return _MST; }
            set { _MST = value; SetDirty("MST"); }
        }
        [FieldName("OrganizationId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int OrganizationId
        {
            get { return _OrganizationId; }
            set { _OrganizationId = value; SetDirty("OrganizationId"); }
        }
        [FieldName("IsConfirm", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsConfirm
        {
            get { return _IsConfirm; }
            set { _IsConfirm = value; SetDirty("IsConfirm"); }
        }
        [FieldName("ShortName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; SetDirty("ShortName"); }
        }
        [FieldName("IsImportant", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsImportant
        {
            get { return _IsImportant; }
            set { _IsImportant = value; SetDirty("IsImportant"); }
        }
        [FieldName("ParentName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; SetDirty("ParentName"); }
        }
        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public int MoHinhQLNL
        {
            get { return _MoHinhQLNL; }
            set { _MoHinhQLNL = value; SetDirty("MoHinhQLNL"); }
        }
        #endregion

    }
}
