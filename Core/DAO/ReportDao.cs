using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class ReportDao : EntityDao<ReportBO>
    {
        public DataTable GetReportByEnerprise(int AdminOrganizationId, DateTime? begindate, DateTime? enddate, string key)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@OrganizationId", AdminOrganizationId);
            if (begindate != null)
            {
                parameter[1] = new DbParameter("@Begin", begindate);
            }
            else
            {
                parameter[1] = new DbParameter("@Begin", DBNull.Value);
            }
            if (enddate != null)
            {
                parameter[2] = new DbParameter("@enddate", enddate);
            }
            else
            {
                parameter[2] = new DbParameter("@enddate", DBNull.Value);
            }

            parameter[3] = new DbParameter("@key", key);
            return new Db().GetDataTable("reporttaptoan", parameter, System.Data.CommandType.StoredProcedure);
        }
        public DataSet CountReport(int IsKey, int ReportYear, int OrgId)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportYear", ReportYear);
            parameter[1] = new DbParameter("@OrgId", OrgId);
            parameter[2] = new DbParameter("@IsKey", IsKey);
            return new Db().GetDataSet("CountReport", parameter, System.Data.CommandType.StoredProcedure);
        }
    }
}
