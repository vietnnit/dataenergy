using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class FuelBO : BaseEntity
	{

	#region Constructor
	public FuelBO()
	{}
	

	public FuelBO(Fuel fuelDTO)
	{
		this.Id = fuelDTO.Id;
		this.MeasurementId = fuelDTO.MeasurementId;
		this.GroupFuelId = fuelDTO.GroupFuelId;
		this.FuelName = fuelDTO.FuelName;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _MeasurementId;
	private int _GroupFuelId;
	private string _FuelName;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Fuel"; }
		set { base.TableName = "DE_Fuel"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("MeasurementId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasurementId
	{ 
		get { return _MeasurementId; }
		set { _MeasurementId = value;SetDirty("MeasurementId"); }
	}
	[FieldName("GroupFuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int GroupFuelId
	{ 
		get { return _GroupFuelId; }
		set { _GroupFuelId = value;SetDirty("GroupFuelId"); }
	}
	[FieldName("FuelName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FuelName
	{ 
		get { return _FuelName; }
		set { _FuelName = value;SetDirty("FuelName"); }
	}
	#endregion

	}
}
