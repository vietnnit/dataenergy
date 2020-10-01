using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace PR.Domain
{
	public class ProjectAreaBO : BaseEntity
	{

	#region Constructor
	public ProjectAreaBO()
	{}
	

	public ProjectAreaBO(ProjectArea projectareaDTO)
	{
		this.Id = projectareaDTO.Id;
		this.AreaName = projectareaDTO.AreaName;
		this.IsDelete = projectareaDTO.IsDelete;
		this.IsActive = projectareaDTO.IsActive;
		this.SortOrder = projectareaDTO.SortOrder;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
	private bool _IsDelete;
	private bool _IsActive;
	private int _SortOrder;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "PR_ProjectArea"; }
		set { base.TableName = "PR_ProjectArea"; }
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
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("IsActive", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value;SetDirty("IsActive"); }
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
