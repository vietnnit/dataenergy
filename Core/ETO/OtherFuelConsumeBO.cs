using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class OtherFuelConsumeBO : BaseEntity
	{

	#region Constructor
	public OtherFuelConsumeBO()
	{}
	

	public OtherFuelConsumeBO(OtherFuelConsume otherfuelconsumeDTO)
	{
		this.Id = otherfuelconsumeDTO.Id;
		this.FuelId = otherfuelconsumeDTO.FuelId;
		this.MeasurementId = otherfuelconsumeDTO.MeasurementId;
		this.Quantity = otherfuelconsumeDTO.Quantity;
		this.Cost = otherfuelconsumeDTO.Cost;
		this.AuditReportId = otherfuelconsumeDTO.AuditReportId;
		this.MonthUsed = otherfuelconsumeDTO.MonthUsed;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_OtherFuelConsume"; }
		set { base.TableName = "DE_OtherFuelConsume"; }
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
	[FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value;SetDirty("MeasurementId"); }
	}
	[FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value;SetDirty("Quantity"); }
	}
	[FieldName("Cost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Cost
	{ 
		get { return _Cost; }
		set { _Cost = value;SetDirty("Cost"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("MonthUsed", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MonthUsed
	{ 
		get { return _MonthUsed; }
		set { _MonthUsed = value;SetDirty("MonthUsed"); }
	}
	#endregion

	}
}
