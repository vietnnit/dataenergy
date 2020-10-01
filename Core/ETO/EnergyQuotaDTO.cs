using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class EnergyQuota
	{

	#region Constructor
	public EnergyQuota()
	{}
	
	public EnergyQuota(EnergyQuotaBO energyquotaBO)
	{
			this.Id = energyquotaBO.Id;
			this.ProductId = energyquotaBO.ProductId;
			this.MeasurementId = energyquotaBO.MeasurementId;
			this.Quantity = energyquotaBO.Quantity;
			this.FuelId = energyquotaBO.FuelId;
			this.PlanOfYear = energyquotaBO.PlanOfYear;
			this.AuditReportId = energyquotaBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProductId;
	private int _MeasurementId;
	private decimal _Quantity;
	private int _FuelId;
	private int _PlanOfYear;
	private int _AuditReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value; }
	}
	public int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value; }
	}
	public decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	public int PlanOfYear
	{ 
		get { return _PlanOfYear; }
		set { _PlanOfYear = value; }
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
