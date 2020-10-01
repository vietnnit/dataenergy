using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Core;

namespace PR.Domain
{
	public class ProjectArticle
	{

	#region Constructor
	public ProjectArticle()
	{}
	
	public ProjectArticle(ProjectArticleBO projectarticleBO)
	{
			this.Id = projectarticleBO.Id;
			this.ArticleId = projectarticleBO.ArticleId;
			this.ProjectId = projectarticleBO.ProjectId;
	}
	#endregion

	#region Private Variables
	private int _Id;
	private int _ArticleId;
	private int _ProjectId;
	private int _Total;
	#endregion

	#region Public Properties
	
	public int Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	public int ArticleId
	{ 
		get { return _ArticleId; }
		set { _ArticleId = value; }
	}
	public int ProjectId
	{ 
		get { return _ProjectId; }
		set { _ProjectId = value; }
	}
	
	public int Total
	{
	get { return _Total; }
	set { _Total = value; }
	}
	#endregion Public Properties

	}
}
