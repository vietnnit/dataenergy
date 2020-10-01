using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class EnterpriseHistory
	{

	#region Constructor
	public EnterpriseHistory()
	{}
	
	public EnterpriseHistory(EnterpriseHistoryBO enterprisehistoryBO)
	{
			this.Id = enterprisehistoryBO.Id;
			this.Title = enterprisehistoryBO.Title;
			this.ProvinceId = enterprisehistoryBO.ProvinceId;
			this.DistrictId = enterprisehistoryBO.DistrictId;
			this.Phone = enterprisehistoryBO.Phone;
			this.Email = enterprisehistoryBO.Email;
			this.Fax = enterprisehistoryBO.Fax;
			this.Address = enterprisehistoryBO.Address;
			this.Info = enterprisehistoryBO.Info;
			this.IsActive = enterprisehistoryBO.IsActive;
			this.IsDelete = enterprisehistoryBO.IsDelete;
			this.ManProvinceId = enterprisehistoryBO.ManProvinceId;
			this.ManDistrictId = enterprisehistoryBO.ManDistrictId;
			this.ManPhone = enterprisehistoryBO.ManPhone;
			this.ManEmail = enterprisehistoryBO.ManEmail;
			this.ManAddress = enterprisehistoryBO.ManAddress;
			this.ManPerson = enterprisehistoryBO.ManPerson;
			this.AreaId = enterprisehistoryBO.AreaId;
			this.ManFax = enterprisehistoryBO.ManFax;
			this.SubAreaId = enterprisehistoryBO.SubAreaId;
			this.MST = enterprisehistoryBO.MST;
			this.OrganizationId = enterprisehistoryBO.OrganizationId;
			this.IsConfirm = enterprisehistoryBO.IsConfirm;
			this.ShortName = enterprisehistoryBO.ShortName;
			this.IsImportant = enterprisehistoryBO.IsImportant;
			this.ParentName = enterprisehistoryBO.ParentName;
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
	private int _Total;
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
	public string MST
	{ 
		get { return _MST; }
		set { _MST = value; }
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
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
