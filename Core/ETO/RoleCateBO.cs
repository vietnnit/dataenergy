using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ETO
{
	public class RoleCateBO : BaseEntity
	{

	#region Constructor
	public RoleCateBO()
	{}
	

	public RoleCateBO(RoleCate rolecateDTO)
	{
		this.Id = rolecateDTO.Id;
		this.CateId = rolecateDTO.CateId;
		this.GroupId = rolecateDTO.GroupId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _CateId;
	private int _GroupId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "tblRoleCate"; }
		set { base.TableName = "tblRoleCate"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("CateId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int CateId
	{ 
		get { return _CateId; }
		set { _CateId = value;SetDirty("CateId"); }
	}
	[FieldName("GroupId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int GroupId
	{ 
		get { return _GroupId; }
		set { _GroupId = value;SetDirty("GroupId"); }
	}
	#endregion

	}
}
