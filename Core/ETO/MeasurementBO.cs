using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class MeasurementBO : BaseEntity
	{

	#region Constructor
	public MeasurementBO()
	{}
	

	public MeasurementBO(Measurement measurementDTO)
	{
		this.Id = measurementDTO.Id;
		this.MeasurementName = measurementDTO.MeasurementName;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _MeasurementName;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Measurement"; }
		set { base.TableName = "DE_Measurement"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("MeasurementName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string MeasurementName
	{ 
		get { return _MeasurementName; }
		set { _MeasurementName = value;SetDirty("MeasurementName"); }
	}
	#endregion

	}
}
