using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace ePower.DE.Domain
{
	public class ProductConsumeBO : BaseEntity
	{

	#region Constructor
	public ProductConsumeBO()
	{}
	

	public ProductConsumeBO(ProductConsume productconsumeDTO)
	{
		this.Id = productconsumeDTO.Id;
		this.ProductId = productconsumeDTO.ProductId;
		this.Quantity = productconsumeDTO.Quantity;
		this.AuditReportId = productconsumeDTO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProductId;
	private decimal _Quantity;
	private int _AuditReportId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "DE_ProductConsume"; }
		set { base.TableName = "DE_ProductConsume"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ProductId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value;SetDirty("ProductId"); }
	}
	[FieldName("Quantity", FieldAccessMode.ReadWrite, FieldType.String)]
	public  decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value;SetDirty("Quantity"); }
	}
	[FieldName("AuditReportId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value;SetDirty("AuditReportId"); }
	}
	#endregion

	}
}
