using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace PR.Domain
{
	public class ProjectBO : BaseEntity
	{

	#region Constructor
	public ProjectBO()
	{}
	

	public ProjectBO(Project projectDTO)
	{
		this.Id = projectDTO.Id;
		this.ProjectName = projectDTO.ProjectName;
		this.AreaId = projectDTO.AreaId;
		this.ProjectTypeId = projectDTO.ProjectTypeId;
		this.Place = projectDTO.Place;
		this.P = projectDTO.P;
		this.Q = projectDTO.Q;
		this.StartTime = projectDTO.StartTime;
		this.EndTime = projectDTO.EndTime;
		this.FullDescription = projectDTO.FullDescription;
		this.IsDelete = projectDTO.IsDelete;
		this.IsActive = projectDTO.IsActive;
		this.GoogleMaps = projectDTO.GoogleMaps;
		this.ImageThumb = projectDTO.ImageThumb;
		this.ImageLarge = projectDTO.ImageLarge;
		this.IsNew = projectDTO.IsNew;
		this.Technology = projectDTO.Technology;
		this.Investor = projectDTO.Investor;
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
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "PR_Project"; }
		set { base.TableName = "PR_Project"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ProjectName", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ProjectName
	{ 
		get { return _ProjectName; }
		set { _ProjectName = value;SetDirty("ProjectName"); }
	}
	[FieldName("AreaId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int AreaId
	{ 
		get { return _AreaId; }
		set { _AreaId = value;SetDirty("AreaId"); }
	}
	[FieldName("ProjectTypeId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProjectTypeId
	{ 
		get { return _ProjectTypeId; }
		set { _ProjectTypeId = value;SetDirty("ProjectTypeId"); }
	}
	[FieldName("Place", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Place
	{ 
		get { return _Place; }
		set { _Place = value;SetDirty("Place"); }
	}
	[FieldName("P", FieldAccessMode.ReadWrite, FieldType.String)]
    public string P
	{ 
		get { return _P; }
		set { _P = value;SetDirty("P"); }
	}
	[FieldName("Q", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Q
	{ 
		get { return _Q; }
		set { _Q = value;SetDirty("Q"); }
	}
	[FieldName("StartTime", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime StartTime
	{ 
		get { return _StartTime; }
		set { _StartTime = value;SetDirty("StartTime"); }
	}
	[FieldName("EndTime", FieldAccessMode.ReadWrite, FieldType.DateTime)]
	public  System.DateTime EndTime
	{ 
		get { return _EndTime; }
		set { _EndTime = value;SetDirty("EndTime"); }
	}
	[FieldName("FullDescription", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string FullDescription
	{ 
		get { return _FullDescription; }
		set { _FullDescription = value;SetDirty("FullDescription"); }
	}
	[FieldName("IsDelete", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsDelete
	{ 
		get { return _IsDelete; }
		set { _IsDelete = value;SetDirty("IsDelete"); }
	}
	[FieldName("IsActive", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsActive
	{ 
		get { return _IsActive; }
		set { _IsActive = value;SetDirty("IsActive"); }
	}
	[FieldName("GoogleMaps", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string GoogleMaps
	{ 
		get { return _GoogleMaps; }
		set { _GoogleMaps = value;SetDirty("GoogleMaps"); }
	}
	[FieldName("ImageThumb", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ImageThumb
	{ 
		get { return _ImageThumb; }
		set { _ImageThumb = value;SetDirty("ImageThumb"); }
	}
	[FieldName("ImageLarge", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string ImageLarge
	{ 
		get { return _ImageLarge; }
		set { _ImageLarge = value;SetDirty("ImageLarge"); }
	}
	[FieldName("IsNew", FieldAccessMode.ReadWrite, FieldType.String)]
	public  bool IsNew
	{ 
		get { return _IsNew; }
		set { _IsNew = value;SetDirty("IsNew"); }
	}
	[FieldName("Technology", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Technology
	{ 
		get { return _Technology; }
		set { _Technology = value;SetDirty("Technology"); }
	}
	[FieldName("Investor", FieldAccessMode.ReadWrite, FieldType.String)]
	public  string Investor
	{ 
		get { return _Investor; }
		set { _Investor = value;SetDirty("Investor"); }
	}
	#endregion

	}
}
