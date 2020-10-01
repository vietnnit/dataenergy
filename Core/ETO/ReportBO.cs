using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
    public class ReportBO : BaseEntity
    {

	#region Constructor
	public ReportBO()
	{}
	

	public ReportBO(Report reportDTO)
	{
		this.Id = reportDTO.Id;
		this.Title = reportDTO.Title;
		this.Des = reportDTO.Des;
		this.FilePath = reportDTO.FilePath;
		this.EnterpriseId = reportDTO.EnterpriseId;
		this.IsApproval = reportDTO.IsApproval;
		this.IsDelete = reportDTO.IsDelete;
		this.Createdate = reportDTO.Createdate;
		this.CreateByUser = reportDTO.CreateByUser;
		this.ModifileByUser = reportDTO.ModifileByUser;
		this.ModifileDate = reportDTO.ModifileDate;
		this.ReportDate = reportDTO.ReportDate;
		this.OrganizationId = reportDTO.OrganizationId;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "tblReport"; }
		set { base.TableName = "tblReport"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("Title", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Title
	{ 
		get { return _Title; }
		set { _Title = value;SetDirty("Title"); }
	}
	[FieldName("Des", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Des
	{ 
		get { return _Des; }
		set { _Des = value;SetDirty("Des"); }
	}
	[FieldName("FilePath", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FilePath
	{ 
		get { return _FilePath; }
		set { _FilePath = value;SetDirty("FilePath"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("IsApproval", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsApproval
	{ 
		get { return _IsApproval; }
		set { _IsApproval = value;SetDirty("IsApproval"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("Createdate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime Createdate
	{ 
		get { return _Createdate; }
		set { _Createdate = value;SetDirty("Createdate"); }
	}
	[FieldName("CreateByUser", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int CreateByUser
	{ 
		get { return _CreateByUser; }
		set { _CreateByUser = value;SetDirty("CreateByUser"); }
	}
	[FieldName("ModifileByUser", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ModifileByUser
	{ 
		get { return _ModifileByUser; }
		set { _ModifileByUser = value;SetDirty("ModifileByUser"); }
	}
	[FieldName("ModifileDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime ModifileDate
	{ 
		get { return _ModifileDate; }
		set { _ModifileDate = value;SetDirty("ModifileDate"); }
	}
	[FieldName("ReportDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime ReportDate
	{ 
		get { return _ReportDate; }
		set { _ReportDate = value;SetDirty("ReportDate"); }
	}
	[FieldName("OrganizationId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OrganizationId
	{ 
		get { return _OrganizationId; }
		set { _OrganizationId = value;SetDirty("OrganizationId"); }
	}
	#endregion

	}
}
