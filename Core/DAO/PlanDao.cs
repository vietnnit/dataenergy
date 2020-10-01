using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class PlanDao: EntityDao<PlanBO>
	{
        public DataTable GetReportPlanEnerprise(int OrganizationId, DateTime? begindate, DateTime? enddate, string key)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@OrganizationId", OrganizationId);
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
            return new Db().GetDataTable("reportPlan", parameter, System.Data.CommandType.StoredProcedure);
        }
        public IList<PlanBO> GetPlanByReportId(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            return new Db().GetList<PlanBO>("SELECT * FROM " + new PlanBO().TableName + " WHERE ReportId=@ReportId", parameter, System.Data.CommandType.Text);
        }
	}
}
