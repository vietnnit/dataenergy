using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ElectricMotorsBO : BaseEntity
	{

	#region Constructor
	public ElectricMotorsBO()
	{}
	

	public ElectricMotorsBO(ElectricMotors electricmotorsDTO)
	{
		this.Id = electricmotorsDTO.Id;
		this.ElectricMotorsName = electricmotorsDTO.ElectricMotorsName;
		this.Capacity = electricmotorsDTO.Capacity;
		this.CapacityUsed = electricmotorsDTO.CapacityUsed;
		this.OperationHours = electricmotorsDTO.OperationHours;
		this.Quantity = electricmotorsDTO.Quantity;
		this.AuditReportId = electricmotorsDTO.AuditReportId;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ElectricMotors"; }
		set { base.TableName = "DE_ElectricMotors"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ElectricMotorsName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ElectricMotorsName
	{ 
		get { return _ElectricMotorsName; }
		set { _ElectricMotorsName = value;SetDirty("ElectricMotorsName"); }
	}
	[FieldName("Capacity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value;SetDirty("Capacity"); }
	}
	[FieldName("CapacityUsed", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal CapacityUsed
	{ 
		get { return _CapacityUsed; }
		set { _CapacityUsed = value;SetDirty("CapacityUsed"); }
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
