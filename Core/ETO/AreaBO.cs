using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class AreaBO : BaseEntity
	{

	#region Constructor
	public AreaBO()
	{}
	

	public AreaBO(Area areaDTO)
	{
		this.Id = areaDTO.Id;
		this.AreaName = areaDTO.AreaName;
		this.ParentId = areaDTO.ParentId;
		this.IsStatus = areaDTO.IsStatus;
		this.SortOrder = areaDTO.SortOrder;
		this.IsDelete = areaDTO.IsDelete;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
	private int _ParentId;
	private int _IsStatus;
	private int _SortOrder;
	private bool _IsDelete;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Area"; }
		set { base.TableName = "DE_Area"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("AreaName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value;SetDirty("AreaName"); }
	}
	[FieldName("ParentId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ParentId
	{ 
		get { return _ParentId; }
		set { _ParentId = value;SetDirty("ParentId"); }
	}
	[FieldName("IsStatus", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int IsStatus
	{ 
		get { return _IsStatus; }
		set { _IsStatus = value;SetDirty("IsStatus"); }
	}
	[FieldName("SortOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value;SetDirty("SortOrder"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	#endregion

	}
}
