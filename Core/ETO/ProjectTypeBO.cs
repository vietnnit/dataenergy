using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace PR.Domain
{
	public class ProjectTypeBO : BaseEntity
	{

	#region Constructor
	public ProjectTypeBO()
	{}
	

	public ProjectTypeBO(ProjectType projecttypeDTO)
	{
		this.Id = projecttypeDTO.Id;
		this.TypeName = projecttypeDTO.TypeName;
		this.IsDelete = projecttypeDTO.IsDelete;
		this.IsActive = projecttypeDTO.IsActive;
		this.SortOrder = projecttypeDTO.SortOrder;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _TypeName;
	private bool _IsDelete;
	private bool _IsActive;
	private int _SortOrder;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "PR_ProjectType"; }
		set { base.TableName = "PR_ProjectType"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("TypeName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string TypeName
	{ 
		get { return _TypeName; }
		set { _TypeName = value;SetDirty("TypeName"); }
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
