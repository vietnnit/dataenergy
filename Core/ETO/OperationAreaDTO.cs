using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class OperationArea
	{

	#region Constructor
	public OperationArea()
	{}
	
	public OperationArea(OperationAreaBO operationareaBO)
	{
			this.Id = operationareaBO.Id;
			this.AreaName = operationareaBO.AreaName;
			this.OperationHours = operationareaBO.OperationHours;
			this.AuditReportId = operationareaBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _AreaName;
	private int _OperationHours;
	private int _AuditReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value; }
	}
	public int OperationHours
	{ 
		get { return _OperationHours; }
		set { _OperationHours = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
