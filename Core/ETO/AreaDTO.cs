using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Area
	{

	#region Constructor
	public Area()
	{}
	
	public Area(AreaBO areaBO)
	{
			this.Id = areaBO.Id;
			this.AreaName = areaBO.AreaName;
			this.ParentId = areaBO.ParentId;
			this.IsStatus = areaBO.IsStatus;
			this.SortOrder = areaBO.SortOrder;
			this.IsDelete = areaBO.IsDelete;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
	private int _ParentId;
	private int _IsStatus;
	private int _SortOrder;
	private bool _IsDelete;
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
	public int ParentId
	{ 
		get { return _ParentId; }
		set { _ParentId = value; }
	}
	public int IsStatus
	{ 
		get { return _IsStatus; }
		set { _IsStatus = value; }
	}
	public int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
