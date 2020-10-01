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
    public class AreaService
    {

        AreaDao areaDao = new AreaDao();
        public int Insert(Area obj)
        {
            AreaBO areaBO = new AreaBO(obj);
            return areaDao.Insert(areaBO);
        }
        public Area Update(Area obj)
        {
            AreaBO areaBO = new AreaBO(obj);
            areaDao.Update(areaBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return areaDao.Delete(_Id);
        }
        public Area FindByKey(int _Id)
        {
            return new Area(areaDao.FindByKey(_Id));
        }
        public IList<Area> FindAll()
        {
            IList<Area> list = new List<Area>();
            IList<AreaBO> listBO = new List<AreaBO>();
            listBO = areaDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (AreaBO obj in listBO)
                    list.Add(new Area(obj));
            return list;
        }

        public DataTable FindList(int ParentId, string keyword, PagingInfo paging)
        {
            return areaDao.FindList(ParentId, keyword, paging);
        }
        public DataTable getAreaByName(string keyword)
        {
            return areaDao.getAreaByName(keyword);
        }
    }
}
