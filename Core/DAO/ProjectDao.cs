using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using PR.Domain;

namespace PR.Dao
{
    public class ProjectDao : EntityDao<ProjectBO>
    {
        public IList<Project> FindList(int AreaId, int TypeId, DateTime? fromDate, DateTime? ToDate, bool? IsActive, string keyword, PagingInfo paging)
        {
            IList<Project> list = new List<Project>();
            DbParameter[] parameter = new DbParameter[8];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@ProjectTypeId", TypeId);
            parameter[2] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[3] = new DbParameter("@PageSize", paging.PageSize);
            if (fromDate != null)
                parameter[4] = new DbParameter("@FromDate", fromDate);
            else
                parameter[4] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[5] = new DbParameter("@ToDate", ToDate);
            else
                parameter[5] = new DbParameter("@ToDate", DBNull.Value);
            if (IsActive != null)
                parameter[6] = new DbParameter("@IsActive", IsActive);
            else
                parameter[6] = new DbParameter("@IsActive", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            try
            {
                list = new Db().GetList<Project>("Get_Project_Find", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
        public DataTable GetNewProject(int item)
        {
            DataTable dt = new Db().GetDataTable("SELECT TOP " + item + " * FROM " + new ProjectBO().TableName + " WHERE IsNew=1 AND IsDelete=0 ORDER BY StartTime DESC", System.Data.CommandType.Text);
            return dt;
        }
    }
}
