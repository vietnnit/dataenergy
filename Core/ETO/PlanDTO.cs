using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Plan
	{

	#region Constructor
	public Plan()
	{}
	
	public Plan(PlanBO planBO)
	{
			this.Id = planBO.Id;
			this.PlanName = planBO.PlanName;
			this.ReportDate = planBO.ReportDate;
			this.EnterpriseId = planBO.EnterpriseId;
			this.CreateByUser = planBO.CreateByUser;
			this.CreateDate = planBO.CreateDate;
			this.ModifyByUser = planBO.ModifyByUser;
			this.ModifyDate = planBO.ModifyDate;
			this.IsDelete = planBO.IsDelete;
			this.Des = planBO.Des;
			this.ReportId = planBO.ReportId;
			this.BeginYear = planBO.BeginYear;
			this.EndYear = planBO.EndYear;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _PlanName;
	private System.DateTime _ReportDate;
	private int _EnterpriseId;
	private int _CreateByUser;
	private System.DateTime _CreateDate;
	private int _ModifyByUser;
	private System.DateTime _ModifyDate;
	private int _IsDelete;
	private string _Des;
	private int _ReportId;
	private int _BeginYear;
	private int _EndYear;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string PlanName
	{ 
		get { return _PlanName; }
		set { _PlanName = value; }
	}
	public System.DateTime ReportDate
	{ 
		get { return _ReportDate; }
		set { _ReportDate = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public int CreateByUser
	{ 
		get { return _CreateByUser; }
		set { _CreateByUser = value; }
	}
	public System.DateTime CreateDate
	{ 
		get { return _CreateDate; }
		set { _CreateDate = value; }
	}
	public int ModifyByUser
	{ 
		get { return _ModifyByUser; }
		set { _ModifyByUser = value; }
	}
	public System.DateTime ModifyDate
	{ 
		get { return _ModifyDate; }
		set { _ModifyDate = value; }
	}
	public int IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public string Des
	{ 
		get { return _Des; }
		set { _Des = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	public int BeginYear
	{ 
		get { return _BeginYear; }
		set { _BeginYear = value; }
	}
	public int EndYear
	{ 
		get { return _EndYear; }
		set { _EndYear = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
