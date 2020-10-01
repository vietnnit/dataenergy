using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ETO
{
	public class RoleCate
	{

	#region Constructor
	public RoleCate()
	{}
	
	public RoleCate(RoleCateBO rolecateBO)
	{
			this.Id = rolecateBO.Id;
			this.CateId = rolecateBO.CateId;
			this.GroupId = rolecateBO.GroupId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _CateId;
	private int _GroupId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int CateId
	{ 
		get { return _CateId; }
		set { _CateId = value; }
	}
	public int GroupId
	{ 
		get { return _GroupId; }
		set { _GroupId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
