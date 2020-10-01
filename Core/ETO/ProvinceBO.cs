using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ProvinceBO : BaseEntity
	{

	#region Constructor
	public ProvinceBO()
	{}
	

	public ProvinceBO(Province provinceDTO)
	{
		this.Id = provinceDTO.Id;
		this.ProvinceName = provinceDTO.ProvinceName;
		this.RegionId = provinceDTO.RegionId;
		this.SortOrder = provinceDTO.SortOrder;
		this.ProvinceCode = provinceDTO.ProvinceCode;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _ProvinceName;
	private int _RegionId;
	private int _SortOrder;
	private string _ProvinceCode;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Province"; }
		set { base.TableName = "DE_Province"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ProvinceName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ProvinceName
	{ 
		get { return _ProvinceName; }
		set { _ProvinceName = value;SetDirty("ProvinceName"); }
	}
	[FieldName("RegionId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int RegionId
	{ 
		get { return _RegionId; }
		set { _RegionId = value;SetDirty("RegionId"); }
	}
	[FieldName("SortOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value;SetDirty("SortOrder"); }
	}
	[FieldName("ProvinceCode", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ProvinceCode
	{ 
		get { return _ProvinceCode; }
		set { _ProvinceCode = value;SetDirty("ProvinceCode"); }
	}
	#endregion

	}
}
