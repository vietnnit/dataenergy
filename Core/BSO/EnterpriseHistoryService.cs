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
    public class EnterpriseHistoryService
    {

        EnterpriseHistoryDao enterpriseDao = new EnterpriseHistoryDao();
        public int Insert(EnterpriseHistory obj)
        {
            EnterpriseHistoryBO enterpriseBO = new EnterpriseHistoryBO(obj);
            return enterpriseDao.Insert(enterpriseBO);
        }
        public EnterpriseHistory Update(EnterpriseHistory obj)
        {
            EnterpriseHistoryBO enterpriseBO = new EnterpriseHistoryBO(obj);
            enterpriseDao.Update(enterpriseBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return enterpriseDao.Delete(_Id);
        }
        public EnterpriseHistory FindByKey(int _Id)
        {
            return new EnterpriseHistory(enterpriseDao.FindByKey(_Id));
        }
        public IList<EnterpriseHistory> FindAll()
        {
            IList<EnterpriseHistory> list = new List<EnterpriseHistory>();
            IList<EnterpriseHistoryBO> listBO = new List<EnterpriseHistoryBO>();
            listBO = enterpriseDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (EnterpriseHistoryBO obj in listBO)
                    list.Add(new EnterpriseHistory(obj));
            return list;
        }
        public IList<EnterpriseHistory> FindList(int Year, int AreaId, int SubAreaId, int OrgId, int ProvinceId, int DistrictId, bool? blActive, string keyword, PagingInfo paging)
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
        public IList<EnterpriseHistory> GetEnterpriseByOrg(int OrgId)
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

    }
}
