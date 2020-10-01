using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class DistrictDao: EntityDao<DistrictBO>
	{
        public DataTable FindList(int ProvinceId, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[1] = new DbParameter("@Keyword", keyword);
            parameter[2] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[3] = new DbParameter("@PageSize", paging.PageSize);

            try
            {
                return new Db().GetDataTable("Get_District_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
	}
}
