using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;


namespace ePower.DE.Domain
{
	public class Report
	{

	#region Constructor
	public Report()
	{}
	
	public Report(ReportBO reportBO)
	{
			this.Id = reportBO.Id;
			this.Title = reportBO.Title;
			this.Des = reportBO.Des;
			this.FilePath = reportBO.FilePath;
			this.EnterpriseId = reportBO.EnterpriseId;
			this.IsApproval = reportBO.IsApproval;
			this.IsDelete = reportBO.IsDelete;
			this.Createdate = reportBO.Createdate;
			this.CreateByUser = reportBO.CreateByUser;
			this.ModifileByUser = reportBO.ModifileByUser;
			this.ModifileDate = reportBO.ModifileDate;
			this.ReportDate = reportBO.ReportDate;
			this.OrganizationId = reportBO.OrganizationId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _Title;
	private string _Des;
	private string _FilePath;
	private int _EnterpriseId;
	private bool _IsApproval;
	private bool _IsDelete;
	private System.DateTime _Createdate;
	private int _CreateByUser;
	private int _ModifileByUser;
	private System.DateTime _ModifileDate;
	private System.DateTime _ReportDate;
	private int _OrganizationId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string Title
	{ 
		get { return _Title; }
		set { _Title = value; }
	}
	public string Des
	{ 
		get { return _Des; }
		set { _Des = value; }
	}
	public string FilePath
	{ 
		get { return _FilePath; }
		set { _FilePath = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public bool IsApproval
	{ 
		get { return _IsApproval; }
		set { _IsApproval = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public System.DateTime Createdate
	{ 
		get { return _Createdate; }
		set { _Createdate = value; }
	}
	public int CreateByUser
	{ 
		get { return _CreateByUser; }
		set { _CreateByUser = value; }
	}
	public int ModifileByUser
	{ 
		get { return _ModifileByUser; }
		set { _ModifileByUser = value; }
	}
	public System.DateTime ModifileDate
	{ 
		get { return _ModifileDate; }
		set { _ModifileDate = value; }
	}
	public System.DateTime ReportDate
	{ 
		get { return _ReportDate; }
		set { _ReportDate = value; }
	}
	public int OrganizationId
	{ 
		get { return _OrganizationId; }
		set { _OrganizationId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
