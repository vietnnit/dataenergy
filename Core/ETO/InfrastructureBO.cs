using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class InfrastructureBO : BaseEntity
	{

	#region Constructor
	public InfrastructureBO()
	{}
	

	public InfrastructureBO(Infrastructure infrastructureDTO)
	{
		this.Id = infrastructureDTO.Id;
		this.ProduceEmployeeNo = infrastructureDTO.ProduceEmployeeNo;
		this.OfficeEmployeeNo = infrastructureDTO.OfficeEmployeeNo;
		this.ProduceAreaNo = infrastructureDTO.ProduceAreaNo;
		this.OfficeAreaNo = infrastructureDTO.OfficeAreaNo;
		this.ReportId = infrastructureDTO.ReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProduceEmployeeNo;
	private int _OfficeEmployeeNo;
	private int _ProduceAreaNo;
	private int _OfficeAreaNo;
	private int _ReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Infrastructure"; }
		set { base.TableName = "DE_Infrastructure"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ProduceEmployeeNo", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProduceEmployeeNo
	{ 
		get { return _ProduceEmployeeNo; }
		set { _ProduceEmployeeNo = value;SetDirty("ProduceEmployeeNo"); }
	}
	[FieldName("OfficeEmployeeNo", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OfficeEmployeeNo
	{ 
		get { return _OfficeEmployeeNo; }
		set { _OfficeEmployeeNo = value;SetDirty("OfficeEmployeeNo"); }
	}
	[FieldName("ProduceAreaNo", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProduceAreaNo
	{ 
		get { return _ProduceAreaNo; }
		set { _ProduceAreaNo = value;SetDirty("ProduceAreaNo"); }
	}
	[FieldName("OfficeAreaNo", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OfficeAreaNo
	{ 
		get { return _OfficeAreaNo; }
		set { _OfficeAreaNo = value;SetDirty("OfficeAreaNo"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	#endregion

	}
}
