using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Region
	{

	#region Constructor
	public Region()
	{}
	
	public Region(RegionBO regionBO)
	{
			this.RegionName = regionBO.RegionName;
			this.Id = regionBO.Id;
			this.SortOrder = regionBO.SortOrder;
	}
	#endregion

	#region Private Variables
	private string _RegionName;
	private int _Id;
	private int _SortOrder;
	private int _Total;
	#endregion

	#region Public Properties
	
	public string RegionName
	{ 
		get { return _RegionName; }
		set { _RegionName = value; }
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
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
