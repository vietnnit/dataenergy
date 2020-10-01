using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ReportTemp2014BO : BaseEntity
	{

	#region Constructor
	public ReportTemp2014BO()
	{}
	

	public ReportTemp2014BO(ReportTemp2014 reporttemp2014DTO)
	{
		this.Id = reporttemp2014DTO.Id;
		this.Year = reporttemp2014DTO.Year;
		this.EnterpriseId = reporttemp2014DTO.EnterpriseId;
		this.Dien_kWh = reporttemp2014DTO.Dien_kWh;
		this.Than_Tan = reporttemp2014DTO.Than_Tan;
		this.DO_Tan = reporttemp2014DTO.DO_Tan;
		this.FO_Tan = reporttemp2014DTO.FO_Tan;
		this.Xang_Tan = reporttemp2014DTO.Xang_Tan;
		this.Gas_Tan = reporttemp2014DTO.Gas_Tan;
		this.Khi_M3 = reporttemp2014DTO.Khi_M3;
		this.LPG_Tan = reporttemp2014DTO.LPG_Tan;
		this.Khac_SoDo = reporttemp2014DTO.Khac_SoDo;
		this.AreaName = reporttemp2014DTO.AreaName;
		this.SubAreaName = reporttemp2014DTO.SubAreaName;
		this.Address = reporttemp2014DTO.Address;
		this.Phone = reporttemp2014DTO.Phone;
		this.Note = reporttemp2014DTO.Note;
		this.Title = reporttemp2014DTO.Title;
		this.AreaId = reporttemp2014DTO.AreaId;
		this.SubAreaId = reporttemp2014DTO.SubAreaId;
		this.OrgId = reporttemp2014DTO.OrgId;
		this.No_TOE = reporttemp2014DTO.No_TOE;
		this.KhacSoDo = reporttemp2014DTO.KhacSoDo;
		this.IsDelete = reporttemp2014DTO.IsDelete;
		this.DO_lit = reporttemp2014DTO.DO_lit;
		this.FO_lit = reporttemp2014DTO.FO_lit;
		this.Xang_lit = reporttemp2014DTO.Xang_lit;
		this.NLPL_Tan = reporttemp2014DTO.NLPL_Tan;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _Year;
	private int _EnterpriseId;
	private string _Dien_kWh;
	private string _Than_Tan;
	private string _DO_Tan;
	private string _FO_Tan;
	private string _Xang_Tan;
	private string _Gas_Tan;
	private string _Khi_M3;
	private string _LPG_Tan;
	private string _Khac_SoDo;
	private string _AreaName;
	private string _SubAreaName;
	private string _Address;
	private string _Phone;
	private string _Note;
	private string _Title;
	private int _AreaId;
	private int _SubAreaId;
	private int _OrgId;
	private decimal _No_TOE;
	private string _KhacSoDo;
	private bool _IsDelete;
	private string _DO_lit;
	private string _FO_lit;
	private string _Xang_lit;
	private string _NLPL_Tan;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ReportTemp2014"; }
		set { base.TableName = "DE_ReportTemp2014"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Year
	{ 
		get { return _Year; }
		set { _Year = value;SetDirty("Year"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("Dien_kWh", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Dien_kWh
	{ 
		get { return _Dien_kWh; }
		set { _Dien_kWh = value;SetDirty("Dien_kWh"); }
	}
	[FieldName("Than_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Than_Tan
	{ 
		get { return _Than_Tan; }
		set { _Than_Tan = value;SetDirty("Than_Tan"); }
	}
	[FieldName("DO_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string DO_Tan
	{ 
		get { return _DO_Tan; }
		set { _DO_Tan = value;SetDirty("DO_Tan"); }
	}
	[FieldName("FO_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FO_Tan
	{ 
		get { return _FO_Tan; }
		set { _FO_Tan = value;SetDirty("FO_Tan"); }
	}
	[FieldName("Xang_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Xang_Tan
	{ 
		get { return _Xang_Tan; }
		set { _Xang_Tan = value;SetDirty("Xang_Tan"); }
	}
	[FieldName("Gas_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Gas_Tan
	{ 
		get { return _Gas_Tan; }
		set { _Gas_Tan = value;SetDirty("Gas_Tan"); }
	}
	[FieldName("Khi_M3", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Khi_M3
	{ 
		get { return _Khi_M3; }
		set { _Khi_M3 = value;SetDirty("Khi_M3"); }
	}
	[FieldName("LPG_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string LPG_Tan
	{ 
		get { return _LPG_Tan; }
		set { _LPG_Tan = value;SetDirty("LPG_Tan"); }
	}
	[FieldName("Khac_SoDo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Khac_SoDo
	{ 
		get { return _Khac_SoDo; }
		set { _Khac_SoDo = value;SetDirty("Khac_SoDo"); }
	}
	[FieldName("AreaName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value;SetDirty("AreaName"); }
	}
	[FieldName("SubAreaName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string SubAreaName
	{ 
		get { return _SubAreaName; }
		set { _SubAreaName = value;SetDirty("SubAreaName"); }
	}
	[FieldName("Address", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Address
	{ 
		get { return _Address; }
		set { _Address = value;SetDirty("Address"); }
	}
	[FieldName("Phone", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value;SetDirty("Phone"); }
	}
	[FieldName("Note", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Note
	{ 
		get { return _Note; }
		set { _Note = value;SetDirty("Note"); }
	}
	[FieldName("Title", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Title
	{ 
		get { return _Title; }
		set { _Title = value;SetDirty("Title"); }
	}
	[FieldName("AreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AreaId
	{ 
		get { return _AreaId; }
		set { _AreaId = value;SetDirty("AreaId"); }
	}
	[FieldName("SubAreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SubAreaId
	{ 
		get { return _SubAreaId; }
		set { _SubAreaId = value;SetDirty("SubAreaId"); }
	}
	[FieldName("OrgId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int OrgId
	{ 
		get { return _OrgId; }
		set { _OrgId = value;SetDirty("OrgId"); }
	}
	[FieldName("No_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal No_TOE
	{ 
		get { return _No_TOE; }
		set { _No_TOE = value;SetDirty("No_TOE"); }
	}
	[FieldName("KhacSoDo", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string KhacSoDo
	{ 
		get { return _KhacSoDo; }
		set { _KhacSoDo = value;SetDirty("KhacSoDo"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("DO_lit", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string DO_lit
	{ 
		get { return _DO_lit; }
		set { _DO_lit = value;SetDirty("DO_lit"); }
	}
	[FieldName("FO_lit", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FO_lit
	{ 
		get { return _FO_lit; }
		set { _FO_lit = value;SetDirty("FO_lit"); }
	}
	[FieldName("Xang_lit", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Xang_lit
	{ 
		get { return _Xang_lit; }
		set { _Xang_lit = value;SetDirty("Xang_lit"); }
	}
	[FieldName("NLPL_Tan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string NLPL_Tan
	{ 
		get { return _NLPL_Tan; }
		set { _NLPL_Tan = value;SetDirty("NLPL_Tan"); }
	}
	#endregion

	}
}
