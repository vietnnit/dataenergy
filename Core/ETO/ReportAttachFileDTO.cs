using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ReportAttachFile
	{

	#region Constructor
	public ReportAttachFile()
	{}
	
	public ReportAttachFile(ReportAttachFileBO reportattachfileBO)
	{
			this.Id = reportattachfileBO.Id;
			this.PathFile = reportattachfileBO.PathFile;
			this.ActionName = reportattachfileBO.ActionName;
			this.Created = reportattachfileBO.Created;
			this.Comment = reportattachfileBO.Comment;
			this.ReportId = reportattachfileBO.ReportId;
			this.UserName = reportattachfileBO.UserName;
			this.UserId = reportattachfileBO.UserId;
			this.ReportType = reportattachfileBO.ReportType;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _PathFile;
	private string _ActionName;
	private System.DateTime _Created;
	private string _Comment;
	private int _ReportId;
	private string _UserName;
	private int _UserId;
	private int _ReportType;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string PathFile
	{ 
		get { return _PathFile; }
		set { _PathFile = value; }
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
	public string UserName
	{ 
		get { return _UserName; }
		set { _UserName = value; }
	}
	public int UserId
	{ 
		get { return _UserId; }
		set { _UserId = value; }
	}
	public int ReportType
	{ 
		get { return _ReportType; }
		set { _ReportType = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
