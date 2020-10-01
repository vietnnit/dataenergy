using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class PlanTBBO : BaseEntity
	{

	#region Constructor
	public PlanTBBO()
	{}
	

	public PlanTBBO(PlanTB plantbDTO)
	{
		this.Id = plantbDTO.Id;
		this.IdPlan = plantbDTO.IdPlan;
		this.EnterpriseId = plantbDTO.EnterpriseId;
		this.NameTB = plantbDTO.NameTB;
		this.TinhNang = plantbDTO.TinhNang;
		this.CachLapDat = plantbDTO.CachLapDat;
		this.LyDo = plantbDTO.LyDo;
		this.KhaNang = plantbDTO.KhaNang;
		this.CamKet = plantbDTO.CamKet;
		this.IsFiveYear = plantbDTO.IsFiveYear;
		this.IsPlan = plantbDTO.IsPlan;
		this.LyDoLapDat = plantbDTO.LyDoLapDat;
		this.IsApproved = plantbDTO.IsApproved;
		this.IsExecuted = plantbDTO.IsExecuted;
		this.ReportId = plantbDTO.ReportId;
		this.IsNew = plantbDTO.IsNew;
		this.Nam = plantbDTO.Nam;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _IdPlan;
	private int _EnterpriseId;
	private string _NameTB;
	private string _TinhNang;
	private string _CachLapDat;
	private string _LyDo;
	private string _KhaNang;
	private string _CamKet;
	private bool _IsFiveYear;
	private bool _IsPlan;
	private string _LyDoLapDat;
	private bool _IsApproved;
	private bool _IsExecuted;
	private int _ReportId;
	private bool _IsNew;
	private int _Nam;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_PlanTB"; }
		set { base.TableName = "DE_PlanTB"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("IdPlan", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int IdPlan
	{ 
		get { return _IdPlan; }
		set { _IdPlan = value;SetDirty("IdPlan"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("NameTB", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string NameTB
	{ 
		get { return _NameTB; }
		set { _NameTB = value;SetDirty("NameTB"); }
	}
	[FieldName("TinhNang", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string TinhNang
	{ 
		get { return _TinhNang; }
		set { _TinhNang = value;SetDirty("TinhNang"); }
	}
	[FieldName("CachLapDat", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string CachLapDat
	{ 
		get { return _CachLapDat; }
		set { _CachLapDat = value;SetDirty("CachLapDat"); }
	}
	[FieldName("LyDo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string LyDo
	{ 
		get { return _LyDo; }
		set { _LyDo = value;SetDirty("LyDo"); }
	}
	[FieldName("KhaNang", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string KhaNang
	{ 
		get { return _KhaNang; }
		set { _KhaNang = value;SetDirty("KhaNang"); }
	}
	[FieldName("CamKet", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string CamKet
	{ 
		get { return _CamKet; }
		set { _CamKet = value;SetDirty("CamKet"); }
	}
	[FieldName("IsFiveYear", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsFiveYear
	{ 
		get { return _IsFiveYear; }
		set { _IsFiveYear = value;SetDirty("IsFiveYear"); }
	}
	[FieldName("IsPlan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsPlan
	{ 
		get { return _IsPlan; }
		set { _IsPlan = value;SetDirty("IsPlan"); }
	}
	[FieldName("LyDoLapDat", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string LyDoLapDat
	{ 
		get { return _LyDoLapDat; }
		set { _LyDoLapDat = value;SetDirty("LyDoLapDat"); }
	}
	[FieldName("IsApproved", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsApproved
	{ 
		get { return _IsApproved; }
		set { _IsApproved = value;SetDirty("IsApproved"); }
	}
	[FieldName("IsExecuted", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsExecuted
	{ 
		get { return _IsExecuted; }
		set { _IsExecuted = value;SetDirty("IsExecuted"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("IsNew", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsNew
	{ 
		get { return _IsNew; }
		set { _IsNew = value;SetDirty("IsNew"); }
	}
	[FieldName("Nam", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Nam
	{ 
		get { return _Nam; }
		set { _Nam = value;SetDirty("Nam"); }
	}
	#endregion

	}
}
