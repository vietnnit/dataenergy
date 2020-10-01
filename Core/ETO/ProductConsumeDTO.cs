using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class ProductConsume
	{

	#region Constructor
	public ProductConsume()
	{}
	
	public ProductConsume(ProductConsumeBO productconsumeBO)
	{
			this.Id = productconsumeBO.Id;
			this.ProductId = productconsumeBO.ProductId;
			this.Quantity = productconsumeBO.Quantity;
			this.AuditReportId = productconsumeBO.AuditReportId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ProductId;
	private decimal _Quantity;
	private int _AuditReportId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ProductId
	{ 
		get { return _ProductId; }
		set { _ProductId = value; }
	}
	public decimal Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
