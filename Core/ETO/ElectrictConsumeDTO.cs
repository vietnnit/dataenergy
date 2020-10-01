using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ElectrictConsume
	{

	#region Constructor
	public ElectrictConsume()
	{}
	
	public ElectrictConsume(ElectrictConsumeBO electrictconsumeBO)
	{
			this.Id = electrictconsumeBO.Id;
			this.Month = electrictconsumeBO.Month;
			this.Year = electrictconsumeBO.Year;
			this.NormalNo = electrictconsumeBO.NormalNo;
			this.NormalCost = electrictconsumeBO.NormalCost;
			this.PeakNo = electrictconsumeBO.PeakNo;
			this.PeakCost = electrictconsumeBO.PeakCost;
			this.LowNo = electrictconsumeBO.LowNo;
			this.LowCost = electrictconsumeBO.LowCost;
			this.ElectrictTotal = electrictconsumeBO.ElectrictTotal;
			this.CostTotal = electrictconsumeBO.CostTotal;
			this.AuditReportId = electrictconsumeBO.AuditReportId;
			this.IsSelf = electrictconsumeBO.IsSelf;
			this.FuelId = electrictconsumeBO.FuelId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _Month;
	private int _Year;
	private long _NormalNo;
	private long _NormalCost;
	private long _PeakNo;
	private long _PeakCost;
	private long _LowNo;
	private long _LowCost;
	private long _ElectrictTotal;
	private long _CostTotal;
	private int _AuditReportId;
	private bool _IsSelf;
	private int _FuelId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int Month
	{ 
		get { return _Month; }
		set { _Month = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	public long NormalNo
	{ 
		get { return _NormalNo; }
		set { _NormalNo = value; }
	}
	public long NormalCost
	{ 
		get { return _NormalCost; }
		set { _NormalCost = value; }
	}
	public long PeakNo
	{ 
		get { return _PeakNo; }
		set { _PeakNo = value; }
	}
	public long PeakCost
	{ 
		get { return _PeakCost; }
		set { _PeakCost = value; }
	}
	public long LowNo
	{ 
		get { return _LowNo; }
		set { _LowNo = value; }
	}
	public long LowCost
	{ 
		get { return _LowCost; }
		set { _LowCost = value; }
	}
	public long ElectrictTotal
	{ 
		get { return _ElectrictTotal; }
		set { _ElectrictTotal = value; }
	}
	public long CostTotal
	{ 
		get { return _CostTotal; }
		set { _CostTotal = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public bool IsSelf
	{ 
		get { return _IsSelf; }
		set { _IsSelf = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
