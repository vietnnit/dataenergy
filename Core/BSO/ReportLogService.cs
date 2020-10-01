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
    public class ReportLogService
    {

        ReportLogDao reportlogDao = new ReportLogDao();
        public int Insert(ReportLog obj)
        {
            ReportLogBO reportlogBO = new ReportLogBO(obj);
            return reportlogDao.Insert(reportlogBO);
        }
        public ReportLog Update(ReportLog obj)
        {
            ReportLogBO reportlogBO = new ReportLogBO(obj);
            reportlogDao.Update(reportlogBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return reportlogDao.Delete(_Id);
        }
        public ReportLog FindByKey(int _Id)
        {
            return new ReportLog(reportlogDao.FindByKey(_Id));
        }
        public IList<ReportLog> FindAll()
        {
            IList<ReportLog> list = new List<ReportLog>();
            IList<ReportLogBO> listBO = new List<ReportLogBO>();
            listBO = reportlogDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ReportLogBO obj in listBO)
                    list.Add(new ReportLog(obj));
            return list;
        }
        public IList<ReportLog> GetLogByReport(int ReportId, int LogType)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@LogType", LogType);
            try
            {
                return new Db().GetList<ReportLog>("SELECT * FROM  DE_ReportLog WHERE ReportId=@ReportId AND LogType=@LogType ORDER BY Id DESC", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
