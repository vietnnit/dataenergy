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
    public class ReportService
    {

        ReportDao reportDao = new ReportDao();
        public int Insert(Report obj)
        {
            ReportBO reportBO = new ReportBO(obj);
            return reportDao.Insert(reportBO);
        }
        public Int32 Update(Report obj)
        {
            ReportBO reportBO = new ReportBO(obj);
            reportDao.Update(reportBO);
            return obj.Id;
        }
        public long Delete(int _Id)
        {
            return reportDao.Delete(_Id);
        }
        public Report FindByKey(int _Id)
        {
            return new Report(reportDao.FindByKey(_Id));
        }
        public IList<Report> FindAll()
        {
            IList<Report> list = new List<Report>();
            IList<ReportBO> listBO = new List<ReportBO>();
            listBO = reportDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ReportBO obj in listBO)
                    list.Add(new Report(obj));
            return list;
        }
        public DataTable GetReportByEnerprise(int AdminOrganizationId, DateTime? begindate, DateTime? enddate, string key)
        {
            return reportDao.GetReportByEnerprise(AdminOrganizationId, begindate, enddate, key);
        }
        public DataSet CountReport(int IsKey, int Year, int OrgId)
        {
            return reportDao.CountReport(IsKey, Year, OrgId);
        }

    }
}
