using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ElectricSupplyingBO : BaseEntity
	{

	#region Constructor
	public ElectricSupplyingBO()
	{}
	

	public ElectricSupplyingBO(ElectricSupplying electricsupplyingDTO)
	{
		this.Id = electricsupplyingDTO.Id;
		this.DeviceName = electricsupplyingDTO.DeviceName;
		this.PlacingCapacity = electricsupplyingDTO.PlacingCapacity;
		this.VoltageLevel = electricsupplyingDTO.VoltageLevel;
		this.Coefficient = electricsupplyingDTO.Coefficient;
		this.IsSelf = electricsupplyingDTO.IsSelf;
		this.AuditReportId = electricsupplyingDTO.AuditReportId;
		this.Capacity = electricsupplyingDTO.Capacity;
		this.Performance = electricsupplyingDTO.Performance;
		this.RateOfSystem = electricsupplyingDTO.RateOfSystem;
		this.Cos = electricsupplyingDTO.Cos;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _DeviceName;
	private int _PlacingCapacity;
	private string _VoltageLevel;
	private decimal _Coefficient;
	private bool _IsSelf;
	private int _AuditReportId;
	private int _Capacity;
	private decimal _Performance;
	private decimal _RateOfSystem;
	private decimal _Cos;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ElectricSupplying"; }
		set { base.TableName = "DE_ElectricSupplying"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("DeviceName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string DeviceName
	{ 
		get { return _DeviceName; }
		set { _DeviceName = value;SetDirty("DeviceName"); }
	}
	[FieldName("PlacingCapacity", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int PlacingCapacity
	{ 
		get { return _PlacingCapacity; }
		set { _PlacingCapacity = value;SetDirty("PlacingCapacity"); }
	}
	[FieldName("VoltageLevel", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string VoltageLevel
	{ 
		get { return _VoltageLevel; }
		set { _VoltageLevel = value;SetDirty("VoltageLevel"); }
	}
	[FieldName("Coefficient", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Coefficient
	{ 
		get { return _Coefficient; }
		set { _Coefficient = value;SetDirty("Coefficient"); }
	}
	[FieldName("IsSelf", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsSelf
	{ 
		get { return _IsSelf; }
		set { _IsSelf = value;SetDirty("IsSelf"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("Capacity", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value;SetDirty("Capacity"); }
	}
	[FieldName("Performance", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Performance
	{ 
		get { return _Performance; }
		set { _Performance = value;SetDirty("Performance"); }
	}
	[FieldName("RateOfSystem", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal RateOfSystem
	{ 
		get { return _RateOfSystem; }
		set { _RateOfSystem = value;SetDirty("RateOfSystem"); }
	}
	[FieldName("Cos", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Cos
	{ 
		get { return _Cos; }
		set { _Cos = value;SetDirty("Cos"); }
	}
	#endregion

	}
}
