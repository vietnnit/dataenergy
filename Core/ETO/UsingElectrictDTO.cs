using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class UsingElectrict
	{

	#region Constructor
	public UsingElectrict()
	{}
	
	public UsingElectrict(UsingElectrictBO usingelectrictBO)
	{
			this.Id = usingelectrictBO.Id;
			this.ReportYear = usingelectrictBO.ReportYear;
			this.IsPlan = usingelectrictBO.IsPlan;
			this.ReportId = usingelectrictBO.ReportId;
			this.FuelId = usingelectrictBO.FuelId;
			this.BuyCost = usingelectrictBO.BuyCost;
			this.Quantity = usingelectrictBO.Quantity;
			this.Capacity = usingelectrictBO.Capacity;
			this.InstalledCapacity = usingelectrictBO.InstalledCapacity;
			this.ProduceQty = usingelectrictBO.ProduceQty;
			this.PriceProduce = usingelectrictBO.PriceProduce;
			this.Technology = usingelectrictBO.Technology;
			this.PriceBuy = usingelectrictBO.PriceBuy;
			this.AvgPrice = usingelectrictBO.AvgPrice;
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
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ReportYear
	{ 
		get { return _ReportYear; }
		set { _ReportYear = value; }
	}
	public bool IsPlan
	{ 
		get { return _IsPlan; }
		set { _IsPlan = value; }
	}
	public int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value; }
	}
	public int FuelId
	{ 
		get { return _FuelId; }
		set { _FuelId = value; }
	}
	public decimal BuyCost
	{ 
		get { return _BuyCost; }
		set { _BuyCost = value; }
	}
	public decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public decimal Capacity
	{ 
		get { return _Capacity; }
		set { _Capacity = value; }
	}
	public decimal InstalledCapacity
	{ 
		get { return _InstalledCapacity; }
		set { _InstalledCapacity = value; }
	}
	public decimal ProduceQty
	{ 
		get { return _ProduceQty; }
		set { _ProduceQty = value; }
	}
	public decimal PriceProduce
	{ 
		get { return _PriceProduce; }
		set { _PriceProduce = value; }
	}
	public string Technology
	{ 
		get { return _Technology; }
		set { _Technology = value; }
	}
	public decimal PriceBuy
	{ 
		get { return _PriceBuy; }
		set { _PriceBuy = value; }
	}
	public decimal AvgPrice
	{ 
		get { return _AvgPrice; }
		set { _AvgPrice = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
