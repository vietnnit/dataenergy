using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class GroupFuelBO : BaseEntity
	{

	#region Constructor
	public GroupFuelBO()
	{}
	

	public GroupFuelBO(GroupFuel groupfuelDTO)
	{
		this.Title = groupfuelDTO.Title;
		this.Id = groupfuelDTO.Id;
		this.SortOrder = groupfuelDTO.SortOrder;
		this.GroupCode = groupfuelDTO.GroupCode;
		this.MeasurementName = groupfuelDTO.MeasurementName;
	}
	#endregion

	#region Private Variables
	private string _Title;
	private int _Id;
	private int _SortOrder;
	private string _GroupCode;
	private string _MeasurementName;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_GroupFuel"; }
		set { base.TableName = "DE_GroupFuel"; }
	}
	
	[FieldName("Title", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Title
	{ 
		get { return _Title; }
		set { _Title = value;SetDirty("Title"); }
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
	[FieldName("GroupCode", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string GroupCode
	{ 
		get { return _GroupCode; }
		set { _GroupCode = value;SetDirty("GroupCode"); }
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
