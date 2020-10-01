using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class RegionProvinceBO : BaseEntity
	{

	#region Constructor
	public RegionProvinceBO()
	{}
	

	public RegionProvinceBO(RegionProvince regionprovinceDTO)
	{
		this.ProvinceId = regionprovinceDTO.ProvinceId;
		this.Id = regionprovinceDTO.Id;
		this.RegionId = regionprovinceDTO.RegionId;
	}
	#endregion

	#region Private Variables
	private int _ProvinceId;
	private int _Id;
	private int _RegionId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_RegionProvince"; }
		set { base.TableName = "DE_RegionProvince"; }
	}
	
	[FieldName("ProvinceId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProvinceId
	{ 
		get { return _ProvinceId; }
		set { _ProvinceId = value;SetDirty("ProvinceId"); }
	}
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("RegionId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int RegionId
	{ 
		get { return _RegionId; }
		set { _RegionId = value;SetDirty("RegionId"); }
	}
	#endregion

	}
}
