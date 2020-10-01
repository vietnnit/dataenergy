using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ProductMeasurement
	{

	#region Constructor
	public ProductMeasurement()
	{}
	
	public ProductMeasurement(ProductMeasurementBO productmeasurementBO)
	{
			this.Id = productmeasurementBO.Id;
			this.MeasuamentId = productmeasurementBO.MeasuamentId;
			this.ProductId = productmeasurementBO.ProductId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _MeasuamentId;
	private int _ProductId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int MeasuamentId
	{ 
		get { return _MeasuamentId; }
		set { _MeasuamentId = value; }
	}
	public int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
