using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class PlanTKNLDao: EntityDao<PlanTKNLBO>
	{
        public DataTable GetPlanTKNLEnerprise(int OrganizationId, Int32 IdKH, bool blIsFiveYear, bool blIsPlan)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@OrganizationId", OrganizationId);

            parameter[1] = new DbParameter("@IdKH", IdKH);
            parameter[2] = new DbParameter("@IsFiveYear", blIsFiveYear);
            parameter[3] = new DbParameter("@IsPlan", blIsPlan);
   
            return new Db().GetDataTable("reportPlanTKNL", parameter, System.Data.CommandType.StoredProcedure);
        }
        public DataTable GetResultSolution5Year(int FromYear, int ToYear, int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@FromYear", FromYear);

            parameter[1] = new DbParameter("@ToYear", ToYear);
            parameter[2] = new DbParameter("@EnterpriseId", EnterpriseId);

            return new Db().GetDataTable("GetResultTKNL", parameter, System.Data.CommandType.StoredProcedure);
        }
	}
}
