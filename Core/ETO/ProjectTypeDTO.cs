using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace PR.Domain
{
	public class ProjectType
	{

	#region Constructor
	public ProjectType()
	{}
	
	public ProjectType(ProjectTypeBO projecttypeBO)
	{
			this.Id = projecttypeBO.Id;
			this.TypeName = projecttypeBO.TypeName;
			this.IsDelete = projecttypeBO.IsDelete;
			this.IsActive = projecttypeBO.IsActive;
			this.SortOrder = projecttypeBO.SortOrder;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _TypeName;
	private bool _IsDelete;
	private bool _IsActive;
	private int _SortOrder;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string TypeName
	{ 
		get { return _TypeName; }
		set { _TypeName = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value; }
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
