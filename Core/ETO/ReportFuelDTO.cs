using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ReportFuel
	{

	#region Constructor
	public ReportFuel()
	{}
	
	public ReportFuel(ReportFuelBO reportfuelBO)
	{
			this.Id = reportfuelBO.Id;
			this.Year = reportfuelBO.Year;
			this.Created = reportfuelBO.Created;
			this.Modified = reportfuelBO.Modified;
			this.Modifier = reportfuelBO.Modifier;
			this.Creator = reportfuelBO.Creator;
			this.EnterpriseId = reportfuelBO.EnterpriseId;
			this.ReporterName = reportfuelBO.ReporterName;
			this.AprovedDate = reportfuelBO.AprovedDate;
			this.AreaId = reportfuelBO.AreaId;
			this.SubAreaId = reportfuelBO.SubAreaId;
			this.ReceivedDate = reportfuelBO.ReceivedDate;
			this.ConfirmedDate = reportfuelBO.ConfirmedDate;
			this.Fax = reportfuelBO.Fax;
			this.Email = reportfuelBO.Email;
			this.Address = reportfuelBO.Address;
			this.ProviceId = reportfuelBO.ProviceId;
			this.DistrictId = reportfuelBO.DistrictId;
			this.UserId = reportfuelBO.UserId;
			this.ApproverId = reportfuelBO.ApproverId;
			this.SendSatus = reportfuelBO.SendSatus;
			this.IsDelete = reportfuelBO.IsDelete;
			this.ApprovedSatus = reportfuelBO.ApprovedSatus;
			this.NoFuel_TOE = reportfuelBO.NoFuel_TOE;
			this.ReportDate = reportfuelBO.ReportDate;
			this.Phone = reportfuelBO.Phone;
			this.OrganizationId = reportfuelBO.OrganizationId;
			this.SendDate = reportfuelBO.SendDate;
			this.ProvinceParentId = reportfuelBO.ProvinceParentId;
			this.DistrictParentId = reportfuelBO.DistrictParentId;
			this.AddressParent = reportfuelBO.AddressParent;
			this.FaxParent = reportfuelBO.FaxParent;
			this.PhoneParent = reportfuelBO.PhoneParent;
			this.ParentName = reportfuelBO.ParentName;
			this.EmailParent = reportfuelBO.EmailParent;
			this.IsFiveYear = reportfuelBO.IsFiveYear;
			this.PathFile = reportfuelBO.PathFile;
			this.TaxCode = reportfuelBO.TaxCode;
			this.CompanyName = reportfuelBO.CompanyName;
			this.Responsible = reportfuelBO.Responsible;
			this.OwnerId = reportfuelBO.OwnerId;
			this.ProcessStatus = reportfuelBO.ProcessStatus;
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
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	public System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value; }
	}
	public System.DateTime Modified
	{ 
		get { return _Modified; }
		set { _Modified = value; }
	}
	public string Modifier
	{ 
		get { return _Modifier; }
		set { _Modifier = value; }
	}
	public string Creator
	{ 
		get { return _Creator; }
		set { _Creator = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public string ReporterName
	{ 
		get { return _ReporterName; }
		set { _ReporterName = value; }
	}
	public System.DateTime AprovedDate
	{ 
		get { return _AprovedDate; }
		set { _AprovedDate = value; }
	}
	public int AreaId
	{ 
		get { return _AreaId; }
		set { _AreaId = value; }
	}
	public int SubAreaId
	{ 
		get { return _SubAreaId; }
		set { _SubAreaId = value; }
	}
	public System.DateTime ReceivedDate
	{ 
		get { return _ReceivedDate; }
		set { _ReceivedDate = value; }
	}
	public System.DateTime ConfirmedDate
	{ 
		get { return _ConfirmedDate; }
		set { _ConfirmedDate = value; }
	}
	public string Fax
	{ 
		get { return _Fax; }
		set { _Fax = value; }
	}
	public string Email
	{ 
		get { return _Email; }
		set { _Email = value; }
	}
	public string Address
	{ 
		get { return _Address; }
		set { _Address = value; }
	}
	public int ProviceId
	{ 
		get { return _ProviceId; }
		set { _ProviceId = value; }
	}
	public int DistrictId
	{ 
		get { return _DistrictId; }
		set { _DistrictId = value; }
	}
	public int UserId
	{ 
		get { return _UserId; }
		set { _UserId = value; }
	}
	public int ApproverId
	{ 
		get { return _ApproverId; }
		set { _ApproverId = value; }
	}
	public int SendSatus
	{ 
		get { return _SendSatus; }
		set { _SendSatus = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public bool ApprovedSatus
	{ 
		get { return _ApprovedSatus; }
		set { _ApprovedSatus = value; }
	}
	public decimal NoFuel_TOE
	{ 
		get { return _NoFuel_TOE; }
		set { _NoFuel_TOE = value; }
	}
	public System.DateTime ReportDate
	{ 
		get { return _ReportDate; }
		set { _ReportDate = value; }
	}
	public string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value; }
	}
	public int OrganizationId
	{ 
		get { return _OrganizationId; }
		set { _OrganizationId = value; }
	}
	public System.DateTime SendDate
	{ 
		get { return _SendDate; }
		set { _SendDate = value; }
	}
	public int ProvinceParentId
	{ 
		get { return _ProvinceParentId; }
		set { _ProvinceParentId = value; }
	}
	public int DistrictParentId
	{ 
		get { return _DistrictParentId; }
		set { _DistrictParentId = value; }
	}
	public string AddressParent
	{ 
		get { return _AddressParent; }
		set { _AddressParent = value; }
	}
	public string FaxParent
	{ 
		get { return _FaxParent; }
		set { _FaxParent = value; }
	}
	public string PhoneParent
	{ 
		get { return _PhoneParent; }
		set { _PhoneParent = value; }
	}
	public string ParentName
	{ 
		get { return _ParentName; }
		set { _ParentName = value; }
	}
	public string EmailParent
	{ 
		get { return _EmailParent; }
		set { _EmailParent = value; }
	}
	public bool IsFiveYear
	{ 
		get { return _IsFiveYear; }
		set { _IsFiveYear = value; }
	}
	public string PathFile
	{ 
		get { return _PathFile; }
		set { _PathFile = value; }
	}
	public string TaxCode
	{ 
		get { return _TaxCode; }
		set { _TaxCode = value; }
	}
	public string CompanyName
	{ 
		get { return _CompanyName; }
		set { _CompanyName = value; }
	}
	public string Responsible
	{ 
		get { return _Responsible; }
		set { _Responsible = value; }
	}
	public int OwnerId
	{ 
		get { return _OwnerId; }
		set { _OwnerId = value; }
	}
	public int ProcessStatus
	{ 
		get { return _ProcessStatus; }
		set { _ProcessStatus = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
