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
    public class InfrastructureService
    {
        InfrastructureDao infrastructureDao = new InfrastructureDao();
        public int Insert(Infrastructure obj)
        {
            InfrastructureBO infrastructureBO = new InfrastructureBO(obj);
            return infrastructureDao.Insert(infrastructureBO);
        }
        public Infrastructure Update(Infrastructure obj)
        {
            InfrastructureBO infrastructureBO = new InfrastructureBO(obj);
            infrastructureDao.Update(infrastructureBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return infrastructureDao.Delete(_Id);
        }
        public Infrastructure FindByKey(int _Id)
        {
            return new Infrastructure(infrastructureDao.FindByKey(_Id));
        }
        public IList<Infrastructure> FindAll()
        {
            IList<Infrastructure> list = new List<Infrastructure>();
            IList<InfrastructureBO> listBO = new List<InfrastructureBO>();
            listBO = infrastructureDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (InfrastructureBO obj in listBO)
                    list.Add(new Infrastructure(obj));
            return list;
        }
        public Infrastructure GetInfrastructureByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                IList<Infrastructure> list = new List<Infrastructure>();
                list = new Db().GetList<Infrastructure>("SELECT * FROM  DE_Infrastructure WHERE ReportId=@ReportId", parameter, System.Data.CommandType.Text);
                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
