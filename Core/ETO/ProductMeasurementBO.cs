using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ProductMeasurementBO : BaseEntity
	{

	#region Constructor
	public ProductMeasurementBO()
	{}
	

	public ProductMeasurementBO(ProductMeasurement productmeasurementDTO)
	{
		this.Id = productmeasurementDTO.Id;
		this.MeasuamentId = productmeasurementDTO.MeasuamentId;
		this.ProductId = productmeasurementDTO.ProductId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _MeasuamentId;
	private int _ProductId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ProductMeasurement"; }
		set { base.TableName = "DE_ProductMeasurement"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("MeasuamentId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int MeasuamentId
	{ 
		get { return _MeasuamentId; }
		set { _MeasuamentId = value;SetDirty("MeasuamentId"); }
	}
	[FieldName("ProductId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value;SetDirty("ProductId"); }
	}
	#endregion

	}
}
