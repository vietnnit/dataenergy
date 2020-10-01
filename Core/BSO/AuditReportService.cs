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
    public class AuditReportService
    {

        AuditReportDao auditreportDao = new AuditReportDao();
        public int Insert(AuditReport obj)
        {
            AuditReportBO auditreportBO = new AuditReportBO(obj);
            return auditreportDao.Insert(auditreportBO);
        }
        public AuditReport Update(AuditReport obj)
        {
            AuditReportBO auditreportBO = new AuditReportBO(obj);
            auditreportDao.Update(auditreportBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return auditreportDao.Delete(_Id);
        }
        public AuditReport FindByKey(int _Id)
        {
            return new AuditReport(auditreportDao.FindByKey(_Id));
        }
        public IList<AuditReport> FindAll()
        {
            IList<AuditReport> list = new List<AuditReport>();
            IList<AuditReportBO> listBO = new List<AuditReportBO>();
            listBO = auditreportDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (AuditReportBO obj in listBO)
                    list.Add(new AuditReport(obj));
            return list;
        }
        public DataTable FindList(int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int Status, int AuditYear, string keyword, PagingInfo paging)
        {
            DbParameter[] parameter = new DbParameter[11];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            parameter[5] = new DbParameter("@Keyword", keyword);
            parameter[6] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[7] = new DbParameter("@PageSize", paging.PageSize);
            parameter[8] = new DbParameter("@AuditYear", AuditYear);
            parameter[9] = new DbParameter("@Status", Status);
            parameter[10] = new DbParameter("@EnterpriseId", EnterpriseId);

            try
            {
                return new Db().GetDataTable("Get_AuditReport_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetCO2ByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@AuditReportId", ReportId);
          
            try
            {
                return new Db().GetDataTable("GetCO2ByReport", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetTOEByAuditReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@AuditReportId", ReportId);

            try
            {
                return new Db().GetDataSet("GetTOEByAuditReport", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int UpdateStatus(int ReportId, int ProcessStatus)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProcessStatus", ProcessStatus);
            return new Db().Update("UPDATE " + new AuditReportBO().TableName + " SET Confirmed=getdate(),Status=@ProcessStatus WHERE Id=@ReportId", parameter, System.Data.CommandType.Text);
        }
        public int UpdateStatusFile(int ReportId, int ProcessStatus, string strPathFile)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProcessStatus", ProcessStatus);
            parameter[2] = new DbParameter("@PathFile", strPathFile);
            return new Db().Update("UPDATE " + new AuditReportBO().TableName + " SET Sent=getdate(),Status=@ProcessStatus, PathFile=@PathFile WHERE Id=@ReportId", parameter, System.Data.CommandType.Text);
        }       
    }
}
