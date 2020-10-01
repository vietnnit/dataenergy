using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace PR.Domain
{
	public class ProType
	{

	#region Constructor
	public ProType()
	{}
	
	public ProType(ProTypeBO protypeBO)
	{
			this.Id = protypeBO.Id;
			this.ProjectId = protypeBO.ProjectId;
			this.TypeId = protypeBO.TypeId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProjectId;
	private int _TypeId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ProjectId
	{ 
		get { return _ProjectId; }
		set { _ProjectId = value; }
	}
	public int TypeId
	{ 
		get { return _TypeId; }
		set { _TypeId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
