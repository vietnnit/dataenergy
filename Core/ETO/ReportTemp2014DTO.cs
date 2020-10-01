using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ReportTemp2014
	{

	#region Constructor
	public ReportTemp2014()
	{}
	
	public ReportTemp2014(ReportTemp2014BO reporttemp2014BO)
	{
			this.Id = reporttemp2014BO.Id;
			this.Year = reporttemp2014BO.Year;
			this.EnterpriseId = reporttemp2014BO.EnterpriseId;
			this.Dien_kWh = reporttemp2014BO.Dien_kWh;
			this.Than_Tan = reporttemp2014BO.Than_Tan;
			this.DO_Tan = reporttemp2014BO.DO_Tan;
			this.FO_Tan = reporttemp2014BO.FO_Tan;
			this.Xang_Tan = reporttemp2014BO.Xang_Tan;
			this.Gas_Tan = reporttemp2014BO.Gas_Tan;
			this.Khi_M3 = reporttemp2014BO.Khi_M3;
			this.LPG_Tan = reporttemp2014BO.LPG_Tan;
			this.Khac_SoDo = reporttemp2014BO.Khac_SoDo;
			this.AreaName = reporttemp2014BO.AreaName;
			this.SubAreaName = reporttemp2014BO.SubAreaName;
			this.Address = reporttemp2014BO.Address;
			this.Phone = reporttemp2014BO.Phone;
			this.Note = reporttemp2014BO.Note;
			this.Title = reporttemp2014BO.Title;
			this.AreaId = reporttemp2014BO.AreaId;
			this.SubAreaId = reporttemp2014BO.SubAreaId;
			this.OrgId = reporttemp2014BO.OrgId;
			this.No_TOE = reporttemp2014BO.No_TOE;
			this.KhacSoDo = reporttemp2014BO.KhacSoDo;
			this.IsDelete = reporttemp2014BO.IsDelete;
			this.DO_lit = reporttemp2014BO.DO_lit;
			this.FO_lit = reporttemp2014BO.FO_lit;
			this.Xang_lit = reporttemp2014BO.Xang_lit;
			this.NLPL_Tan = reporttemp2014BO.NLPL_Tan;
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
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public string Dien_kWh
	{ 
		get { return _Dien_kWh; }
		set { _Dien_kWh = value; }
	}
	public string Than_Tan
	{ 
		get { return _Than_Tan; }
		set { _Than_Tan = value; }
	}
	public string DO_Tan
	{ 
		get { return _DO_Tan; }
		set { _DO_Tan = value; }
	}
	public string FO_Tan
	{ 
		get { return _FO_Tan; }
		set { _FO_Tan = value; }
	}
	public string Xang_Tan
	{ 
		get { return _Xang_Tan; }
		set { _Xang_Tan = value; }
	}
	public string Gas_Tan
	{ 
		get { return _Gas_Tan; }
		set { _Gas_Tan = value; }
	}
	public string Khi_M3
	{ 
		get { return _Khi_M3; }
		set { _Khi_M3 = value; }
	}
	public string LPG_Tan
	{ 
		get { return _LPG_Tan; }
		set { _LPG_Tan = value; }
	}
	public string Khac_SoDo
	{ 
		get { return _Khac_SoDo; }
		set { _Khac_SoDo = value; }
	}
	public string AreaName
	{ 
		get { return _AreaName; }
		set { _AreaName = value; }
	}
	public string SubAreaName
	{ 
		get { return _SubAreaName; }
		set { _SubAreaName = value; }
	}
	public string Address
	{ 
		get { return _Address; }
		set { _Address = value; }
	}
	public string Phone
	{ 
		get { return _Phone; }
		set { _Phone = value; }
	}
	public string Note
	{ 
		get { return _Note; }
		set { _Note = value; }
	}
	public string Title
	{ 
		get { return _Title; }
		set { _Title = value; }
	}
	public int AreaId
	{ 
		get { return _AreaId; }
		set { _AreaId = value; }
	}
	public int SubAreaId
	{ 
		get { return _SubAreaId; }
		set { _SubAreaId = value; }
	}
	public int OrgId
	{ 
		get { return _OrgId; }
		set { _OrgId = value; }
	}
	public decimal No_TOE
	{ 
		get { return _No_TOE; }
		set { _No_TOE = value; }
	}
	public string KhacSoDo
	{ 
		get { return _KhacSoDo; }
		set { _KhacSoDo = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public string DO_lit
	{ 
		get { return _DO_lit; }
		set { _DO_lit = value; }
	}
	public string FO_lit
	{ 
		get { return _FO_lit; }
		set { _FO_lit = value; }
	}
	public string Xang_lit
	{ 
		get { return _Xang_lit; }
		set { _Xang_lit = value; }
	}
	public string NLPL_Tan
	{ 
		get { return _NLPL_Tan; }
		set { _NLPL_Tan = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
