using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class MeasurementFuel
	{

	#region Constructor
	public MeasurementFuel()
	{}
	
	public MeasurementFuel(MeasurementFuelBO measurementfuelBO)
	{
			this.Id = measurementfuelBO.Id;
			this.FuelId = measurementfuelBO.FuelId;
			this.TOE = measurementfuelBO.TOE;
			this.From_TOE = measurementfuelBO.From_TOE;
			this.To_TOE = measurementfuelBO.To_TOE;
			this.MeasurementId = measurementfuelBO.MeasurementId;
			this.TOEId = measurementfuelBO.TOEId;
			this.NoCO2 = measurementfuelBO.NoCO2;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _FuelId;
	private decimal _TOE;
	private decimal _From_TOE;
	private decimal _To_TOE;
	private int _MeasurementId;
	private int _TOEId;
	private decimal _NoCO2;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	public decimal TOE
	{ 
		get { return _TOE; }
		set { _TOE = value; }
	}
	public decimal From_TOE
	{ 
		get { return _From_TOE; }
		set { _From_TOE = value; }
	}
	public decimal To_TOE
	{ 
		get { return _To_TOE; }
		set { _To_TOE = value; }
	}
	public int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value; }
	}
	public int TOEId
	{ 
		get { return _TOEId; }
		set { _TOEId = value; }
	}
	public decimal NoCO2
	{ 
		get { return _NoCO2; }
		set { _NoCO2 = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
