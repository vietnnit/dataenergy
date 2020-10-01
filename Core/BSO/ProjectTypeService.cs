using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using PR.Domain;
using PR.Dao;

namespace PR.Service
{
	public class ProjectTypeService
	{

ProjectTypeDao projecttypeDao = new ProjectTypeDao();
	public int Insert(ProjectType obj)
	{
		ProjectTypeBO projecttypeBO = new ProjectTypeBO(obj);
		return projecttypeDao.Insert(projecttypeBO);
	}
	public ProjectType Update(ProjectType obj)
	{
		ProjectTypeBO projecttypeBO = new ProjectTypeBO(obj);
		projecttypeDao.Update(projecttypeBO);
		return obj;
	}
	public long Delete(int _Id)
	{
		return projecttypeDao.Delete(_Id);
	}
	public ProjectType FindByKey(int _Id)
	{
		return new ProjectType(projecttypeDao.FindByKey(_Id));
	}
	public IList<ProjectType> FindAll()
	{
		IList<ProjectType> list = new List<ProjectType>();
		IList<ProjectTypeBO> listBO = new List<ProjectTypeBO>();
		listBO = projecttypeDao.FindAll();
		if (listBO != null && listBO.Count > 0)
			foreach (ProjectTypeBO obj in listBO)
			list.Add(new ProjectType(obj));
		 return list;
	}

	}
}
