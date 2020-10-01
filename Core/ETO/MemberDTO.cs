using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Member
	{

	#region Constructor
	public Member()
	{}
	
	public Member(MemberBO memberBO)
	{
			this.Id = memberBO.Id;
			this.AccountName = memberBO.AccountName;
			this.Password = memberBO.Password;
			this.IsDelete = memberBO.IsDelete;
			this.EnterpriseId = memberBO.EnterpriseId;
			this.IsActive = memberBO.IsActive;
			this.FullName = memberBO.FullName;
			this.Email = memberBO.Email;
			this.Address = memberBO.Address;
			this.Phone = memberBO.Phone;
			this.Created = memberBO.Created;
			this.LastLogin = memberBO.LastLogin;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AccountName;
	private string _Password;
	private bool _IsDelete;
	private int _EnterpriseId;
	private bool _IsActive;
	private string _FullName;
	private string _Email;
	private string _Address;
	private string _Phone;
	private System.DateTime _Created;
	private System.DateTime _LastLogin;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string AccountName
	{ 
		get { return _AccountName; }
		set { _AccountName = value; }
	}
	public string Password
	{ 
		get { return _Password; }
		set { _Password = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value; }
	}
	public string FullName
	{ 
		get { return _FullName; }
		set { _FullName = value; }
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
	public string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value; }
	}
	public System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value; }
	}
	public System.DateTime LastLogin
	{ 
		get { return _LastLogin; }
		set { _LastLogin = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
