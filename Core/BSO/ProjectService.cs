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
    public class ProjectService
    {

        ProjectDao projectDao = new ProjectDao();
        public int Insert(Project obj)
        {
            ProjectBO projectBO = new ProjectBO(obj);
            return projectDao.Insert(projectBO);
        }
        public Project Update(Project obj)
        {
            ProjectBO projectBO = new ProjectBO(obj);
            projectDao.Update(projectBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return projectDao.Delete(_Id);
        }
        public Project FindByKey(int _Id)
        {
            return new Project(projectDao.FindByKey(_Id));
        }
        public IList<Project> FindAll()
        {
            IList<Project> list = new List<Project>();
            IList<ProjectBO> listBO = new List<ProjectBO>();
            listBO = projectDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProjectBO obj in listBO)
                    list.Add(new Project(obj));
            return list;
        }
        public IList<Project> FindList(int AreaId, int TypeId, DateTime? fromDate, DateTime? ToDate, bool? IsActive, string keyword, PagingInfo paging)
        {
           return projectDao.FindList(AreaId, TypeId, fromDate, ToDate, IsActive, keyword, paging);

        }
        public DataTable GetNewProject(int item)
        {
            return projectDao.GetNewProject(item);
        }

    }
}
