using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace PR.Domain
{
	public class Project
	{

	#region Constructor
	public Project()
	{}
	
	public Project(ProjectBO projectBO)
	{
			this.Id = projectBO.Id;
			this.ProjectName = projectBO.ProjectName;
			this.AreaId = projectBO.AreaId;
			this.ProjectTypeId = projectBO.ProjectTypeId;
			this.Place = projectBO.Place;
			this.P = projectBO.P;
			this.Q = projectBO.Q;
			this.StartTime = projectBO.StartTime;
			this.EndTime = projectBO.EndTime;
			this.FullDescription = projectBO.FullDescription;
			this.IsDelete = projectBO.IsDelete;
			this.IsActive = projectBO.IsActive;
			this.GoogleMaps = projectBO.GoogleMaps;
			this.ImageThumb = projectBO.ImageThumb;
			this.ImageLarge = projectBO.ImageLarge;
			this.IsNew = projectBO.IsNew;
			this.Technology = projectBO.Technology;
			this.Investor = projectBO.Investor;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private string _ProjectName;
	private int _AreaId;
	private int _ProjectTypeId;
	private string _Place;
    private string _P;
    private string _Q;
	private System.DateTime _StartTime;
	private System.DateTime _EndTime;
	private string _FullDescription;
	private bool _IsDelete;
	private bool _IsActive;
	private string _GoogleMaps;
	private string _ImageThumb;
	private string _ImageLarge;
	private bool _IsNew;
	private string _Technology;
	private string _Investor;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public string ProjectName
	{ 
		get { return _ProjectName; }
		set { _ProjectName = value; }
	}
	public int AreaId
	{ 
		get { return _AreaId; }
		set { _AreaId = value; }
	}
	public int ProjectTypeId
	{ 
		get { return _ProjectTypeId; }
		set { _ProjectTypeId = value; }
	}
	public string Place
	{ 
		get { return _Place; }
		set { _Place = value; }
	}
    public string P
	{ 
		get { return _P; }
		set { _P = value; }
	}
    public string Q
	{ 
		get { return _Q; }
		set { _Q = value; }
	}
	public System.DateTime StartTime
	{ 
		get { return _StartTime; }
		set { _StartTime = value; }
	}
	public System.DateTime EndTime
	{ 
		get { return _EndTime; }
		set { _EndTime = value; }
	}
	public string FullDescription
	{ 
		get { return _FullDescription; }
		set { _FullDescription = value; }
	}
	public bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value; }
	}
	public bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value; }
	}
	public string GoogleMaps
	{ 
		get { return _GoogleMaps; }
		set { _GoogleMaps = value; }
	}
	public string ImageThumb
	{ 
		get { return _ImageThumb; }
		set { _ImageThumb = value; }
	}
	public string ImageLarge
	{ 
		get { return _ImageLarge; }
		set { _ImageLarge = value; }
	}
	public bool IsNew
	{ 
		get { return _IsNew; }
		set { _IsNew = value; }
	}
	public string Technology
	{ 
		get { return _Technology; }
		set { _Technology = value; }
	}
	public string Investor
	{ 
		get { return _Investor; }
		set { _Investor = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
