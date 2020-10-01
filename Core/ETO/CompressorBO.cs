using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class CompressorBO : BaseEntity
	{

	#region Constructor
	public CompressorBO()
	{}
	

	public CompressorBO(Compressor compressorDTO)
	{
		this.Id = compressorDTO.Id;
		this.CompressorName = compressorDTO.CompressorName;
		this.Pressure = compressorDTO.Pressure;
		this.Capacity = compressorDTO.Capacity;
		this.PressureLV = compressorDTO.PressureLV;
		this.OperationHours = compressorDTO.OperationHours;
		this.Quantity = compressorDTO.Quantity;
		this.AuditReportId = compressorDTO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _CompressorName;
	private decimal _Pressure;
	private decimal _Capacity;
	private decimal _PressureLV;
	private int _OperationHours;
	private int _Quantity;
	private int _AuditReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Compressor"; }
		set { base.TableName = "DE_Compressor"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("CompressorName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string CompressorName
	{ 
		get { return _CompressorName; }
		set { _CompressorName = value;SetDirty("CompressorName"); }
	}
	[FieldName("Pressure", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Pressure
	{ 
		get { return _Pressure; }
		set { _Pressure = value;SetDirty("Pressure"); }
	}
	[FieldName("Capacity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value;SetDirty("Capacity"); }
	}
	[FieldName("PressureLV", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal PressureLV
	{ 
		get { return _PressureLV; }
		set { _PressureLV = value;SetDirty("PressureLV"); }
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
