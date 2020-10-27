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
    public class ReportFuelService
    {

        ReportFuelDao reportfuelDao = new ReportFuelDao();
        public int Insert(ReportFuel obj)
        {
            ReportFuelBO reportfuelBO = new ReportFuelBO(obj);
            return reportfuelDao.Insert(reportfuelBO);
        }
        public ReportFuel Update(ReportFuel obj)
        {
            ReportFuelBO reportfuelBO = new ReportFuelBO(obj);
            reportfuelDao.Update(reportfuelBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return reportfuelDao.Delete(_Id);
        }
        public ReportFuel FindByKey(int _Id)
        {
            return new ReportFuel(reportfuelDao.FindByKey(_Id));
        }
        public IList<ReportFuel> FindAll()
        {
            IList<ReportFuel> list = new List<ReportFuel>();
            IList<ReportFuelBO> listBO = new List<ReportFuelBO>();
            listBO = reportfuelDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ReportFuelBO obj in listBO)
                    list.Add(new ReportFuel(obj));
            return list;
        }
        public DataTable GetReportByEnterprise(int EnterpriseId)
        {
            return reportfuelDao.GetReportByEnerprise(EnterpriseId);
        }
        public DataTable GetReportByxuatphieu(int IdReportfuel)
        {
            return reportfuelDao.GetReportByxuatphieu(IdReportfuel);
        }
        public DataTable FindList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            return reportfuelDao.FindList(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, SendStatus, blApproved, Year, FromDate, ToDate, keyword, paging);
        }
        public DataTable FindListWithType(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging, string ReportType)
        {
            return reportfuelDao.FindListWithType(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, SendStatus, blApproved, Year, FromDate, ToDate, keyword, paging, ReportType);
        }

        public DataTable TongHopMucNLTT(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            return reportfuelDao.TongHopMucNLTT(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, SendStatus, blApproved, Year, FromDate, ToDate, keyword, paging);
        }

        public DataTable FindWaittingList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            return reportfuelDao.FindWaittingList(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, SendStatus, blApproved, Year, FromDate, ToDate, keyword, paging);
        }
        public DataTable FindWaittingListWithType(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, string ReportType, PagingInfo paging)
        {
            return reportfuelDao.FindWaittingListWithType(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, SendStatus, blApproved, Year, FromDate, ToDate, keyword, ReportType, paging);
        }
        public DataTable FindProcessingList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            return reportfuelDao.FindProcessingList(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, blApproved, Year, FromDate, ToDate, keyword, paging);
        }

        public DataTable FindProcessingListWithType(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, string ReportType, PagingInfo paging)
        {
            return reportfuelDao.FindProcessingListWithType(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, blApproved, Year, FromDate, ToDate, keyword, ReportType, paging);
        }

        public DataTable ListBCTieuThuNangLuong(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, string Status, PagingInfo paging)
        {
            return reportfuelDao.SCTListBCTieuThuNangLuong(blReportType, AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, blApproved, Year, FromDate, ToDate, keyword, Status, paging);
        }



        public DataTable GetInfoReportFuel(int IdReportfuel)
        { return reportfuelDao.GetInfoReportFuel(IdReportfuel); }
        public DataTable GetNoTOEByEnterprise(int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int Year, string keyword, PagingInfo paging)
        {
            return reportfuelDao.GetNoTOEByEnterprise(AreaId, SubAreaId, OrgId, EnterpriseId, ProvinceId, DistrictId, Year, keyword, paging);
        }
        public DataTable GetReportTOETemp2014(int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int Year, string keyword, PagingInfo paging)
        {
            return reportfuelDao.GetReportTOETemp2014(AreaId, SubAreaId, OrgId, EnterpriseId, Year, keyword, paging);
        }
        public int ApproveReport(int ReportId, DateTime confirmDate, bool blApproved)
        {
            return reportfuelDao.ApproveReport(ReportId, confirmDate, blApproved);

        }
        public int UpdateStatusEnterprise(int ReportId, int ProcessStatus)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProcessStatus", ProcessStatus);
            return new Db().Update("UPDATE " + new ReportFuelBO().TableName + " SET SendSatus=@ProcessStatus WHERE Id=@ReportId", parameter, System.Data.CommandType.Text);
        }
        public int CheckReport(int ReportYear, int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportYear", ReportYear);
            parameter[1] = new DbParameter("@EnterpriseId", EnterpriseId);
            DataTable dt = new Db().GetDataTable("CheckReport", parameter, System.Data.CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ReportNo"]);
            }
            else
                return -1;
        }

        public int CheckReportWithType(int ReportYear, int EnterpriseId, string ReportType)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportYear", ReportYear);
            parameter[1] = new DbParameter("@EnterpriseId", EnterpriseId);
            parameter[2] = new DbParameter("@ReportType", ReportType);
            DataTable dt = new Db().GetDataTable("CheckReportWithType", parameter, System.Data.CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ReportNo"]);
            }
            else
                return -1;
        }

    }
}
