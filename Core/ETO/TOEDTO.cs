using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class TOE
	{

	#region Constructor
	public TOE()
	{}
	
	public TOE(TOEBO toeBO)
	{
			this.Id = toeBO.Id;
			this.TOEName = toeBO.TOEName;
			this.Description = toeBO.Description;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _TOEName;
	private string _Description;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string TOEName
	{ 
		get { return _TOEName; }
		set { _TOEName = value; }
	}
	public string Description
	{ 
		get { return _Description; }
		set { _Description = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
