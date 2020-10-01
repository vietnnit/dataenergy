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
    public class DistrictService
    {

        DistrictDao districtDao = new DistrictDao();
        public int Insert(District obj)
        {
            DistrictBO districtBO = new DistrictBO(obj);
            return districtDao.Insert(districtBO);
        }
        public District Update(District obj)
        {
            DistrictBO districtBO = new DistrictBO(obj);
            districtDao.Update(districtBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return districtDao.Delete(_Id);
        }
        public District FindByKey(int _Id)
        {
            return new District(districtDao.FindByKey(_Id));
        }
        public IList<District> FindAll()
        {
            IList<District> list = new List<District>();
            IList<DistrictBO> listBO = new List<DistrictBO>();
            listBO = districtDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (DistrictBO obj in listBO)
                    list.Add(new District(obj));
            return list;
        }
        public DataTable FindList(int ProvinceId, string keyword, PagingInfo paging)
        {
            return districtDao.FindList(ProvinceId, keyword, paging);
        }
    }
}
