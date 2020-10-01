using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Measurement
	{

	#region Constructor
	public Measurement()
	{}
	
	public Measurement(MeasurementBO measurementBO)
	{
			this.Id = measurementBO.Id;
			this.MeasurementName = measurementBO.MeasurementName;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _MeasurementName;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string MeasurementName
	{ 
		get { return _MeasurementName; }
		set { _MeasurementName = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
