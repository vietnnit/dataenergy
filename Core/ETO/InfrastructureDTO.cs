using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Infrastructure
	{

	#region Constructor
	public Infrastructure()
	{}
	
	public Infrastructure(InfrastructureBO infrastructureBO)
	{
			this.Id = infrastructureBO.Id;
			this.ProduceEmployeeNo = infrastructureBO.ProduceEmployeeNo;
			this.OfficeEmployeeNo = infrastructureBO.OfficeEmployeeNo;
			this.ProduceAreaNo = infrastructureBO.ProduceAreaNo;
			this.OfficeAreaNo = infrastructureBO.OfficeAreaNo;
			this.ReportId = infrastructureBO.ReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProduceEmployeeNo;
	private int _OfficeEmployeeNo;
	private int _ProduceAreaNo;
	private int _OfficeAreaNo;
	private int _ReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ProduceEmployeeNo
	{ 
		get { return _ProduceEmployeeNo; }
		set { _ProduceEmployeeNo = value; }
	}
	public int OfficeEmployeeNo
	{ 
		get { return _OfficeEmployeeNo; }
		set { _OfficeEmployeeNo = value; }
	}
	public int ProduceAreaNo
	{ 
		get { return _ProduceAreaNo; }
		set { _ProduceAreaNo = value; }
	}
	public int OfficeAreaNo
	{ 
		get { return _OfficeAreaNo; }
		set { _OfficeAreaNo = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
