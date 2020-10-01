using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class TOEBO : BaseEntity
	{

	#region Constructor
	public TOEBO()
	{}
	

	public TOEBO(TOE toeDTO)
	{
		this.Id = toeDTO.Id;
		this.TOEName = toeDTO.TOEName;
		this.Description = toeDTO.Description;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _TOEName;
	private string _Description;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_TOE"; }
		set { base.TableName = "DE_TOE"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("TOEName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string TOEName
	{ 
		get { return _TOEName; }
		set { _TOEName = value;SetDirty("TOEName"); }
	}
	[FieldName("Description", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Description
	{ 
		get { return _Description; }
		set { _Description = value;SetDirty("Description"); }
	}
	#endregion

	}
}
