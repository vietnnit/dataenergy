using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class EnterpriseYearBO : BaseEntity
	{

	#region Constructor
	public EnterpriseYearBO()
	{}
	

	public EnterpriseYearBO(EnterpriseYear enterpriseyearDTO)
	{
		this.Id = enterpriseyearDTO.Id;
		this.Year = enterpriseyearDTO.Year;
		this.EnterpriseId = enterpriseyearDTO.EnterpriseId;
		this.IsDelete = enterpriseyearDTO.IsDelete;
		this.No_TOE = enterpriseyearDTO.No_TOE;
		this.IsKey = enterpriseyearDTO.IsKey;
		this.NoTOE_Plan = enterpriseyearDTO.NoTOE_Plan;
		this.ReportId = enterpriseyearDTO.ReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _Year;
	private int _EnterpriseId;
	private bool _IsDelete;
	private decimal _No_TOE;
	private bool _IsKey;
	private decimal _NoTOE_Plan;
	private int _ReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_EnterpriseYear"; }
		set { base.TableName = "DE_EnterpriseYear"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("Year", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int Year
	{ 
		get { return _Year; }
		set { _Year = value;SetDirty("Year"); }
	}
	[FieldName("EnterpriseId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int EnterpriseId
	{ 
		get { return _EnterpriseId; }
		set { _EnterpriseId = value;SetDirty("EnterpriseId"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("No_TOE", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal No_TOE
	{ 
		get { return _No_TOE; }
		set { _No_TOE = value;SetDirty("No_TOE"); }
	}
	[FieldName("IsKey", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsKey
	{ 
		get { return _IsKey; }
		set { _IsKey = value;SetDirty("IsKey"); }
	}
	[FieldName("NoTOE_Plan", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal NoTOE_Plan
	{ 
		get { return _NoTOE_Plan; }
		set { _NoTOE_Plan = value;SetDirty("NoTOE_Plan"); }
	}
	[FieldName("ReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ReportId
	{ 
		get { return _ReportId; }
		set { _ReportId = value;SetDirty("ReportId"); }
	}
	#endregion

	}
}
