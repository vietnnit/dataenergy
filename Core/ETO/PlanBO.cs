using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class PlanBO : BaseEntity
	{

	#region Constructor
	public PlanBO()
	{}
	

	public PlanBO(Plan planDTO)
	{
		this.Id = planDTO.Id;
		this.PlanName = planDTO.PlanName;
		this.ReportDate = planDTO.ReportDate;
		this.EnterpriseId = planDTO.EnterpriseId;
		this.CreateByUser = planDTO.CreateByUser;
		this.CreateDate = planDTO.CreateDate;
		this.ModifyByUser = planDTO.ModifyByUser;
		this.ModifyDate = planDTO.ModifyDate;
		this.IsDelete = planDTO.IsDelete;
		this.Des = planDTO.Des;
		this.ReportId = planDTO.ReportId;
		this.BeginYear = planDTO.BeginYear;
		this.EndYear = planDTO.EndYear;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Plan"; }
		set { base.TableName = "DE_Plan"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("PlanName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string PlanName
	{ 
		get { return _PlanName; }
		set { _PlanName = value;SetDirty("PlanName"); }
	}
	[FieldName("ReportDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime ReportDate
	{ 
		get { return _ReportDate; }
		set { _ReportDate = value;SetDirty("ReportDate"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("CreateByUser", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int CreateByUser
	{ 
		get { return _CreateByUser; }
		set { _CreateByUser = value;SetDirty("CreateByUser"); }
	}
	[FieldName("CreateDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime CreateDate
	{ 
		get { return _CreateDate; }
		set { _CreateDate = value;SetDirty("CreateDate"); }
	}
	[FieldName("ModifyByUser", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ModifyByUser
	{ 
		get { return _ModifyByUser; }
		set { _ModifyByUser = value;SetDirty("ModifyByUser"); }
	}
	[FieldName("ModifyDate", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime ModifyDate
	{ 
		get { return _ModifyDate; }
		set { _ModifyDate = value;SetDirty("ModifyDate"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("Des", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Des
	{ 
		get { return _Des; }
		set { _Des = value;SetDirty("Des"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("BeginYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int BeginYear
	{ 
		get { return _BeginYear; }
		set { _BeginYear = value;SetDirty("BeginYear"); }
	}
	[FieldName("EndYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EndYear
	{ 
		get { return _EndYear; }
		set { _EndYear = value;SetDirty("EndYear"); }
	}
	#endregion

	}
}
