using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Organization
	{

	#region Constructor
	public Organization()
	{}
	
	public Organization(OrganizationBO organizationBO)
	{
			this.Id = organizationBO.Id;
			this.Title = organizationBO.Title;
			this.ProvinceId = organizationBO.ProvinceId;
			this.Address = organizationBO.Address;
			this.Note = organizationBO.Note;
			this.Phone = organizationBO.Phone;
			this.Email = organizationBO.Email;
			this.IsActive = organizationBO.IsActive;
			this.IsDelete = organizationBO.IsDelete;
			this.SortOrder = organizationBO.SortOrder;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _Title;
	private int _ProvinceId;
	private string _Address;
	private string _Note;
	private string _Phone;
	private string _Email;
	private bool _IsActive;
	private bool _IsDelete;
	private int _SortOrder;
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
	public string Address
	{ 
		get { return _Address; }
		set { _Address = value; }
	}
	public string Note
	{ 
		get { return _Note; }
		set { _Note = value; }
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
	public int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
