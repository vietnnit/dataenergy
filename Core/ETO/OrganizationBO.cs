using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class OrganizationBO : BaseEntity
	{

	#region Constructor
	public OrganizationBO()
	{}
	

	public OrganizationBO(Organization organizationDTO)
	{
		this.Id = organizationDTO.Id;
		this.Title = organizationDTO.Title;
		this.ProvinceId = organizationDTO.ProvinceId;
		this.Address = organizationDTO.Address;
		this.Note = organizationDTO.Note;
		this.Phone = organizationDTO.Phone;
		this.Email = organizationDTO.Email;
		this.IsActive = organizationDTO.IsActive;
		this.IsDelete = organizationDTO.IsDelete;
		this.SortOrder = organizationDTO.SortOrder;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Organization"; }
		set { base.TableName = "DE_Organization"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("Title", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Title
	{ 
		get { return _Title; }
		set { _Title = value;SetDirty("Title"); }
	}
	[FieldName("ProvinceId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProvinceId
	{ 
		get { return _ProvinceId; }
		set { _ProvinceId = value;SetDirty("ProvinceId"); }
	}
	[FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Address
	{ 
		get { return _Address; }
		set { _Address = value;SetDirty("Address"); }
	}
	[FieldName("Note", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Note
	{ 
		get { return _Note; }
		set { _Note = value;SetDirty("Note"); }
	}
	[FieldName("Phone", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value;SetDirty("Phone"); }
	}
	[FieldName("Email", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Email
	{ 
		get { return _Email; }
		set { _Email = value;SetDirty("Email"); }
	}
	[FieldName("IsActive", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value;SetDirty("IsActive"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("SortOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value;SetDirty("SortOrder"); }
	}
	#endregion

	}
}
