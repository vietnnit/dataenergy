using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class ReportFuelDetailDao : EntityDao<ReportFuelDetailBO>
    {
        public DataTable GetNoFuelDetailByReport(int ReportId, bool blIsNexYear)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsNexYear", blIsNexYear);
            return new Db().GetDataTable("GetNoFuelDetailByReport", parameter, System.Data.CommandType.StoredProcedure);
        }
        public DataTable GetNoFuelDetailGroupByReport(int ReportId, bool blInext)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsNext", blInext);
            return new Db().GetDataTable("Get_ReportFuelDetailGroupFuelByReport", parameter, System.Data.CommandType.StoredProcedure);
        }

    }
}
