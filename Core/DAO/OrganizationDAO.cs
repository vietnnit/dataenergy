using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class OrganizationDao : EntityDao<OrganizationBO>
    {
        public DataTable FindOrganizationList(string keyword, int provinceId, PagingInfo paging, bool bPaging)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@ProvinceId", provinceId);
            parameter[1] = new DbParameter("@Keyword", keyword);
            if (bPaging)
                parameter[2] = new DbParameter("@CurrentPage", paging.CurrentPage);
            else parameter[2] = new DbParameter("@CurrentPage", 0);
            parameter[3] = new DbParameter("@PageSize", paging.PageSize);
            try
            {
                return new Db().GetDataTable("Get_Organization_Find", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
