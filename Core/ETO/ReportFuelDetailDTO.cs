using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ReportFuelDetail
	{

	#region Constructor
	public ReportFuelDetail()
	{}
	
	public ReportFuelDetail(ReportFuelDetailBO reportfueldetailBO)
	{
			this.Id = reportfueldetailBO.Id;
			this.FuelId = reportfueldetailBO.FuelId;
			this.NoFuel = reportfueldetailBO.NoFuel;
			this.NoFuel_TOE = reportfueldetailBO.NoFuel_TOE;
			this.ReportId = reportfueldetailBO.ReportId;
			this.EnterpriseId = reportfueldetailBO.EnterpriseId;
			this.Year = reportfueldetailBO.Year;
			this.Reason = reportfueldetailBO.Reason;
			this.IsNextYear = reportfueldetailBO.IsNextYear;
			this.GroupFuelId = reportfueldetailBO.GroupFuelId;
			this.MeasurementId = reportfueldetailBO.MeasurementId;
			this.No_RateTOE = reportfueldetailBO.No_RateTOE;
			this.Price = reportfueldetailBO.Price;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _FuelId;
	private decimal _NoFuel;
	private decimal _NoFuel_TOE;
	private int _ReportId;
	private int _EnterpriseId;
	private int _Year;
	private string _Reason;
	private bool _IsNextYear;
	private int _GroupFuelId;
	private int _MeasurementId;
	private decimal _No_RateTOE;
	private decimal _Price;
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
	public decimal NoFuel
	{ 
		get { return _NoFuel; }
		set { _NoFuel = value; }
	}
	public decimal NoFuel_TOE
	{ 
		get { return _NoFuel_TOE; }
		set { _NoFuel_TOE = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	public string Reason
	{ 
		get { return _Reason; }
		set { _Reason = value; }
	}
	public bool IsNextYear
	{ 
		get { return _IsNextYear; }
		set { _IsNextYear = value; }
	}
	public int GroupFuelId
	{ 
		get { return _GroupFuelId; }
		set { _GroupFuelId = value; }
	}
	public int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value; }
	}
	public decimal No_RateTOE
	{ 
		get { return _No_RateTOE; }
		set { _No_RateTOE = value; }
	}
	public decimal Price
	{ 
		get { return _Price; }
		set { _Price = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
