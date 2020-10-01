using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class ProductDao : EntityDao<ProductBO>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromYear"></param>
        /// <param name="toYear"></param>
        /// <param name="keyword"></param>
        /// <param name="enterpriseId"></param>
        /// <param name="paging"></param>
        /// <param name="bPaging">True : Use paging</param>
        /// <returns></returns>
        public DataTable FindProductList(int fromYear, int toYear,int isproduct, string keyword, int enterpriseId, PagingInfo paging, bool bPaging)
        {            
            DbParameter[] parameter = new DbParameter[7];
            parameter[0] = new DbParameter("@FromYear", fromYear);
            parameter[1] = new DbParameter("@ToYear", toYear);
            parameter[2] = new DbParameter("@EnterpriseId", enterpriseId);
            parameter[3] = new DbParameter("@Keyword", keyword);
            if (bPaging)
                parameter[4] = new DbParameter("@CurrentPage", paging.CurrentPage);
            else parameter[4] = new DbParameter("@CurrentPage", 0);
            parameter[5] = new DbParameter("@PageSize", paging.PageSize);
            parameter[6] = new DbParameter("@IsProduct", isproduct);
            try
            {
                 return new Db().GetDataTable("Get_Product_Find", parameter, System.Data.CommandType.StoredProcedure);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
