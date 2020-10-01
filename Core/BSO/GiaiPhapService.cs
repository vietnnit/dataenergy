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
    public class GiaiPhapService
    {

        GiaiPhapDao giaiphapDao = new GiaiPhapDao();
        public int Insert(GiaiPhap obj)
        {
            GiaiPhapBO giaiphapBO = new GiaiPhapBO(obj);
            return giaiphapDao.Insert(giaiphapBO);
        }
        public GiaiPhap Update(GiaiPhap obj)
        {
            GiaiPhapBO giaiphapBO = new GiaiPhapBO(obj);
            giaiphapDao.Update(giaiphapBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return giaiphapDao.Delete(_Id);
        }
        public GiaiPhap FindByKey(int _Id)
        {
            return new GiaiPhap(giaiphapDao.FindByKey(_Id));
        }
        public DataTable GetGiaiPhepByEnerprise(int OrganizationId)
        {
            return giaiphapDao.GetGiaiPhepByEnerprise(OrganizationId);
        }
        public DataTable GetSolutionYear(int FromYear, int ToYear, int EnterpriseId)
        {
            return giaiphapDao.GetSolutionYear(FromYear, ToYear, EnterpriseId);
        }
        public IList<GiaiPhap> FindAll()
        {
            IList<GiaiPhap> list = new List<GiaiPhap>();
            IList<GiaiPhapBO> listBO = new List<GiaiPhapBO>();
            listBO = giaiphapDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (GiaiPhapBO obj in listBO)
                    list.Add(new GiaiPhap(obj));
            return list;
        }
        public DataTable FindList(int EnterpriseId, string keyword, PagingInfo paging)
        {
            return giaiphapDao.FindList(EnterpriseId, keyword, paging);
        }

    }
}
