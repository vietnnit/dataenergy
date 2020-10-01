using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Boiler
	{

	#region Constructor
	public Boiler()
	{}
	
	public Boiler(BoilerBO boilerBO)
	{
			this.Id = boilerBO.Id;
			this.BoilerName = boilerBO.BoilerName;
			this.FuelId = boilerBO.FuelId;
			this.CapacityInstalled = boilerBO.CapacityInstalled;
			this.OperationHours = boilerBO.OperationHours;
			this.Quantity = boilerBO.Quantity;
			this.AuditReportId = boilerBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _BoilerName;
	private int _FuelId;
	private decimal _CapacityInstalled;
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
	public string BoilerName
	{ 
		get { return _BoilerName; }
		set { _BoilerName = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	public decimal CapacityInstalled
	{ 
		get { return _CapacityInstalled; }
		set { _CapacityInstalled = value; }
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
