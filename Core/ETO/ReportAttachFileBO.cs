using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ReportAttachFileBO : BaseEntity
	{

	#region Constructor
	public ReportAttachFileBO()
	{}
	

	public ReportAttachFileBO(ReportAttachFile reportattachfileDTO)
	{
		this.Id = reportattachfileDTO.Id;
		this.PathFile = reportattachfileDTO.PathFile;
		this.ActionName = reportattachfileDTO.ActionName;
		this.Created = reportattachfileDTO.Created;
		this.Comment = reportattachfileDTO.Comment;
		this.ReportId = reportattachfileDTO.ReportId;
		this.UserName = reportattachfileDTO.UserName;
		this.UserId = reportattachfileDTO.UserId;
		this.ReportType = reportattachfileDTO.ReportType;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ReportAttachFile"; }
		set { base.TableName = "DE_ReportAttachFile"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("PathFile", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string PathFile
	{ 
		get { return _PathFile; }
		set { _PathFile = value;SetDirty("PathFile"); }
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
	[FieldName("UserName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string UserName
	{ 
		get { return _UserName; }
		set { _UserName = value;SetDirty("UserName"); }
	}
	[FieldName("UserId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int UserId
	{ 
		get { return _UserId; }
		set { _UserId = value;SetDirty("UserId"); }
	}
	[FieldName("ReportType", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportType
	{ 
		get { return _ReportType; }
		set { _ReportType = value;SetDirty("ReportType"); }
	}
	#endregion

	}
}
