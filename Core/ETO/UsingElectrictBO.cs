using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class UsingElectrictBO : BaseEntity
	{

	#region Constructor
	public UsingElectrictBO()
	{}
	

	public UsingElectrictBO(UsingElectrict usingelectrictDTO)
	{
		this.Id = usingelectrictDTO.Id;
		this.ReportYear = usingelectrictDTO.ReportYear;
		this.IsPlan = usingelectrictDTO.IsPlan;
		this.ReportId = usingelectrictDTO.ReportId;
		this.FuelId = usingelectrictDTO.FuelId;
		this.BuyCost = usingelectrictDTO.BuyCost;
		this.Quantity = usingelectrictDTO.Quantity;
		this.Capacity = usingelectrictDTO.Capacity;
		this.InstalledCapacity = usingelectrictDTO.InstalledCapacity;
		this.ProduceQty = usingelectrictDTO.ProduceQty;
		this.PriceProduce = usingelectrictDTO.PriceProduce;
		this.Technology = usingelectrictDTO.Technology;
		this.PriceBuy = usingelectrictDTO.PriceBuy;
		this.AvgPrice = usingelectrictDTO.AvgPrice;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ReportYear;
	private bool _IsPlan;
	private int _ReportId;
	private int _FuelId;
	private decimal _BuyCost;
	private decimal _Quantity;
	private decimal _Capacity;
	private decimal _InstalledCapacity;
	private decimal _ProduceQty;
	private decimal _PriceProduce;
	private string _Technology;
	private decimal _PriceBuy;
	private decimal _AvgPrice;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_UsingElectrict"; }
		set { base.TableName = "DE_UsingElectrict"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ReportYear", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportYear
	{ 
		get { return _ReportYear; }
		set { _ReportYear = value;SetDirty("ReportYear"); }
	}
	[FieldName("IsPlan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsPlan
	{ 
		get { return _IsPlan; }
		set { _IsPlan = value;SetDirty("IsPlan"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	[FieldName("FuelId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value;SetDirty("FuelId"); }
	}
	[FieldName("BuyCost", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal BuyCost
	{ 
		get { return _BuyCost; }
		set { _BuyCost = value;SetDirty("BuyCost"); }
	}
	[FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value;SetDirty("Quantity"); }
	}
	[FieldName("Capacity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value;SetDirty("Capacity"); }
	}
	[FieldName("InstalledCapacity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal InstalledCapacity
	{ 
		get { return _InstalledCapacity; }
		set { _InstalledCapacity = value;SetDirty("InstalledCapacity"); }
	}
	[FieldName("ProduceQty", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal ProduceQty
	{ 
		get { return _ProduceQty; }
		set { _ProduceQty = value;SetDirty("ProduceQty"); }
	}
	[FieldName("PriceProduce", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal PriceProduce
	{ 
		get { return _PriceProduce; }
		set { _PriceProduce = value;SetDirty("PriceProduce"); }
	}
	[FieldName("Technology", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Technology
	{ 
		get { return _Technology; }
		set { _Technology = value;SetDirty("Technology"); }
	}
	[FieldName("PriceBuy", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal PriceBuy
	{ 
		get { return _PriceBuy; }
		set { _PriceBuy = value;SetDirty("PriceBuy"); }
	}
	[FieldName("AvgPrice", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal AvgPrice
	{ 
		get { return _AvgPrice; }
		set { _AvgPrice = value;SetDirty("AvgPrice"); }
	}
	#endregion

	}
}
