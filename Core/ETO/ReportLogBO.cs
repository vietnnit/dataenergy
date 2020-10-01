using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ReportLogBO : BaseEntity
	{

	#region Constructor
	public ReportLogBO()
	{}
	

	public ReportLogBO(ReportLog reportlogDTO)
	{
		this.Id = reportlogDTO.Id;
		this.MemberId = reportlogDTO.MemberId;
		this.ActionName = reportlogDTO.ActionName;
		this.Created = reportlogDTO.Created;
		this.Comment = reportlogDTO.Comment;
		this.ReportId = reportlogDTO.ReportId;
		this.Status = reportlogDTO.Status;
		this.UserName = reportlogDTO.UserName;
		this.LogType = reportlogDTO.LogType;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ReportLog"; }
		set { base.TableName = "DE_ReportLog"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("MemberId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MemberId
	{ 
		get { return _MemberId; }
		set { _MemberId = value;SetDirty("MemberId"); }
	}
	[FieldName("ActionName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ActionName
	{ 
		get { return _ActionName; }
		set { _ActionName = value;SetDirty("ActionName"); }
	}
	[FieldName("Created", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Created
	{ 
		get { return _Created; }
		set { _Created = value;SetDirty("Created"); }
	}
	[FieldName("Comment", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Comment
	{ 
		get { return _Comment; }
		set { _Comment = value;SetDirty("Comment"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("Status", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Status
	{ 
		get { return _Status; }
		set { _Status = value;SetDirty("Status"); }
	}
	[FieldName("UserName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string UserName
	{ 
		get { return _UserName; }
		set { _UserName = value;SetDirty("UserName"); }
	}
	[FieldName("LogType", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int LogType
	{ 
		get { return _LogType; }
		set { _LogType = value;SetDirty("LogType"); }
	}
	#endregion

	}
}
