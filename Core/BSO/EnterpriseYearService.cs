using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;
using ePower.DE.Dao;

namespace ePower.DE.Service
{
    public class EnterpriseYearService
    {

        EnterpriseYearDao enterpriseyearDao = new EnterpriseYearDao();
        public int Insert(EnterpriseYear obj)
        {
            EnterpriseYearBO enterpriseyearBO = new EnterpriseYearBO(obj);
            return enterpriseyearDao.Insert(enterpriseyearBO);
        }
        public EnterpriseYear Update(EnterpriseYear obj)
        {
            EnterpriseYearBO enterpriseyearBO = new EnterpriseYearBO(obj);
            enterpriseyearDao.Update(enterpriseyearBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return enterpriseyearDao.Delete(_Id);
        }
        public EnterpriseYear FindByKey(int _Id)
        {
            return new EnterpriseYear(enterpriseyearDao.FindByKey(_Id));
        }
        public IList<EnterpriseYear> FindAll()
        {
            IList<EnterpriseYear> list = new List<EnterpriseYear>();
            IList<EnterpriseYearBO> listBO = new List<EnterpriseYearBO>();
            listBO = enterpriseyearDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (EnterpriseYearBO obj in listBO)
                    list.Add(new EnterpriseYear(obj));
            return list;
        }
        public IList<EnterpriseYear> GetYearByEnterprise(int EnterpriseId)
        {
            return enterpriseyearDao.GetYearByEnterprise(EnterpriseId);
        }
        public IList<EnterpriseYear> GetYearByEnterprise(int EnterpriseId, int ReportYear, int topRecord)
        {
            IList<EnterpriseYear> list = new List<EnterpriseYear>();
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            parameter[1] = new DbParameter("@ReportYear", ReportYear);
            parameter[2] = new DbParameter("@TopRecord", topRecord);
            try
            {
                list = new Db().GetList<EnterpriseYear>("GetYearByEnterprise", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int UpdateTOE(int EnterpriseId, int ReportYear, int ReportId, decimal NoTOE, decimal NoTOEPlan)
        {
            DbParameter[] parameter = new DbParameter[5];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            parameter[1] = new DbParameter("@ReportYear", ReportYear);
            parameter[2] = new DbParameter("@No_TOE", NoTOE);
            parameter[3] = new DbParameter("@NoTOE_Plan", NoTOEPlan);
            parameter[4] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().Update("UPDATE " + new EnterpriseYearBO().TableName + " SET No_TOE=@No_TOE,NoTOE_Plan=@NoTOE_Plan,ReportId=@ReportId WHERE EnterpriseId=@EnterpriseId AND [Year]= @ReportYear", parameter, System.Data.CommandType.Text);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
