using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class AuditReportBO : BaseEntity
	{

	#region Constructor
	public AuditReportBO()
	{}
	

	public AuditReportBO(AuditReport auditreportDTO)
	{
		this.Id = auditreportDTO.Id;
		this.AuditConsultancyName = auditreportDTO.AuditConsultancyName;
		this.Address = auditreportDTO.Address;
		this.ShiftNo = auditreportDTO.ShiftNo;
		this.AuditingScope = auditreportDTO.AuditingScope;
		this.AuditorName = auditreportDTO.AuditorName;
		this.AuditReportId = auditreportDTO.AuditReportId;
		this.AuditYear = auditreportDTO.AuditYear;
		this.DataYear = auditreportDTO.DataYear;
		this.EnterpriseId = auditreportDTO.EnterpriseId;
		this.Created = auditreportDTO.Created;
		this.Sent = auditreportDTO.Sent;
		this.Confirmed = auditreportDTO.Confirmed;
		this.Status = auditreportDTO.Status;
		this.PathFile = auditreportDTO.PathFile;
		this.TaxNo = auditreportDTO.TaxNo;
		this.AuditorCode = auditreportDTO.AuditorCode;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AuditConsultancyName;
	private string _Address;
	private int _ShiftNo;
	private string _AuditingScope;
	private string _AuditorName;
	private int _AuditReportId;
	private int _AuditYear;
	private int _DataYear;
	private int _EnterpriseId;
	private System.DateTime _Created;
	private System.DateTime _Sent;
	private System.DateTime _Confirmed;
	private int _Status;
	private string _PathFile;
	private string _TaxNo;
	private string _AuditorCode;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_AuditReport"; }
		set { base.TableName = "DE_AuditReport"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("AuditConsultancyName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AuditConsultancyName
	{ 
		get { return _AuditConsultancyName; }
		set { _AuditConsultancyName = value;SetDirty("AuditConsultancyName"); }
	}
	[FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Address
	{ 
		get { return _Address; }
		set { _Address = value;SetDirty("Address"); }
	}
	[FieldName("ShiftNo", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ShiftNo
	{ 
		get { return _ShiftNo; }
		set { _ShiftNo = value;SetDirty("ShiftNo"); }
	}
	[FieldName("AuditingScope", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AuditingScope
	{ 
		get { return _AuditingScope; }
		set { _AuditingScope = value;SetDirty("AuditingScope"); }
	}
	[FieldName("AuditorName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AuditorName
	{ 
		get { return _AuditorName; }
		set { _AuditorName = value;SetDirty("AuditorName"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	[FieldName("AuditYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditYear
	{ 
		get { return _AuditYear; }
		set { _AuditYear = value;SetDirty("AuditYear"); }
	}
	[FieldName("DataYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int DataYear
	{ 
		get { return _DataYear; }
		set { _DataYear = value;SetDirty("DataYear"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("Created", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value;SetDirty("Created"); }
	}
	[FieldName("Sent", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Sent
	{ 
		get { return _Sent; }
		set { _Sent = value;SetDirty("Sent"); }
	}
	[FieldName("Confirmed", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Confirmed
	{ 
		get { return _Confirmed; }
		set { _Confirmed = value;SetDirty("Confirmed"); }
	}
	[FieldName("Status", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Status
	{ 
		get { return _Status; }
		set { _Status = value;SetDirty("Status"); }
	}
	[FieldName("PathFile", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string PathFile
	{ 
		get { return _PathFile; }
		set { _PathFile = value;SetDirty("PathFile"); }
	}
	[FieldName("TaxNo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string TaxNo
	{ 
		get { return _TaxNo; }
		set { _TaxNo = value;SetDirty("TaxNo"); }
	}
	[FieldName("AuditorCode", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AuditorCode
	{ 
		get { return _AuditorCode; }
		set { _AuditorCode = value;SetDirty("AuditorCode"); }
	}
	#endregion

	}
}
