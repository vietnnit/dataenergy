using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class MeasurementFuelBO : BaseEntity
	{

	#region Constructor
	public MeasurementFuelBO()
	{}
	

	public MeasurementFuelBO(MeasurementFuel measurementfuelDTO)
	{
		this.Id = measurementfuelDTO.Id;
		this.FuelId = measurementfuelDTO.FuelId;
		this.TOE = measurementfuelDTO.TOE;
		this.From_TOE = measurementfuelDTO.From_TOE;
		this.To_TOE = measurementfuelDTO.To_TOE;
		this.MeasurementId = measurementfuelDTO.MeasurementId;
		this.TOEId = measurementfuelDTO.TOEId;
		this.NoCO2 = measurementfuelDTO.NoCO2;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_MeasurementFuel"; }
		set { base.TableName = "DE_MeasurementFuel"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal TOE
	{ 
		get { return _TOE; }
		set { _TOE = value;SetDirty("TOE"); }
	}
	[FieldName("From_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal From_TOE
	{ 
		get { return _From_TOE; }
		set { _From_TOE = value;SetDirty("From_TOE"); }
	}
	[FieldName("To_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal To_TOE
	{ 
		get { return _To_TOE; }
		set { _To_TOE = value;SetDirty("To_TOE"); }
	}
	[FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value;SetDirty("MeasurementId"); }
	}
	[FieldName("TOEId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int TOEId
	{ 
		get { return _TOEId; }
		set { _TOEId = value;SetDirty("TOEId"); }
	}
	[FieldName("NoCO2", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal NoCO2
	{ 
		get { return _NoCO2; }
		set { _NoCO2 = value;SetDirty("NoCO2"); }
	}
	#endregion

	}
}
