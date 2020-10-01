using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class FurnacesBO : BaseEntity
	{

	#region Constructor
	public FurnacesBO()
	{}
	

	public FurnacesBO(Furnaces furnacesDTO)
	{
		this.Id = furnacesDTO.Id;
		this.DeviceName = furnacesDTO.DeviceName;
		this.FuelId = furnacesDTO.FuelId;
		this.CapacityInstalled = furnacesDTO.CapacityInstalled;
		this.OperationHours = furnacesDTO.OperationHours;
		this.Quantity = furnacesDTO.Quantity;
		this.AuditReportId = furnacesDTO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _DeviceName;
	private int _FuelId;
	private decimal _CapacityInstalled;
	private int _OperationHours;
	private int _Quantity;
	private int _AuditReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Furnaces"; }
		set { base.TableName = "DE_Furnaces"; }
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
