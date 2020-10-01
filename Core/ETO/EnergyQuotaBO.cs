using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class EnergyQuotaBO : BaseEntity
	{

	#region Constructor
	public EnergyQuotaBO()
	{}
	

	public EnergyQuotaBO(EnergyQuota energyquotaDTO)
	{
		this.Id = energyquotaDTO.Id;
		this.ProductId = energyquotaDTO.ProductId;
		this.MeasurementId = energyquotaDTO.MeasurementId;
		this.Quantity = energyquotaDTO.Quantity;
		this.FuelId = energyquotaDTO.FuelId;
		this.PlanOfYear = energyquotaDTO.PlanOfYear;
		this.AuditReportId = energyquotaDTO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProductId;
	private int _MeasurementId;
	private decimal _Quantity;
	private int _FuelId;
	private int _PlanOfYear;
	private int _AuditReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_EnergyQuota"; }
		set { base.TableName = "DE_EnergyQuota"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ProductId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value;SetDirty("ProductId"); }
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
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("PlanOfYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int PlanOfYear
	{ 
		get { return _PlanOfYear; }
		set { _PlanOfYear = value;SetDirty("PlanOfYear"); }
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
