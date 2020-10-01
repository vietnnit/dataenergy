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
    public class OrganizationService
    {

        OrganizationDao organizationDao = new OrganizationDao();
        public int Insert(Organization obj)
        {
            OrganizationBO organizationBO = new OrganizationBO(obj);
            return organizationDao.Insert(organizationBO);
        }
        public Organization Update(Organization obj)
        {
            OrganizationBO organizationBO = new OrganizationBO(obj);
            organizationDao.Update(organizationBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return organizationDao.Delete(_Id);
        }
        public Organization FindByKey(int _Id)
        {
            return new Organization(organizationDao.FindByKey(_Id));
        }
        public IList<Organization> FindAll()
        {
            IList<Organization> list = new List<Organization>();
            IList<OrganizationBO> listBO = new List<OrganizationBO>();
            listBO = organizationDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (OrganizationBO obj in listBO)
                    list.Add(new Organization(obj));
            return list;
        }

        public DataTable FindOrganizationList(string keyword, int provinceId, PagingInfo paging, bool bPaging)
        {
            return organizationDao.FindOrganizationList(keyword, provinceId, paging, bPaging);
        }

    }
}
