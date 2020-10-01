using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class BoilerBO : BaseEntity
	{

	#region Constructor
	public BoilerBO()
	{}
	

	public BoilerBO(Boiler boilerDTO)
	{
		this.Id = boilerDTO.Id;
		this.BoilerName = boilerDTO.BoilerName;
		this.FuelId = boilerDTO.FuelId;
		this.CapacityInstalled = boilerDTO.CapacityInstalled;
		this.OperationHours = boilerDTO.OperationHours;
		this.Quantity = boilerDTO.Quantity;
		this.AuditReportId = boilerDTO.AuditReportId;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Boiler"; }
		set { base.TableName = "DE_Boiler"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("BoilerName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string BoilerName
	{ 
		get { return _BoilerName; }
		set { _BoilerName = value;SetDirty("BoilerName"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("CapacityInstalled", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal CapacityInstalled
	{ 
		get { return _CapacityInstalled; }
		set { _CapacityInstalled = value;SetDirty("CapacityInstalled"); }
	}
	[FieldName("OperationHours", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OperationHours
	{ 
		get { return _OperationHours; }
		set { _OperationHours = value;SetDirty("OperationHours"); }
	}
	[FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value;SetDirty("Quantity"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	#endregion

	}
}
