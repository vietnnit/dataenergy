using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class MemberBO : BaseEntity
	{

	#region Constructor
	public MemberBO()
	{}
	

	public MemberBO(Member memberDTO)
	{
		this.Id = memberDTO.Id;
		this.AccountName = memberDTO.AccountName;
		this.Password = memberDTO.Password;
		this.IsDelete = memberDTO.IsDelete;
		this.EnterpriseId = memberDTO.EnterpriseId;
		this.IsActive = memberDTO.IsActive;
		this.FullName = memberDTO.FullName;
		this.Email = memberDTO.Email;
		this.Address = memberDTO.Address;
		this.Phone = memberDTO.Phone;
		this.Created = memberDTO.Created;
		this.LastLogin = memberDTO.LastLogin;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Member"; }
		set { base.TableName = "DE_Member"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("AccountName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AccountName
	{ 
		get { return _AccountName; }
		set { _AccountName = value;SetDirty("AccountName"); }
	}
	[FieldName("Password", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Password
	{ 
		get { return _Password; }
		set { _Password = value;SetDirty("Password"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("IsActive", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value;SetDirty("IsActive"); }
	}
	[FieldName("FullName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FullName
	{ 
		get { return _FullName; }
		set { _FullName = value;SetDirty("FullName"); }
	}
	[FieldName("Email", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Email
	{ 
		get { return _Email; }
		set { _Email = value;SetDirty("Email"); }
	}
	[FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Address
	{ 
		get { return _Address; }
		set { _Address = value;SetDirty("Address"); }
	}
	[FieldName("Phone", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value;SetDirty("Phone"); }
	}
	[FieldName("Created", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value;SetDirty("Created"); }
	}
	[FieldName("LastLogin", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime LastLogin
	{ 
		get { return _LastLogin; }
		set { _LastLogin = value;SetDirty("LastLogin"); }
	}
	#endregion

	}
}
