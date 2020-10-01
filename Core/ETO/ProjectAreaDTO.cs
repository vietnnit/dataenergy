using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace PR.Domain
{
	public class ProjectArea
	{

	#region Constructor
	public ProjectArea()
	{}
	
	public ProjectArea(ProjectAreaBO projectareaBO)
	{
			this.Id = projectareaBO.Id;
			this.AreaName = projectareaBO.AreaName;
			this.IsDelete = projectareaBO.IsDelete;
			this.IsActive = projectareaBO.IsActive;
			this.SortOrder = projectareaBO.SortOrder;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
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
	public string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value; }
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
