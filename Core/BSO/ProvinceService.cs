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
    public class ProvinceService
    {

        ProvinceDao provinceDao = new ProvinceDao();
        public int Insert(Province obj)
        {
            ProvinceBO provinceBO = new ProvinceBO(obj);
            return provinceDao.Insert(provinceBO);
        }
        public Province Update(Province obj)
        {
            ProvinceBO provinceBO = new ProvinceBO(obj);
            provinceDao.Update(provinceBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return provinceDao.Delete(_Id);
        }
        public Province FindByKey(int _Id)
        {
            return new Province(provinceDao.FindByKey(_Id));
        }
        public IList<Province> FindAll()
        {
            IList<Province> list = new List<Province>();
            IList<ProvinceBO> listBO = new List<ProvinceBO>();
            listBO = provinceDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProvinceBO obj in listBO)
                    list.Add(new Province(obj));
            return list;
        }

        public DataTable GetProvinceList(string strKey, int regionId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@Keyword", strKey);
            parameter[1] = new DbParameter("@RegionId", regionId);
            try
            {
                return new Db().GetDataTable("Get_Province_Find", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
