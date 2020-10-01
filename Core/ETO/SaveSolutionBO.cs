using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class SaveSolutionBO : BaseEntity
	{

	#region Constructor
	public SaveSolutionBO()
	{}
	

	public SaveSolutionBO(SaveSolution savesolutionDTO)
	{
		this.Id = savesolutionDTO.Id;
		this.SolutionId = savesolutionDTO.SolutionId;
		this.Purpose = savesolutionDTO.Purpose;
		this.EnterpriseId = savesolutionDTO.EnterpriseId;
		this.FuelId = savesolutionDTO.FuelId;
		this.AuditReportId = savesolutionDTO.AuditReportId;
		this.MeasurementFuelId = savesolutionDTO.MeasurementFuelId;
		this.Quantity = savesolutionDTO.Quantity;
		this.Cost = savesolutionDTO.Cost;
		this.Budget = savesolutionDTO.Budget;
		this.TimeExecuted = savesolutionDTO.TimeExecuted;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _SolutionId;
	private string _Purpose;
	private int _EnterpriseId;
	private int _FuelId;
	private int _AuditReportId;
	private int _MeasurementFuelId;
	private decimal _Quantity;
	private decimal _Cost;
	private decimal _Budget;
	private decimal _TimeExecuted;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_SaveSolution"; }
		set { base.TableName = "DE_SaveSolution"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("SolutionId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SolutionId
	{ 
		get { return _SolutionId; }
		set { _SolutionId = value;SetDirty("SolutionId"); }
	}
	[FieldName("Purpose", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Purpose
	{ 
		get { return _Purpose; }
		set { _Purpose = value;SetDirty("Purpose"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("MeasurementFuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasurementFuelId
	{ 
		get { return _MeasurementFuelId; }
		set { _MeasurementFuelId = value;SetDirty("MeasurementFuelId"); }
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
	[FieldName("Budget", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Budget
	{ 
		get { return _Budget; }
		set { _Budget = value;SetDirty("Budget"); }
	}
	[FieldName("TimeExecuted", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal TimeExecuted
	{ 
		get { return _TimeExecuted; }
		set { _TimeExecuted = value;SetDirty("TimeExecuted"); }
	}
	#endregion

	}
}
