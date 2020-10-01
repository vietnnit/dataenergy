using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class FuelDao : EntityDao<FuelBO>
    {
        public DataTable FindAll(int GroupFuelId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@GroupFuelId", GroupFuelId);
            return new Db().GetDataTable("FindAllFuel", parameter, System.Data.CommandType.StoredProcedure);
        }

        public DataTable FindFuelList(string keyword, int measurementId, int groupFuelId, PagingInfo paging, bool bPaging)
        {
            DbParameter[] parameter = new DbParameter[5];
            parameter[0] = new DbParameter("@MeasurementId", measurementId);
            parameter[1] = new DbParameter("@GroupFuelId", groupFuelId);
            parameter[2] = new DbParameter("@Keyword", keyword);
            if (bPaging)
                parameter[3] = new DbParameter("@CurrentPage", paging.CurrentPage);
            else parameter[3] = new DbParameter("@CurrentPage", 0);
            parameter[4] = new DbParameter("@PageSize", paging.PageSize);
            try
            {
                return new Db().GetDataTable("Get_Fuel_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
