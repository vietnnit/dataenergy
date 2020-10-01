using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class EnterpriseYearDao: EntityDao<EnterpriseYearBO>
	{
        public IList<EnterpriseYear> GetYearByEnterprise(int EnterpriseId)
        {
            IList<EnterpriseYear> list = new List<EnterpriseYear>();
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            try
            {
                list = new Db().GetList<EnterpriseYear>("SELECT * FROM " + new EnterpriseYearBO().TableName + " WHERE EnterpriseId=@EnterpriseId AND IsDelete=0 ORDER BY Year DESC", parameter, System.Data.CommandType.Text);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
	}
}
