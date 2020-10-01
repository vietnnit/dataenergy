using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class Province
	{

	#region Constructor
	public Province()
	{}
	
	public Province(ProvinceBO provinceBO)
	{
			this.Id = provinceBO.Id;
			this.ProvinceName = provinceBO.ProvinceName;
			this.RegionId = provinceBO.RegionId;
			this.SortOrder = provinceBO.SortOrder;
			this.ProvinceCode = provinceBO.ProvinceCode;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _ProvinceName;
	private int _RegionId;
	private int _SortOrder;
	private string _ProvinceCode;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string ProvinceName
	{ 
		get { return _ProvinceName; }
		set { _ProvinceName = value; }
	}
	public int RegionId
	{ 
		get { return _RegionId; }
		set { _RegionId = value; }
	}
	public int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value; }
	}
	public string ProvinceCode
	{ 
		get { return _ProvinceCode; }
		set { _ProvinceCode = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
