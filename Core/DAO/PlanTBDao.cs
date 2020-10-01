using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class PlanTBDao : EntityDao<PlanTBBO>
    {
        public DataTable GetPlanTBEnterprise(int OrganizationId, Int32 IdKH, bool blIsFiveYear, bool blIsPlan)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@OrganizationId", OrganizationId);

            parameter[1] = new DbParameter("@IdKH", IdKH);
            parameter[2] = new DbParameter("@IsFiveYear", blIsFiveYear);
            parameter[3] = new DbParameter("@IsPlan", blIsPlan);

            return new Db().GetDataTable("reportPlanTB", parameter, System.Data.CommandType.StoredProcedure);
        }
    }
}
