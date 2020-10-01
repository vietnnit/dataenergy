using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class OtherFuelConsume
	{

	#region Constructor
	public OtherFuelConsume()
	{}
	
	public OtherFuelConsume(OtherFuelConsumeBO otherfuelconsumeBO)
	{
			this.Id = otherfuelconsumeBO.Id;
			this.FuelId = otherfuelconsumeBO.FuelId;
			this.MeasurementId = otherfuelconsumeBO.MeasurementId;
			this.Quantity = otherfuelconsumeBO.Quantity;
			this.Cost = otherfuelconsumeBO.Cost;
			this.AuditReportId = otherfuelconsumeBO.AuditReportId;
			this.MonthUsed = otherfuelconsumeBO.MonthUsed;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _FuelId;
	private int _MeasurementId;
	private decimal _Quantity;
	private decimal _Cost;
	private int _AuditReportId;
	private int _MonthUsed;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
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
	public decimal Cost
	{ 
		get { return _Cost; }
		set { _Cost = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public int MonthUsed
	{ 
		get { return _MonthUsed; }
		set { _MonthUsed = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
