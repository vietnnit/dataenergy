using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class AuditReport
	{

	#region Constructor
	public AuditReport()
	{}
	
	public AuditReport(AuditReportBO auditreportBO)
	{
			this.Id = auditreportBO.Id;
			this.AuditConsultancyName = auditreportBO.AuditConsultancyName;
			this.Address = auditreportBO.Address;
			this.ShiftNo = auditreportBO.ShiftNo;
			this.AuditingScope = auditreportBO.AuditingScope;
			this.AuditorName = auditreportBO.AuditorName;
			this.AuditReportId = auditreportBO.AuditReportId;
			this.AuditYear = auditreportBO.AuditYear;
			this.DataYear = auditreportBO.DataYear;
			this.EnterpriseId = auditreportBO.EnterpriseId;
			this.Created = auditreportBO.Created;
			this.Sent = auditreportBO.Sent;
			this.Confirmed = auditreportBO.Confirmed;
			this.Status = auditreportBO.Status;
			this.PathFile = auditreportBO.PathFile;
			this.TaxNo = auditreportBO.TaxNo;
			this.AuditorCode = auditreportBO.AuditorCode;
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
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string AuditConsultancyName
	{ 
		get { return _AuditConsultancyName; }
		set { _AuditConsultancyName = value; }
	}
	public string Address
	{ 
		get { return _Address; }
		set { _Address = value; }
	}
	public int ShiftNo
	{ 
		get { return _ShiftNo; }
		set { _ShiftNo = value; }
	}
	public string AuditingScope
	{ 
		get { return _AuditingScope; }
		set { _AuditingScope = value; }
	}
	public string AuditorName
	{ 
		get { return _AuditorName; }
		set { _AuditorName = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public int AuditYear
	{ 
		get { return _AuditYear; }
		set { _AuditYear = value; }
	}
	public int DataYear
	{ 
		get { return _DataYear; }
		set { _DataYear = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value; }
	}
	public System.DateTime Sent
	{ 
		get { return _Sent; }
		set { _Sent = value; }
	}
	public System.DateTime Confirmed
	{ 
		get { return _Confirmed; }
		set { _Confirmed = value; }
	}
	public int Status
	{ 
		get { return _Status; }
		set { _Status = value; }
	}
	public string PathFile
	{ 
		get { return _PathFile; }
		set { _PathFile = value; }
	}
	public string TaxNo
	{ 
		get { return _TaxNo; }
		set { _TaxNo = value; }
	}
	public string AuditorCode
	{ 
		get { return _AuditorCode; }
		set { _AuditorCode = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
