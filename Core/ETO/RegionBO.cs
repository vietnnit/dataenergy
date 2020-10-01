using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class RegionBO : BaseEntity
	{

	#region Constructor
	public RegionBO()
	{}
	

	public RegionBO(Region regionDTO)
	{
		this.RegionName = regionDTO.RegionName;
		this.Id = regionDTO.Id;
		this.SortOrder = regionDTO.SortOrder;
	}
	#endregion

	#region Private Variables
	private string _RegionName;
	private int _Id;
	private int _SortOrder;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_Region"; }
		set { base.TableName = "DE_Region"; }
	}
	
	[FieldName("RegionName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string RegionName
	{ 
		get { return _RegionName; }
		set { _RegionName = value;SetDirty("RegionName"); }
	}
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("SortOrder", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int SortOrder
	{ 
		get { return _SortOrder; }
		set { _SortOrder = value;SetDirty("SortOrder"); }
	}
	#endregion

	}
}
