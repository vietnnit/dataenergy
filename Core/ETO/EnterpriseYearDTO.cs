using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class EnterpriseYear
	{

	#region Constructor
	public EnterpriseYear()
	{}
	
	public EnterpriseYear(EnterpriseYearBO enterpriseyearBO)
	{
			this.Id = enterpriseyearBO.Id;
			this.Year = enterpriseyearBO.Year;
			this.EnterpriseId = enterpriseyearBO.EnterpriseId;
			this.IsDelete = enterpriseyearBO.IsDelete;
			this.No_TOE = enterpriseyearBO.No_TOE;
			this.IsKey = enterpriseyearBO.IsKey;
			this.NoTOE_Plan = enterpriseyearBO.NoTOE_Plan;
			this.ReportId = enterpriseyearBO.ReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _Year;
	private int _EnterpriseId;
	private bool _IsDelete;
	private decimal _No_TOE;
	private bool _IsKey;
	private decimal _NoTOE_Plan;
	private int _ReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public decimal No_TOE
	{ 
		get { return _No_TOE; }
		set { _No_TOE = value; }
	}
	public bool IsKey
	{ 
		get { return _IsKey; }
		set { _IsKey = value; }
	}
	public decimal NoTOE_Plan
	{ 
		get { return _NoTOE_Plan; }
		set { _NoTOE_Plan = value; }
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
