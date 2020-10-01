using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ReportLog
	{

	#region Constructor
	public ReportLog()
	{}
	
	public ReportLog(ReportLogBO reportlogBO)
	{
			this.Id = reportlogBO.Id;
			this.MemberId = reportlogBO.MemberId;
			this.ActionName = reportlogBO.ActionName;
			this.Created = reportlogBO.Created;
			this.Comment = reportlogBO.Comment;
			this.ReportId = reportlogBO.ReportId;
			this.Status = reportlogBO.Status;
			this.UserName = reportlogBO.UserName;
			this.LogType = reportlogBO.LogType;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _MemberId;
	private string _ActionName;
	private System.DateTime _Created;
	private string _Comment;
	private int _ReportId;
	private string _Status;
	private string _UserName;
	private int _LogType;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int MemberId
	{ 
		get { return _MemberId; }
		set { _MemberId = value; }
	}
	public string ActionName
	{ 
		get { return _ActionName; }
		set { _ActionName = value; }
	}
	public System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value; }
	}
	public string Comment
	{ 
		get { return _Comment; }
		set { _Comment = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	public string Status
	{ 
		get { return _Status; }
		set { _Status = value; }
	}
	public string UserName
	{ 
		get { return _UserName; }
		set { _UserName = value; }
	}
	public int LogType
	{ 
		get { return _LogType; }
		set { _LogType = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
