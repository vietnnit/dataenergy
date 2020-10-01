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
    public class ElectrictConsumeService
    {

        ElectrictConsumeDao electrictconsumeDao = new ElectrictConsumeDao();
        public int Insert(ElectrictConsume obj)
        {
            ElectrictConsumeBO electrictconsumeBO = new ElectrictConsumeBO(obj);
            return electrictconsumeDao.Insert(electrictconsumeBO);
        }
        public ElectrictConsume Update(ElectrictConsume obj)
        {
            ElectrictConsumeBO electrictconsumeBO = new ElectrictConsumeBO(obj);
            electrictconsumeDao.Update(electrictconsumeBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return electrictconsumeDao.Delete(_Id);
        }
        public ElectrictConsume FindByKey(int _Id)
        {
            return new ElectrictConsume(electrictconsumeDao.FindByKey(_Id));
        }
        public IList<ElectrictConsume> FindAll()
        {
            IList<ElectrictConsume> list = new List<ElectrictConsume>();
            IList<ElectrictConsumeBO> listBO = new List<ElectrictConsumeBO>();
            listBO = electrictconsumeDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ElectrictConsumeBO obj in listBO)
                    list.Add(new ElectrictConsume(obj));
            return list;
        }
        public DataTable GetElectrictConsume(int ReportId, bool blIsSelf)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsSelf", blIsSelf);
            try
            {
                return new Db().GetDataTable("SELECT * from " + new ElectrictConsumeBO().TableName + " WHERE AuditReportId=@ReportId AND IsSelf=@IsSelf", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int DeleteByReport(int ReportId, bool blSelf)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsSelf", blSelf);
            try
            {
                return new Db().Delete("Delete from " + new ElectrictConsumeBO().TableName + " WHERE AuditReportId=@ReportId AND IsSelf=@IsSelf", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
    }
}
