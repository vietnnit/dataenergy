using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class GiaiPhap
	{

	#region Constructor
	public GiaiPhap()
	{}
	
	public GiaiPhap(GiaiPhapBO giaiphapBO)
	{
			this.Id = giaiphapBO.Id;
			this.TenGiaiPhap = giaiphapBO.TenGiaiPhap;
			this.MoTa = giaiphapBO.MoTa;
			this.EnterpriseId = giaiphapBO.EnterpriseId;
			this.IsDelete = giaiphapBO.IsDelete;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _TenGiaiPhap;
	private string _MoTa;
	private int _EnterpriseId;
	private bool _IsDelete;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string TenGiaiPhap
	{ 
		get { return _TenGiaiPhap; }
		set { _TenGiaiPhap = value; }
	}
	public string MoTa
	{ 
		get { return _MoTa; }
		set { _MoTa = value; }
	}
	public int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
