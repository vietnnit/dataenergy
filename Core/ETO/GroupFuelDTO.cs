using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class GroupFuel
	{

	#region Constructor
	public GroupFuel()
	{}
	
	public GroupFuel(GroupFuelBO groupfuelBO)
	{
			this.Title = groupfuelBO.Title;
			this.Id = groupfuelBO.Id;
			this.SortOrder = groupfuelBO.SortOrder;
			this.GroupCode = groupfuelBO.GroupCode;
			this.MeasurementName = groupfuelBO.MeasurementName;
	}
	#endregion

	#region Private Variables
	private string _Title;
	private int _Id;
	private int _SortOrder;
	private string _GroupCode;
	private string _MeasurementName;
	private int _Total;
	#endregion

	#region Public Properties
	
	public string Title
	{ 
		get { return _Title; }
		set { _Title = value; }
	}
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value; }
	}
	public string GroupCode
	{ 
		get { return _GroupCode; }
		set { _GroupCode = value; }
	}
	public string MeasurementName
	{ 
		get { return _MeasurementName; }
		set { _MeasurementName = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
