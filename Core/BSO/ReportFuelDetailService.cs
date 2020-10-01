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
    public class ReportFuelDetailService
    {

        ReportFuelDetailDao reportfueldetailDao = new ReportFuelDetailDao();
        public int Insert(ReportFuelDetail obj)
        {
            ReportFuelDetailBO reportfueldetailBO = new ReportFuelDetailBO(obj);
            return reportfueldetailDao.Insert(reportfueldetailBO);
        }
        public ReportFuelDetail Update(ReportFuelDetail obj)
        {
            ReportFuelDetailBO reportfueldetailBO = new ReportFuelDetailBO(obj);
            reportfueldetailDao.Update(reportfueldetailBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return reportfueldetailDao.Delete(_Id);
        }
        public ReportFuelDetail FindByKey(int _Id)
        {
            return new ReportFuelDetail(reportfueldetailDao.FindByKey(_Id));
        }
        public IList<ReportFuelDetail> FindAll()
        {
            IList<ReportFuelDetail> list = new List<ReportFuelDetail>();
            IList<ReportFuelDetailBO> listBO = new List<ReportFuelDetailBO>();
            listBO = reportfueldetailDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ReportFuelDetailBO obj in listBO)
                    list.Add(new ReportFuelDetail(obj));
            return list;
        }
        public DataTable GetNoFuelDetailByReport(int ReportId, bool blIsNexYear)
        {
            return reportfueldetailDao.GetNoFuelDetailByReport(ReportId, blIsNexYear);
        }
        public DataTable GetNoFuelDetailGroupByReport(int ReportId, bool blInext)
        {
            return reportfueldetailDao.GetNoFuelDetailGroupByReport(ReportId, blInext);
        }
        public DataTable GetFuelTOEByReport(int ReportId, bool blInext)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsNext", blInext);
            return new Db().GetDataTable("GetFuelTOEByReport", parameter, System.Data.CommandType.StoredProcedure);
        }

        public DataTable GetTOEByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            return new Db().GetDataTable("GetTOEByReport", parameter, System.Data.CommandType.StoredProcedure);
        }
    }
}
