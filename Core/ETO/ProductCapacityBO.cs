using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ProductCapacityBO : BaseEntity
	{

	#region Constructor
	public ProductCapacityBO()
	{}
	

	public ProductCapacityBO(ProductCapacity productcapacityDTO)
	{
		this.ProductId = productcapacityDTO.ProductId;
		this.MaxQuantity = productcapacityDTO.MaxQuantity;
		this.DesignQuantity = productcapacityDTO.DesignQuantity;
		this.ReportId = productcapacityDTO.ReportId;
		this.RateOfCost = productcapacityDTO.RateOfCost;
		this.RateOfRevenue = productcapacityDTO.RateOfRevenue;
		this.IsPlan = productcapacityDTO.IsPlan;
		this.ReportYear = productcapacityDTO.ReportYear;
		this.Id = productcapacityDTO.Id;
	}
	#endregion

	#region Private Variables
	private int _ProductId;
	private decimal _MaxQuantity;
	private decimal _DesignQuantity;
	private int _ReportId;
	private decimal _RateOfCost;
	private decimal _RateOfRevenue;
	private bool _IsPlan;
	private int _ReportYear;
	private int _Id;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ProductCapacity"; }
		set { base.TableName = "DE_ProductCapacity"; }
	}
	
	[FieldName("ProductId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value;SetDirty("ProductId"); }
	}
	[FieldName("MaxQuantity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal MaxQuantity
	{ 
		get { return _MaxQuantity; }
		set { _MaxQuantity = value;SetDirty("MaxQuantity"); }
	}
	[FieldName("DesignQuantity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal DesignQuantity
	{ 
		get { return _DesignQuantity; }
		set { _DesignQuantity = value;SetDirty("DesignQuantity"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("RateOfCost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal RateOfCost
	{ 
		get { return _RateOfCost; }
		set { _RateOfCost = value;SetDirty("RateOfCost"); }
	}
	[FieldName("RateOfRevenue", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal RateOfRevenue
	{ 
		get { return _RateOfRevenue; }
		set { _RateOfRevenue = value;SetDirty("RateOfRevenue"); }
	}
	[FieldName("IsPlan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsPlan
	{ 
		get { return _IsPlan; }
		set { _IsPlan = value;SetDirty("IsPlan"); }
	}
	[FieldName("ReportYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportYear
	{ 
		get { return _ReportYear; }
		set { _ReportYear = value;SetDirty("ReportYear"); }
	}
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	#endregion

	}
}
