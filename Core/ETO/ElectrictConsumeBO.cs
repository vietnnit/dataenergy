using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ElectrictConsumeBO : BaseEntity
	{

	#region Constructor
	public ElectrictConsumeBO()
	{}
	

	public ElectrictConsumeBO(ElectrictConsume electrictconsumeDTO)
	{
		this.Id = electrictconsumeDTO.Id;
		this.Month = electrictconsumeDTO.Month;
		this.Year = electrictconsumeDTO.Year;
		this.NormalNo = electrictconsumeDTO.NormalNo;
		this.NormalCost = electrictconsumeDTO.NormalCost;
		this.PeakNo = electrictconsumeDTO.PeakNo;
		this.PeakCost = electrictconsumeDTO.PeakCost;
		this.LowNo = electrictconsumeDTO.LowNo;
		this.LowCost = electrictconsumeDTO.LowCost;
		this.ElectrictTotal = electrictconsumeDTO.ElectrictTotal;
		this.CostTotal = electrictconsumeDTO.CostTotal;
		this.AuditReportId = electrictconsumeDTO.AuditReportId;
		this.IsSelf = electrictconsumeDTO.IsSelf;
		this.FuelId = electrictconsumeDTO.FuelId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _Month;
	private int _Year;
	private long _NormalNo;
	private long _NormalCost;
	private long _PeakNo;
	private long _PeakCost;
	private long _LowNo;
	private long _LowCost;
	private long _ElectrictTotal;
	private long _CostTotal;
	private int _AuditReportId;
	private bool _IsSelf;
	private int _FuelId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ElectrictConsume"; }
		set { base.TableName = "DE_ElectrictConsume"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("Month", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Month
	{ 
		get { return _Month; }
		set { _Month = value;SetDirty("Month"); }
	}
	[FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Year
	{ 
		get { return _Year; }
		set { _Year = value;SetDirty("Year"); }
	}
	[FieldName("NormalNo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long NormalNo
	{ 
		get { return _NormalNo; }
		set { _NormalNo = value;SetDirty("NormalNo"); }
	}
	[FieldName("NormalCost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long NormalCost
	{ 
		get { return _NormalCost; }
		set { _NormalCost = value;SetDirty("NormalCost"); }
	}
	[FieldName("PeakNo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long PeakNo
	{ 
		get { return _PeakNo; }
		set { _PeakNo = value;SetDirty("PeakNo"); }
	}
	[FieldName("PeakCost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long PeakCost
	{ 
		get { return _PeakCost; }
		set { _PeakCost = value;SetDirty("PeakCost"); }
	}
	[FieldName("LowNo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long LowNo
	{ 
		get { return _LowNo; }
		set { _LowNo = value;SetDirty("LowNo"); }
	}
	[FieldName("LowCost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long LowCost
	{ 
		get { return _LowCost; }
		set { _LowCost = value;SetDirty("LowCost"); }
	}
	[FieldName("ElectrictTotal", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long ElectrictTotal
	{ 
		get { return _ElectrictTotal; }
		set { _ElectrictTotal = value;SetDirty("ElectrictTotal"); }
	}
	[FieldName("CostTotal", FieldAccessMode.ReadWrite, FieldType.String)]
	public  long CostTotal
	{ 
		get { return _CostTotal; }
		set { _CostTotal = value;SetDirty("CostTotal"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("IsSelf", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsSelf
	{ 
		get { return _IsSelf; }
		set { _IsSelf = value;SetDirty("IsSelf"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	#endregion

	}
}
