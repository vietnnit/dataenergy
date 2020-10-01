using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class RegionProvince
	{

	#region Constructor
	public RegionProvince()
	{}
	
	public RegionProvince(RegionProvinceBO regionprovinceBO)
	{
			this.ProvinceId = regionprovinceBO.ProvinceId;
			this.Id = regionprovinceBO.Id;
			this.RegionId = regionprovinceBO.RegionId;
	}
	#endregion

	#region Private Variables
	private int _ProvinceId;
	private int _Id;
	private int _RegionId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int ProvinceId
	{ 
		get { return _ProvinceId; }
		set { _ProvinceId = value; }
	}
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int RegionId
	{ 
		get { return _RegionId; }
		set { _RegionId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
