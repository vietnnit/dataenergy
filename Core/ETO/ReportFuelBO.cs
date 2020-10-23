using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class ReportFuelBO : BaseEntity
    {

        #region Constructor
        public ReportFuelBO()
        { }


        public ReportFuelBO(ReportFuel reportfuelDTO)
        {
            this.Id = reportfuelDTO.Id;
            this.Year = reportfuelDTO.Year;
            this.Created = reportfuelDTO.Created;
            this.Modified = reportfuelDTO.Modified;
            this.Modifier = reportfuelDTO.Modifier;
            this.Creator = reportfuelDTO.Creator;
            this.EnterpriseId = reportfuelDTO.EnterpriseId;
            this.ReporterName = reportfuelDTO.ReporterName;
            this.AprovedDate = reportfuelDTO.AprovedDate;
            this.AreaId = reportfuelDTO.AreaId;
            this.SubAreaId = reportfuelDTO.SubAreaId;
            this.ReceivedDate = reportfuelDTO.ReceivedDate;
            this.ConfirmedDate = reportfuelDTO.ConfirmedDate;
            this.Fax = reportfuelDTO.Fax;
            this.Email = reportfuelDTO.Email;
            this.Address = reportfuelDTO.Address;
            this.ProviceId = reportfuelDTO.ProviceId;
            this.DistrictId = reportfuelDTO.DistrictId;
            this.UserId = reportfuelDTO.UserId;
            this.ApproverId = reportfuelDTO.ApproverId;
            this.SendSatus = reportfuelDTO.SendSatus;
            this.IsDelete = reportfuelDTO.IsDelete;
            this.ApprovedSatus = reportfuelDTO.ApprovedSatus;
            this.NoFuel_TOE = reportfuelDTO.NoFuel_TOE;
            this.ReportDate = reportfuelDTO.ReportDate;
            this.Phone = reportfuelDTO.Phone;
            this.OrganizationId = reportfuelDTO.OrganizationId;
            this.SendDate = reportfuelDTO.SendDate;
            this.ProvinceParentId = reportfuelDTO.ProvinceParentId;
            this.DistrictParentId = reportfuelDTO.DistrictParentId;
            this.AddressParent = reportfuelDTO.AddressParent;
            this.FaxParent = reportfuelDTO.FaxParent;
            this.PhoneParent = reportfuelDTO.PhoneParent;
            this.ParentName = reportfuelDTO.ParentName;
            this.EmailParent = reportfuelDTO.EmailParent;
            this.IsFiveYear = reportfuelDTO.IsFiveYear;
            this.PathFile = reportfuelDTO.PathFile;
            this.TaxCode = reportfuelDTO.TaxCode;
            this.CompanyName = reportfuelDTO.CompanyName;
            this.Responsible = reportfuelDTO.Responsible;
            this.OwnerId = reportfuelDTO.OwnerId;
            this.ProcessStatus = reportfuelDTO.ProcessStatus;
            this.ReportType = reportfuelDTO.ReportType;
        }
        #endregion

        #region Private Variables
        private int _Id;
        private int _Year;
        private System.DateTime _Created;
        private System.DateTime _Modified;
        private string _Modifier;
        private string _Creator;
        private int _EnterpriseId;
        private string _ReporterName;
        private System.DateTime _AprovedDate;
        private int _AreaId;
        private int _SubAreaId;
        private System.DateTime _ReceivedDate;
        private System.DateTime _ConfirmedDate;
        private string _Fax;
        private string _Email;
        private string _Address;
        private int _ProviceId;
        private int _DistrictId;
        private int _UserId;
        private int _ApproverId;
        private int _SendSatus;
        private bool _IsDelete;
        private bool _ApprovedSatus;
        private decimal _NoFuel_TOE;
        private System.DateTime _ReportDate;
        private string _Phone;
        private int _OrganizationId;
        private System.DateTime _SendDate;
        private int _ProvinceParentId;
        private int _DistrictParentId;
        private string _AddressParent;
        private string _FaxParent;
        private string _PhoneParent;
        private string _ParentName;
        private string _EmailParent;
        private bool _IsFiveYear;
        private string _PathFile;
        private string _TaxCode;
        private string _CompanyName;
        private string _Responsible;
        private int _OwnerId;
        private int _ProcessStatus;
        private string _ReportType;
        #endregion

        #region Public Properties
        public override string TableName
        {
            get { return "DE_ReportFuel"; }
            set { base.TableName = "DE_ReportFuel"; }
        }

        [FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
        public override int Id
        {
            get { return _Id; }
            set { _Id = value; SetDirty("Id"); }
        }
        [FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int Year
        {
            get { return _Year; }
            set { _Year = value; SetDirty("Year"); }
        }
        [FieldName("Created", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime Created
        {
            get { return _Created; }
            set { _Created = value; SetDirty("Created"); }
        }
        [FieldName("Modified", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; SetDirty("Modified"); }
        }
        [FieldName("Modifier", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Modifier
        {
            get { return _Modifier; }
            set { _Modifier = value; SetDirty("Modifier"); }
        }
        [FieldName("Creator", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; SetDirty("Creator"); }
        }
        [FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set { _EnterpriseId = value; SetDirty("EnterpriseId"); }
        }
        [FieldName("ReporterName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ReporterName
        {
            get { return _ReporterName; }
            set { _ReporterName = value; SetDirty("ReporterName"); }
        }
        [FieldName("AprovedDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime AprovedDate
        {
            get { return _AprovedDate; }
            set { _AprovedDate = value; SetDirty("AprovedDate"); }
        }
        [FieldName("AreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; SetDirty("AreaId"); }
        }
        [FieldName("SubAreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int SubAreaId
        {
            get { return _SubAreaId; }
            set { _SubAreaId = value; SetDirty("SubAreaId"); }
        }
        [FieldName("ReceivedDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; SetDirty("ReceivedDate"); }
        }
        [FieldName("ConfirmedDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime ConfirmedDate
        {
            get { return _ConfirmedDate; }
            set { _ConfirmedDate = value; SetDirty("ConfirmedDate"); }
        }
        [FieldName("Fax", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; SetDirty("Fax"); }
        }
        [FieldName("Email", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; SetDirty("Email"); }
        }
        [FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; SetDirty("Address"); }
        }
        [FieldName("ProviceId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProviceId
        {
            get { return _ProviceId; }
            set { _ProviceId = value; SetDirty("ProviceId"); }
        }
        [FieldName("DistrictId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int DistrictId
        {
            get { return _DistrictId; }
            set { _DistrictId = value; SetDirty("DistrictId"); }
        }
        [FieldName("UserId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; SetDirty("UserId"); }
        }
        [FieldName("ApproverId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ApproverId
        {
            get { return _ApproverId; }
            set { _ApproverId = value; SetDirty("ApproverId"); }
        }
        [FieldName("SendSatus", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int SendSatus
        {
            get { return _SendSatus; }
            set { _SendSatus = value; SetDirty("SendSatus"); }
        }
        [FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; SetDirty("IsDelete"); }
        }
        [FieldName("ApprovedSatus", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool ApprovedSatus
        {
            get { return _ApprovedSatus; }
            set { _ApprovedSatus = value; SetDirty("ApprovedSatus"); }
        }
        [FieldName("NoFuel_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
        public decimal NoFuel_TOE
        {
            get { return _NoFuel_TOE; }
            set { _NoFuel_TOE = value; SetDirty("NoFuel_TOE"); }
        }
        [FieldName("ReportDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime ReportDate
        {
            get { return _ReportDate; }
            set { _ReportDate = value; SetDirty("ReportDate"); }
        }
        [FieldName("Phone", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; SetDirty("Phone"); }
        }
        [FieldName("OrganizationId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int OrganizationId
        {
            get { return _OrganizationId; }
            set { _OrganizationId = value; SetDirty("OrganizationId"); }
        }
        [FieldName("SendDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
        public System.DateTime SendDate
        {
            get { return _SendDate; }
            set { _SendDate = value; SetDirty("SendDate"); }
        }
        [FieldName("ProvinceParentId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProvinceParentId
        {
            get { return _ProvinceParentId; }
            set { _ProvinceParentId = value; SetDirty("ProvinceParentId"); }
        }
        [FieldName("DistrictParentId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int DistrictParentId
        {
            get { return _DistrictParentId; }
            set { _DistrictParentId = value; SetDirty("DistrictParentId"); }
        }
        [FieldName("AddressParent", FieldAccessMode.ReadWrite, FieldType.String)]
        public string AddressParent
        {
            get { return _AddressParent; }
            set { _AddressParent = value; SetDirty("AddressParent"); }
        }
        [FieldName("FaxParent", FieldAccessMode.ReadWrite, FieldType.String)]
        public string FaxParent
        {
            get { return _FaxParent; }
            set { _FaxParent = value; SetDirty("FaxParent"); }
        }
        [FieldName("PhoneParent", FieldAccessMode.ReadWrite, FieldType.String)]
        public string PhoneParent
        {
            get { return _PhoneParent; }
            set { _PhoneParent = value; SetDirty("PhoneParent"); }
        }
        [FieldName("ParentName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; SetDirty("ParentName"); }
        }
        [FieldName("EmailParent", FieldAccessMode.ReadWrite, FieldType.String)]
        public string EmailParent
        {
            get { return _EmailParent; }
            set { _EmailParent = value; SetDirty("EmailParent"); }
        }
        [FieldName("IsFiveYear", FieldAccessMode.ReadWrite, FieldType.String)]
        public bool IsFiveYear
        {
            get { return _IsFiveYear; }
            set { _IsFiveYear = value; SetDirty("IsFiveYear"); }
        }
        [FieldName("PathFile", FieldAccessMode.ReadWrite, FieldType.String)]
        public string PathFile
        {
            get { return _PathFile; }
            set { _PathFile = value; SetDirty("PathFile"); }
        }
        [FieldName("TaxCode", FieldAccessMode.ReadWrite, FieldType.String)]
        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; SetDirty("TaxCode"); }
        }
        [FieldName("CompanyName", FieldAccessMode.ReadWrite, FieldType.String)]
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; SetDirty("CompanyName"); }
        }
        [FieldName("Responsible", FieldAccessMode.ReadWrite, FieldType.String)]
        public string Responsible
        {
            get { return _Responsible; }
            set { _Responsible = value; SetDirty("Responsible"); }
        }
        [FieldName("OwnerId", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int OwnerId
        {
            get { return _OwnerId; }
            set { _OwnerId = value; SetDirty("OwnerId"); }
        }
        [FieldName("ProcessStatus", FieldAccessMode.ReadWrite, FieldType.Int)]
        public int ProcessStatus
        {
            get { return _ProcessStatus; }
            set { _ProcessStatus = value; SetDirty("ProcessStatus"); }
        }

        [FieldName("ReportType", FieldAccessMode.ReadWrite, FieldType.String)]
        public string ReportType
        {
            get { return _ReportType; }
            set { _ReportType = value; SetDirty("ReportType"); }
        }
        #endregion

    }
}
