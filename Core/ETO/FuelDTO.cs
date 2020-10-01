using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Fuel
	{

	#region Constructor
	public Fuel()
	{}
	
	public Fuel(FuelBO fuelBO)
	{
			this.Id = fuelBO.Id;
			this.MeasurementId = fuelBO.MeasurementId;
			this.GroupFuelId = fuelBO.GroupFuelId;
			this.FuelName = fuelBO.FuelName;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _MeasurementId;
	private int _GroupFuelId;
	private string _FuelName;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value; }
	}
	public int GroupFuelId
	{ 
		get { return _GroupFuelId; }
		set { _GroupFuelId = value; }
	}
	public string FuelName
	{ 
		get { return _FuelName; }
		set { _FuelName = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
