using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class ReportFuelDao : EntityDao<ReportFuelBO>
    {
        public int ApproveReport(int ReportId, DateTime confirmDate, bool blApproved)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ConfirmedDate", confirmDate);
            parameter[2] = new DbParameter("@ApprovedStatus", blApproved);
            return new Db().Update("UPDATE " + new ReportFuelBO().TableName + " SET ConfirmedDate=@ConfirmedDate, SendSatus=5, ApprovedSatus=@ApprovedStatus, AprovedDate=getdate() WHERE Id=@ReportId", parameter, System.Data.CommandType.Text);
        }
        public int ApproveReport(int ReportId, DateTime confirmDate)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ConfirmedDate", confirmDate);
            return new Db().Update("UPDATE " + new ReportFuelBO().TableName + " SET ConfirmedDate=@ConfirmedDate, SendSatus=1, ApprovedSatus=1, AprovedDate=getdate() WHERE Id=@ReportId", parameter, System.Data.CommandType.Text);
        }
        public DataTable GetReportByEnerprise(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            return new Db().GetDataTable("SELECT RF.* FROM DE_ReportFuel RF WHERE RF.EnterpriseId=@EnterpriseId ORDER BY RF.Year DESC, RF.ReportDate DESC", parameter, System.Data.CommandType.Text);
        }
        public DataTable GetReportByxuatphieu(int IdReportfuel)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@IdReportFuel", IdReportfuel);
            return new Db().GetDataTable("rptBaoCaoReportFuelDetail", parameter, System.Data.CommandType.StoredProcedure);
        }
        public DataTable GetInfoReportFuel(int IdReportfuel)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", IdReportfuel);
            return new Db().GetDataTable("GetInfoReportFuel", parameter, System.Data.CommandType.StoredProcedure);
        }
        public DataTable FindWaittingList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[15];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[5] = new DbParameter("@FromDate", FromDate);
            else
                parameter[5] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[6] = new DbParameter("@ToDate", ToDate);
            else
                parameter[6] = new DbParameter("@ToDate", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            parameter[8] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[9] = new DbParameter("@PageSize", paging.PageSize);
            parameter[10] = new DbParameter("@Year", Year);
            parameter[11] = new DbParameter("@SendStatus", SendStatus);
            if (blApproved != null)
                parameter[12] = new DbParameter("@ApprovedStatus", blApproved);
            else
                parameter[12] = new DbParameter("@ApprovedStatus", DBNull.Value);
            parameter[13] = new DbParameter("@Enterprise", EnterpriseId);
            parameter[14] = new DbParameter("@IsFiveYear", blReportType);

            try
            {
                return new Db().GetDataTable("Get_ReportWaitting_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataTable FindProcessingList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[14];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[5] = new DbParameter("@FromDate", FromDate);
            else
                parameter[5] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[6] = new DbParameter("@ToDate", ToDate);
            else
                parameter[6] = new DbParameter("@ToDate", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            parameter[8] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[9] = new DbParameter("@PageSize", paging.PageSize);
            parameter[10] = new DbParameter("@Year", Year);

            if (blApproved != null)
                parameter[11] = new DbParameter("@ApprovedStatus", blApproved);
            else
                parameter[11] = new DbParameter("@ApprovedStatus", DBNull.Value);
            parameter[12] = new DbParameter("@Enterprise", EnterpriseId);
            parameter[13] = new DbParameter("@IsFiveYear", blReportType);

            try
            {
                return new Db().GetDataTable("Get_ReportProcessing_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable SCTListBCTieuThuNangLuong(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, string Status, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[15];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[5] = new DbParameter("@FromDate", FromDate);
            else
                parameter[5] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[6] = new DbParameter("@ToDate", ToDate);
            else
                parameter[6] = new DbParameter("@ToDate", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            parameter[8] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[9] = new DbParameter("@PageSize", paging.PageSize);
            parameter[10] = new DbParameter("@Year", Year);

            if (blApproved != null)
                parameter[11] = new DbParameter("@ApprovedStatus", blApproved);
            else
                parameter[11] = new DbParameter("@ApprovedStatus", DBNull.Value);
            parameter[12] = new DbParameter("@Enterprise", EnterpriseId);
            parameter[13] = new DbParameter("@IsFiveYear", blReportType);
            parameter[14] = new DbParameter("@Status", Status);
            try
            {
                return new Db().GetDataTable("TTNL_SCT_Get_BaoCao_TheoTrangThai", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable FindList(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[15];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[5] = new DbParameter("@FromDate", FromDate);
            else
                parameter[5] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[6] = new DbParameter("@ToDate", ToDate);
            else
                parameter[6] = new DbParameter("@ToDate", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            parameter[8] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[9] = new DbParameter("@PageSize", paging.PageSize);
            parameter[10] = new DbParameter("@Year", Year);
            parameter[11] = new DbParameter("@SendStatus", SendStatus);
            if (blApproved != null)
                parameter[12] = new DbParameter("@ApprovedStatus", blApproved);
            else
                parameter[12] = new DbParameter("@ApprovedStatus", DBNull.Value);
            parameter[13] = new DbParameter("@Enterprise", EnterpriseId);
            parameter[14] = new DbParameter("@IsFiveYear", blReportType);

            try
            {
                return new Db().GetDataTable("Get_ReportFuel_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable TongHopMucNLTT(bool blReportType, int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int SendStatus, bool? blApproved, int Year, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[15];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[5] = new DbParameter("@FromDate", FromDate);
            else
                parameter[5] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[6] = new DbParameter("@ToDate", ToDate);
            else
                parameter[6] = new DbParameter("@ToDate", DBNull.Value);
            parameter[7] = new DbParameter("@Keyword", keyword);
            parameter[8] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[9] = new DbParameter("@PageSize", paging.PageSize);
            parameter[10] = new DbParameter("@Year", Year);
            parameter[11] = new DbParameter("@SendStatus", SendStatus);
            if (blApproved != null)
                parameter[12] = new DbParameter("@ApprovedStatus", blApproved);
            else
                parameter[12] = new DbParameter("@ApprovedStatus", DBNull.Value);
            parameter[13] = new DbParameter("@Enterprise", EnterpriseId);
            parameter[14] = new DbParameter("@IsFiveYear", blReportType);

            try
            {
                return new Db().GetDataTable("TTNL_SCT_TongHopMucNLTT", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }



        public DataTable GetNoTOEByEnterprise(int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int ProvinceId, int DistrictId, int Year, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[10];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            parameter[5] = new DbParameter("@Keyword", keyword);
            parameter[6] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[7] = new DbParameter("@PageSize", paging.PageSize);
            parameter[8] = new DbParameter("@Year", Year);
            parameter[9] = new DbParameter("@EnterpriseId", EnterpriseId);

            try
            {
                return new Db().GetDataTable("GetNoTOEByEnterprise", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public DataTable GetReportTOETemp2014(int AreaId, int SubAreaId, int OrgId, int EnterpriseId, int Year, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[8];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@OrgId", OrgId);
            parameter[3] = new DbParameter("@Keyword", keyword);
            parameter[4] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[5] = new DbParameter("@PageSize", paging.PageSize);
            parameter[6] = new DbParameter("@Year", Year);
            parameter[7] = new DbParameter("@EnterpriseId", EnterpriseId);

            try
            {
                return new Db().GetDataTable("GetReportTOETemp2014", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
