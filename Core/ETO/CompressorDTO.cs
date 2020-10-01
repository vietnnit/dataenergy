using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Compressor
	{

	#region Constructor
	public Compressor()
	{}
	
	public Compressor(CompressorBO compressorBO)
	{
			this.Id = compressorBO.Id;
			this.CompressorName = compressorBO.CompressorName;
			this.Pressure = compressorBO.Pressure;
			this.Capacity = compressorBO.Capacity;
			this.PressureLV = compressorBO.PressureLV;
			this.OperationHours = compressorBO.OperationHours;
			this.Quantity = compressorBO.Quantity;
			this.AuditReportId = compressorBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _CompressorName;
	private decimal _Pressure;
	private decimal _Capacity;
	private decimal _PressureLV;
	private int _OperationHours;
	private int _Quantity;
	private int _AuditReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string CompressorName
	{ 
		get { return _CompressorName; }
		set { _CompressorName = value; }
	}
	public decimal Pressure
	{ 
		get { return _Pressure; }
		set { _Pressure = value; }
	}
	public decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value; }
	}
	public decimal PressureLV
	{ 
		get { return _PressureLV; }
		set { _PressureLV = value; }
	}
	public int OperationHours
	{ 
		get { return _OperationHours; }
		set { _OperationHours = value; }
	}
	public int Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
