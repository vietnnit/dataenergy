using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ReportFuelDetailBO : BaseEntity
	{

	#region Constructor
	public ReportFuelDetailBO()
	{}
	

	public ReportFuelDetailBO(ReportFuelDetail reportfueldetailDTO)
	{
		this.Id = reportfueldetailDTO.Id;
		this.FuelId = reportfueldetailDTO.FuelId;
		this.NoFuel = reportfueldetailDTO.NoFuel;
		this.NoFuel_TOE = reportfueldetailDTO.NoFuel_TOE;
		this.ReportId = reportfueldetailDTO.ReportId;
		this.EnterpriseId = reportfueldetailDTO.EnterpriseId;
		this.Year = reportfueldetailDTO.Year;
		this.Reason = reportfueldetailDTO.Reason;
		this.IsNextYear = reportfueldetailDTO.IsNextYear;
		this.GroupFuelId = reportfueldetailDTO.GroupFuelId;
		this.MeasurementId = reportfueldetailDTO.MeasurementId;
		this.No_RateTOE = reportfueldetailDTO.No_RateTOE;
		this.Price = reportfueldetailDTO.Price;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ReportFuelDetail"; }
		set { base.TableName = "DE_ReportFuelDetail"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("NoFuel", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal NoFuel
	{ 
		get { return _NoFuel; }
		set { _NoFuel = value;SetDirty("NoFuel"); }
	}
	[FieldName("NoFuel_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal NoFuel_TOE
	{ 
		get { return _NoFuel_TOE; }
		set { _NoFuel_TOE = value;SetDirty("NoFuel_TOE"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Year
	{ 
		get { return _Year; }
		set { _Year = value;SetDirty("Year"); }
	}
	[FieldName("Reason", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Reason
	{ 
		get { return _Reason; }
		set { _Reason = value;SetDirty("Reason"); }
	}
	[FieldName("IsNextYear", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsNextYear
	{ 
		get { return _IsNextYear; }
		set { _IsNextYear = value;SetDirty("IsNextYear"); }
	}
	[FieldName("GroupFuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int GroupFuelId
	{ 
		get { return _GroupFuelId; }
		set { _GroupFuelId = value;SetDirty("GroupFuelId"); }
	}
	[FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value;SetDirty("MeasurementId"); }
	}
	[FieldName("No_RateTOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal No_RateTOE
	{ 
		get { return _No_RateTOE; }
		set { _No_RateTOE = value;SetDirty("No_RateTOE"); }
	}
	[FieldName("Price", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Price
	{ 
		get { return _Price; }
		set { _Price = value;SetDirty("Price"); }
	}
	#endregion

	}
}
