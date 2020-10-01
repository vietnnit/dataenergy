using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class GiaiPhapDao : EntityDao<GiaiPhapBO>
    {
        public DataTable GetGiaiPhepByEnerprise(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            return new Db().GetDataTable("SELECT * FROM " + new GiaiPhapBO().TableName + " WHERE EnterpriseId= @EnterpriseId AND IsDelete=0 ORDER BY TenGiaiPhap ASC", parameter, System.Data.CommandType.Text);
        }
        public DataTable GetSolutionYear(int FromYear, int ToYear, int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@FromYear", FromYear);
            parameter[1] = new DbParameter("@ToYear", ToYear);
            parameter[2] = new DbParameter("@EnterpriseId", EnterpriseId);            

            try
            {
                return new Db().GetDataTable("GetSolutionYear", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public DataTable FindList(int EnterpriseId, string keyword, PagingInfo paging)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@Keyword", keyword);
            parameter[1] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[2] = new DbParameter("@PageSize", paging.PageSize);
            parameter[3] = new DbParameter("@EnterpriseId", EnterpriseId);

            try
            {
                return new Db().GetDataTable("Get_Solution_Find", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
