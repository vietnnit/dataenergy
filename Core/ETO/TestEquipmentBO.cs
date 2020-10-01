using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class TestEquipmentBO : BaseEntity
	{

	#region Constructor
	public TestEquipmentBO()
	{}
	

	public TestEquipmentBO(TestEquipment testequipmentDTO)
	{
		this.Id = testequipmentDTO.Id;
		this.DeviceName = testequipmentDTO.DeviceName;
		this.Measurement = testequipmentDTO.Measurement;
		this.Quantity = testequipmentDTO.Quantity;
		this.MadeIn = testequipmentDTO.MadeIn;
		this.AuditReportId = testequipmentDTO.AuditReportId;
		this.SerialNo = testequipmentDTO.SerialNo;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _DeviceName;
	private string _Measurement;
	private int _Quantity;
	private string _MadeIn;
	private int _AuditReportId;
	private string _SerialNo;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_TestEquipment"; }
		set { base.TableName = "DE_TestEquipment"; }
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
	[FieldName("Measurement", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Measurement
	{ 
		get { return _Measurement; }
		set { _Measurement = value;SetDirty("Measurement"); }
	}
	[FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value;SetDirty("Quantity"); }
	}
	[FieldName("MadeIn", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string MadeIn
	{ 
		get { return _MadeIn; }
		set { _MadeIn = value;SetDirty("MadeIn"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("SerialNo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string SerialNo
	{ 
		get { return _SerialNo; }
		set { _SerialNo = value;SetDirty("SerialNo"); }
	}
	#endregion

	}
}
