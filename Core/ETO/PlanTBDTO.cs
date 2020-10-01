using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class PlanTB
	{

	#region Constructor
	public PlanTB()
	{}
	
	public PlanTB(PlanTBBO plantbBO)
	{
			this.Id = plantbBO.Id;
			this.IdPlan = plantbBO.IdPlan;
			this.EnterpriseId = plantbBO.EnterpriseId;
			this.NameTB = plantbBO.NameTB;
			this.TinhNang = plantbBO.TinhNang;
			this.CachLapDat = plantbBO.CachLapDat;
			this.LyDo = plantbBO.LyDo;
			this.KhaNang = plantbBO.KhaNang;
			this.CamKet = plantbBO.CamKet;
			this.IsFiveYear = plantbBO.IsFiveYear;
			this.IsPlan = plantbBO.IsPlan;
			this.LyDoLapDat = plantbBO.LyDoLapDat;
			this.IsApproved = plantbBO.IsApproved;
			this.IsExecuted = plantbBO.IsExecuted;
			this.ReportId = plantbBO.ReportId;
			this.IsNew = plantbBO.IsNew;
			this.Nam = plantbBO.Nam;
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
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int IdPlan
	{ 
		get { return _IdPlan; }
		set { _IdPlan = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public string NameTB
	{ 
		get { return _NameTB; }
		set { _NameTB = value; }
	}
	public string TinhNang
	{ 
		get { return _TinhNang; }
		set { _TinhNang = value; }
	}
	public string CachLapDat
	{ 
		get { return _CachLapDat; }
		set { _CachLapDat = value; }
	}
	public string LyDo
	{ 
		get { return _LyDo; }
		set { _LyDo = value; }
	}
	public string KhaNang
	{ 
		get { return _KhaNang; }
		set { _KhaNang = value; }
	}
	public string CamKet
	{ 
		get { return _CamKet; }
		set { _CamKet = value; }
	}
	public bool IsFiveYear
	{ 
		get { return _IsFiveYear; }
		set { _IsFiveYear = value; }
	}
	public bool IsPlan
	{ 
		get { return _IsPlan; }
		set { _IsPlan = value; }
	}
	public string LyDoLapDat
	{ 
		get { return _LyDoLapDat; }
		set { _LyDoLapDat = value; }
	}
	public bool IsApproved
	{ 
		get { return _IsApproved; }
		set { _IsApproved = value; }
	}
	public bool IsExecuted
	{ 
		get { return _IsExecuted; }
		set { _IsExecuted = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	public bool IsNew
	{ 
		get { return _IsNew; }
		set { _IsNew = value; }
	}
	public int Nam
	{ 
		get { return _Nam; }
		set { _Nam = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
