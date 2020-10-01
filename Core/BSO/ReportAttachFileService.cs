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
    public class ReportAttachFileService
    {

        ReportAttachFileDao reportattachfileDao = new ReportAttachFileDao();
        public int Insert(ReportAttachFile obj)
        {
            ReportAttachFileBO reportattachfileBO = new ReportAttachFileBO(obj);
            return reportattachfileDao.Insert(reportattachfileBO);
        }
        public ReportAttachFile Update(ReportAttachFile obj)
        {
            ReportAttachFileBO reportattachfileBO = new ReportAttachFileBO(obj);
            reportattachfileDao.Update(reportattachfileBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return reportattachfileDao.Delete(_Id);
        }
        public ReportAttachFile FindByKey(int _Id)
        {
            return new ReportAttachFile(reportattachfileDao.FindByKey(_Id));
        }
        public IList<ReportAttachFile> FindAll()
        {
            IList<ReportAttachFile> list = new List<ReportAttachFile>();
            IList<ReportAttachFileBO> listBO = new List<ReportAttachFileBO>();
            listBO = reportattachfileDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ReportAttachFileBO obj in listBO)
                    list.Add(new ReportAttachFile(obj));
            return list;
        }
        public IList<ReportAttachFile> GetFileByReport(int ReportId, int LogType)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@LogType", LogType);
            try
            {
                return new Db().GetList<ReportAttachFile>("SELECT * FROM  DE_ReportAttachFile WHERE ReportId=@ReportId AND ReportType=@LogType  ORDER BY Id DESC", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
