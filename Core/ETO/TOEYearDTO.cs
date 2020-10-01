using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class TOEYear
	{

	#region Constructor
	public TOEYear()
	{}
	
	public TOEYear(TOEYearBO toeyearBO)
	{
			this.Id = toeyearBO.Id;
			this.TOEId = toeyearBO.TOEId;
			this.Year = toeyearBO.Year;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _TOEId;
	private int _Year;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int TOEId
	{ 
		get { return _TOEId; }
		set { _TOEId = value; }
	}
	public int Year
	{ 
		get { return _Year; }
		set { _Year = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
