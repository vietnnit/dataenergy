using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class TOEYearBO : BaseEntity
	{

	#region Constructor
	public TOEYearBO()
	{}
	

	public TOEYearBO(TOEYear toeyearDTO)
	{
		this.Id = toeyearDTO.Id;
		this.TOEId = toeyearDTO.TOEId;
		this.Year = toeyearDTO.Year;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _TOEId;
	private int _Year;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_TOEYear"; }
		set { base.TableName = "DE_TOEYear"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("TOEId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int TOEId
	{ 
		get { return _TOEId; }
		set { _TOEId = value;SetDirty("TOEId"); }
	}
	[FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Year
	{ 
		get { return _Year; }
		set { _Year = value;SetDirty("Year"); }
	}
	#endregion

	}
}
