using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using PR.Domain;

namespace PR.Dao
{
    public class ProjectArticleDao : EntityDao<ProjectArticleBO>
    {
        public DataTable GetNewsByProject(int ProjectId, DateTime? fromDate, DateTime? toDate, string keyword, PagingInfo paging)
        {
            DataTable list = new DataTable();
            DbParameter[] parameter = new DbParameter[6];
            parameter[0] = new DbParameter("@ProjectId", ProjectId);
            parameter[1] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[2] = new DbParameter("@PageSize", paging.PageSize);
            if (fromDate != null)
                parameter[3] = new DbParameter("@FromDate", fromDate);
            else
                parameter[3] = new DbParameter("@FromDate", DBNull.Value);
            if (toDate != null)
                parameter[4] = new DbParameter("@ToDate", toDate);
            else
                parameter[4] = new DbParameter("@ToDate", DBNull.Value);
            parameter[5] = new DbParameter("@Keyword", keyword);
            try
            {
                list = new Db().GetDataTable("Get_NewsBy_Project", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
