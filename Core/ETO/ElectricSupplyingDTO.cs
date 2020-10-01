using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ElectricSupplying
	{

	#region Constructor
	public ElectricSupplying()
	{}
	
	public ElectricSupplying(ElectricSupplyingBO electricsupplyingBO)
	{
			this.Id = electricsupplyingBO.Id;
			this.DeviceName = electricsupplyingBO.DeviceName;
			this.PlacingCapacity = electricsupplyingBO.PlacingCapacity;
			this.VoltageLevel = electricsupplyingBO.VoltageLevel;
			this.Coefficient = electricsupplyingBO.Coefficient;
			this.IsSelf = electricsupplyingBO.IsSelf;
			this.AuditReportId = electricsupplyingBO.AuditReportId;
			this.Capacity = electricsupplyingBO.Capacity;
			this.Performance = electricsupplyingBO.Performance;
			this.RateOfSystem = electricsupplyingBO.RateOfSystem;
			this.Cos = electricsupplyingBO.Cos;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _DeviceName;
	private int _PlacingCapacity;
	private string _VoltageLevel;
	private decimal _Coefficient;
	private bool _IsSelf;
	private int _AuditReportId;
	private int _Capacity;
	private decimal _Performance;
	private decimal _RateOfSystem;
	private decimal _Cos;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string DeviceName
	{ 
		get { return _DeviceName; }
		set { _DeviceName = value; }
	}
	public int PlacingCapacity
	{ 
		get { return _PlacingCapacity; }
		set { _PlacingCapacity = value; }
	}
	public string VoltageLevel
	{ 
		get { return _VoltageLevel; }
		set { _VoltageLevel = value; }
	}
	public decimal Coefficient
	{ 
		get { return _Coefficient; }
		set { _Coefficient = value; }
	}
	public bool IsSelf
	{ 
		get { return _IsSelf; }
		set { _IsSelf = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public int Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value; }
	}
	public decimal Performance
	{ 
		get { return _Performance; }
		set { _Performance = value; }
	}
	public decimal RateOfSystem
	{ 
		get { return _RateOfSystem; }
		set { _RateOfSystem = value; }
	}
	public decimal Cos
	{ 
		get { return _Cos; }
		set { _Cos = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
