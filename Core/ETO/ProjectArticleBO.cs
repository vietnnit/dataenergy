using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;
using ePower.Core.Entity;

namespace PR.Domain
{
	public class ProjectArticleBO : BaseEntity
	{

	#region Constructor
	public ProjectArticleBO()
	{}
	

	public ProjectArticleBO(ProjectArticle projectarticleDTO)
	{
		this.Id = projectarticleDTO.Id;
		this.ArticleId = projectarticleDTO.ArticleId;
		this.ProjectId = projectarticleDTO.ProjectId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ArticleId;
	private int _ProjectId;
	#endregion

	#region Public Properties
	public override string TableName
	{
		get { return "PR_ProjectArticle"; }
		set { base.TableName = "PR_ProjectArticle"; }
	}
	
	[FieldName("Id", FieldAccessMode.ReadOnly, FieldType.Int)]
	public override int Id
	{ 
		get { return _Id; }
		set { _Id = value;SetDirty("Id"); }
	}
	[FieldName("ArticleId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ArticleId
	{ 
		get { return _ArticleId; }
		set { _ArticleId = value;SetDirty("ArticleId"); }
	}
	[FieldName("ProjectId", FieldAccessMode.ReadWrite, FieldType.Int)]
	public  int ProjectId
	{ 
		get { return _ProjectId; }
		set { _ProjectId = value;SetDirty("ProjectId"); }
	}
	#endregion

	}
}
