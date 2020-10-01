using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class ReportTemp2014Dao: EntityDao<ReportTemp2014BO>
	{
        public DataTable GetReportByEnerprise(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            return new Db().GetDataTable("SELECT RF.* FROM DE_ReportFuel RF WHERE RF.EnterpriseId=@EnterpriseId ORDER BY RF.Year DESC, RF.ReportDate DESC", parameter, System.Data.CommandType.Text);
        }
	}
}
