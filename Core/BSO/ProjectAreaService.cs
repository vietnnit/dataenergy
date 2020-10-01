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
    public class ProjectAreaService
    {

        ProjectAreaDao projectareaDao = new ProjectAreaDao();
        public int Insert(ProjectArea obj)
        {
            ProjectAreaBO projectareaBO = new ProjectAreaBO(obj);
            return projectareaDao.Insert(projectareaBO);
        }
        public ProjectArea Update(ProjectArea obj)
        {
            ProjectAreaBO projectareaBO = new ProjectAreaBO(obj);
            projectareaDao.Update(projectareaBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return projectareaDao.Delete(_Id);
        }
        public ProjectArea FindByKey(int _Id)
        {
            return new ProjectArea(projectareaDao.FindByKey(_Id));
        }
        public IList<ProjectArea> FindAll()
        {
            IList<ProjectArea> list = new List<ProjectArea>();
            IList<ProjectAreaBO> listBO = new List<ProjectAreaBO>();
            listBO = projectareaDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProjectAreaBO obj in listBO)
                    list.Add(new ProjectArea(obj));
            return list;
        }
      

    }
}
