using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class OperationAreaBO : BaseEntity
	{

	#region Constructor
	public OperationAreaBO()
	{}
	

	public OperationAreaBO(OperationArea operationareaDTO)
	{
		this.Id = operationareaDTO.Id;
		this.AreaName = operationareaDTO.AreaName;
		this.OperationHours = operationareaDTO.OperationHours;
		this.AuditReportId = operationareaDTO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
	private int _OperationHours;
	private int _AuditReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_OperationArea"; }
		set { base.TableName = "DE_OperationArea"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("AreaName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value;SetDirty("AreaName"); }
	}
	[FieldName("OperationHours", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OperationHours
	{ 
		get { return _OperationHours; }
		set { _OperationHours = value;SetDirty("OperationHours"); }
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
