using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class SaveSolution
	{

	#region Constructor
	public SaveSolution()
	{}
	
	public SaveSolution(SaveSolutionBO savesolutionBO)
	{
			this.Id = savesolutionBO.Id;
			this.SolutionId = savesolutionBO.SolutionId;
			this.Purpose = savesolutionBO.Purpose;
			this.EnterpriseId = savesolutionBO.EnterpriseId;
			this.FuelId = savesolutionBO.FuelId;
			this.AuditReportId = savesolutionBO.AuditReportId;
			this.MeasurementFuelId = savesolutionBO.MeasurementFuelId;
			this.Quantity = savesolutionBO.Quantity;
			this.Cost = savesolutionBO.Cost;
			this.Budget = savesolutionBO.Budget;
			this.TimeExecuted = savesolutionBO.TimeExecuted;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _SolutionId;
	private string _Purpose;
	private int _EnterpriseId;
	private int _FuelId;
	private int _AuditReportId;
	private int _MeasurementFuelId;
	private decimal _Quantity;
	private decimal _Cost;
	private decimal _Budget;
	private decimal _TimeExecuted;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int SolutionId
	{ 
		get { return _SolutionId; }
		set { _SolutionId = value; }
	}
	public string Purpose
	{ 
		get { return _Purpose; }
		set { _Purpose = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public int MeasurementFuelId
	{ 
		get { return _MeasurementFuelId; }
		set { _MeasurementFuelId = value; }
	}
	public decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public decimal Cost
	{ 
		get { return _Cost; }
		set { _Cost = value; }
	}
	public decimal Budget
	{ 
		get { return _Budget; }
		set { _Budget = value; }
	}
	public decimal TimeExecuted
	{ 
		get { return _TimeExecuted; }
		set { _TimeExecuted = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
