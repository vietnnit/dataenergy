using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace ePower.DE.Domain
{
	public class TestEquipment
	{

	#region Constructor
	public TestEquipment()
	{}
	
	public TestEquipment(TestEquipmentBO testequipmentBO)
	{
			this.Id = testequipmentBO.Id;
			this.DeviceName = testequipmentBO.DeviceName;
			this.Measurement = testequipmentBO.Measurement;
			this.Quantity = testequipmentBO.Quantity;
			this.MadeIn = testequipmentBO.MadeIn;
			this.AuditReportId = testequipmentBO.AuditReportId;
			this.SerialNo = testequipmentBO.SerialNo;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _DeviceName;
	private string _Measurement;
	private int _Quantity;
	private string _MadeIn;
	private int _AuditReportId;
	private string _SerialNo;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string DeviceName
	{ 
		get { return _DeviceName; }
		set { _DeviceName = value; }
	}
	public string Measurement
	{ 
		get { return _Measurement; }
		set { _Measurement = value; }
	}
	public int Quantity
	{ 
		get { return _Quantity; }
		set { _Quantity = value; }
	}
	public string MadeIn
	{ 
		get { return _MadeIn; }
		set { _MadeIn = value; }
	}
	public int AuditReportId
	{ 
		get { return _AuditReportId; }
		set { _AuditReportId = value; }
	}
	public string SerialNo
	{ 
		get { return _SerialNo; }
		set { _SerialNo = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
