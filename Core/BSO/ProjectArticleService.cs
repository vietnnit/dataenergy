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
    public class ProjectArticleService
    {

        ProjectArticleDao projectarticleDao = new ProjectArticleDao();
        public int Insert(ProjectArticle obj)
        {
            ProjectArticleBO projectarticleBO = new ProjectArticleBO(obj);
            return projectarticleDao.Insert(projectarticleBO);
        }
        public ProjectArticle Update(ProjectArticle obj)
        {
            ProjectArticleBO projectarticleBO = new ProjectArticleBO(obj);
            projectarticleDao.Update(projectarticleBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return projectarticleDao.Delete(_Id);
        }
        public ProjectArticle FindByKey(int _Id)
        {
            return new ProjectArticle(projectarticleDao.FindByKey(_Id));
        }
        public IList<ProjectArticle> FindAll()
        {
            IList<ProjectArticle> list = new List<ProjectArticle>();
            IList<ProjectArticleBO> listBO = new List<ProjectArticleBO>();
            listBO = projectarticleDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProjectArticleBO obj in listBO)
                    list.Add(new ProjectArticle(obj));
            return list;
        }
        public DataTable GetNewsByProject(int ProjectId, DateTime? fromDate, DateTime? toDate, string keyword, PagingInfo paging)
        {
            return projectarticleDao.GetNewsByProject(ProjectId, fromDate, toDate, keyword, paging);
        }

    }
}
