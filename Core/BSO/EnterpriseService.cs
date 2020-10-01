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
    public class EnterpriseService
    {

        EnterpriseDao enterpriseDao = new EnterpriseDao();
        public int Insert(Enterprise obj)
        {
            EnterpriseBO enterpriseBO = new EnterpriseBO(obj);
            return enterpriseDao.Insert(enterpriseBO);
        }
        public Enterprise Update(Enterprise obj)
        {
            EnterpriseBO enterpriseBO = new EnterpriseBO(obj);
            enterpriseDao.Update(enterpriseBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return enterpriseDao.Delete(_Id);
        }
        public Enterprise FindByKey(int _Id)
        {
            return new Enterprise(enterpriseDao.FindByKey(_Id));
        }
        public IList<Enterprise> FindAll()
        {
            IList<Enterprise> list = new List<Enterprise>();
            IList<EnterpriseBO> listBO = new List<EnterpriseBO>();
            listBO = enterpriseDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (EnterpriseBO obj in listBO)
                    list.Add(new Enterprise(obj));
            return list;
        }
        public IList<Enterprise> FindList(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, bool? blActive, string keyword, PagingInfo paging)
        {
            return enterpriseDao.FindList(Year, AreaId, SubAreaId, OrgId, ProvinceId, DistrictId, blActive, keyword, paging);
        }

        public DataTable GetDataTable(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, bool? blActive, string keyword, PagingInfo paging)
        {
            return enterpriseDao.GetDataTable(Year,AreaId, SubAreaId, OrgId, ProvinceId, DistrictId, blActive, keyword, paging);
        }
        public DataTable GetDataEnterpriseByOrg(int OrgId)
        {
            return enterpriseDao.GetDataEnterpriseByOrg(OrgId);
        }
        public IList<Enterprise> GetEnterpriseByOrg(int OrgId)
        {
            return enterpriseDao.GetEnterpriseByOrg(OrgId);
        }
        public int GetNoAccount(int OrgId)
        {
            return enterpriseDao.GetNoAccount(OrgId);
        }
        public int Delete(int EnterpriseId, string username, string strComment)
        {
            return enterpriseDao.Delete(EnterpriseId, username, strComment);
        }
        public DataTable GetDNByName(string strName, int OrgId)
        {
            return enterpriseDao.GetDNByName(strName, OrgId);
        }
        public DataTable GetEnterpriseByYear(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, int blActive, int IsKey, string keyword, PagingInfo paging)
        {
            DataTable list = new DataTable();
            DbParameter[] parameter = new DbParameter[11];
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
            parameter[10] = new DbParameter("@IsKey", IsKey);

            try
            {
                list = new Db().GetDataTable("GetEnterpriseFind", parameter, System.Data.CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
