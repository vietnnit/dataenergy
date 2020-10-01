using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class EnterpriseDao : EntityDao<EnterpriseBO>
    {
        //public IList<Enterprise> GetEnterpriseByOrg(int OrgId)
        //{
        //    IList<Enterprise> list = new List<Enterprise>();
        //    DbParameter[] parameter = new DbParameter[1];
        //    parameter[0] = new DbParameter("@OrgId", OrgId);
        //    list = new Db().GetList<Enterprise>("SELECT * FROM " + new EnterpriseBO().TableName + " WHERE OrganizationId=@OrgId", parameter, System.Data.CommandType.Text);
        //    return list;
        //}
        public IList<Enterprise> FindList(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, bool? blActive, string keyword, PagingInfo paging)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[10];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (blActive != null)
                parameter[5] = new DbParameter("@IsActive", blActive);
            else
                parameter[5] = new DbParameter("@IsActive", DBNull.Value);
            parameter[6] = new DbParameter("@Keyword", keyword);
            parameter[7] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[8] = new DbParameter("@PageSize", paging.PageSize);
            parameter[9] = new DbParameter("@Year", Year);

            try
            {
                list = new Db().GetList<Enterprise>("Get_Enterprise_Find", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataTable GetDataTable(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, bool? blActive, string keyword, PagingInfo paging)
        {
            DataTable list = new DataTable();
            DbParameter[] parameter = new DbParameter[10];
            parameter[0] = new DbParameter("@AreaId", AreaId);
            parameter[1] = new DbParameter("@SubAreaId", SubAreaId);
            parameter[2] = new DbParameter("@ProvinceId", ProvinceId);
            parameter[3] = new DbParameter("@DistrictId", DistrictId);
            parameter[4] = new DbParameter("@OrgId", OrgId);
            if (blActive != null)
                parameter[5] = new DbParameter("@IsActive", blActive);
            else
                parameter[5] = new DbParameter("@IsActive", DBNull.Value);
            parameter[6] = new DbParameter("@Keyword", keyword);
            parameter[7] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[8] = new DbParameter("@PageSize", paging.PageSize);
            parameter[9] = new DbParameter("@Year", Year);

            try
            {
                list = new Db().GetDataTable("Get_Enterprise_Find", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public IList<Enterprise> GetEnterpriseByOrg(int OrgId)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@OrgId", OrgId);
            try
            {
                list = new Db().GetList<Enterprise>("SELECT * FROM " + new EnterpriseBO().TableName + " WHERE OrganizationId=@OrgId ORDER BY Title ASC", parameter, System.Data.CommandType.Text);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataTable GetDataEnterpriseByOrg(int OrgId)
        {
            IList<Enterprise> list = new List<Enterprise>();
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@OrgId", OrgId);
            try
            {
                return new Db().GetDataTable("SELECT * FROM " + new EnterpriseBO().TableName + " WHERE OrganizationId=@OrgId ORDER BY Id DESC", parameter, System.Data.CommandType.Text);
                //return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int GetNoAccount(int OrgId)
        {

            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@OrgId", OrgId);
            DataTable dt = new Db().GetDataTable("SELECT COUNT(*) as NoAccount FROM " + new EnterpriseBO().TableName + " WHERE OrganizationId=@OrgId", parameter, System.Data.CommandType.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["NoAccount"]) + 1;
            }

            return 1;

        }
        public DataTable GetDNByName(string strName, int OrgId)
        {

            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@OrgId", OrgId);
            parameter[1] = new DbParameter("@Title", strName);
            DataTable dt = new Db().GetDataTable("SELECT Id, Title, OrganizationId FROM " + new EnterpriseBO().TableName + " WHERE OrganizationId=@OrgId AND Title=@Title", parameter, System.Data.CommandType.Text);
            return dt;

        }
        public int Delete(int EnterpriseId, string username, string strComment)
        {

            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            parameter[1] = new DbParameter("@UserName", username);
            parameter[2] = new DbParameter("@Comment", strComment);
            return new Db().Delete("DeleteEnterprise", parameter, System.Data.CommandType.StoredProcedure);
        }
        public int Delete(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            return new Db().Delete("UPDATE " + new EnterpriseBO().TableName + " SET IsDelete=1 WHERE Id=@EnterpriseId UPDATE " + new MemberBO().TableName + " SET IsDelete=1,IsActive=0 WHERE EnterpriseId=@EnterpriseId ", parameter, System.Data.CommandType.Text);
        }
    }

}
