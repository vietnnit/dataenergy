using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ElectricMotors
	{

	#region Constructor
	public ElectricMotors()
	{}
	
	public ElectricMotors(ElectricMotorsBO electricmotorsBO)
	{
			this.Id = electricmotorsBO.Id;
			this.ElectricMotorsName = electricmotorsBO.ElectricMotorsName;
			this.Capacity = electricmotorsBO.Capacity;
			this.CapacityUsed = electricmotorsBO.CapacityUsed;
			this.OperationHours = electricmotorsBO.OperationHours;
			this.Quantity = electricmotorsBO.Quantity;
			this.AuditReportId = electricmotorsBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _ElectricMotorsName;
	private decimal _Capacity;
	private decimal _CapacityUsed;
	private int _OperationHours;
	private int _Quantity;
	private int _AuditReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string ElectricMotorsName
	{ 
		get { return _ElectricMotorsName; }
		set { _ElectricMotorsName = value; }
	}
	public decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value; }
	}
	public decimal CapacityUsed
	{ 
		get { return _CapacityUsed; }
		set { _CapacityUsed = value; }
	}
	public int OperationHours
	{ 
		get { return _OperationHours; }
		set { _OperationHours = value; }
	}
	public int Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
