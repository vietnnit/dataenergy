using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using DAO;
using ETO;

namespace BSO
{
    public class RoleCateService
    {

        RoleCateDao rolecateDao = new RoleCateDao();
        public int Insert(RoleCate obj)
        {
            RoleCateBO rolecateBO = new RoleCateBO(obj);
            return rolecateDao.Insert(rolecateBO);
        }
        public RoleCate Update(RoleCate obj)
        {
            RoleCateBO rolecateBO = new RoleCateBO(obj);
            rolecateDao.Update(rolecateBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return rolecateDao.Delete(_Id);
        }
        public RoleCate FindByKey(int _Id)
        {
            return new RoleCate(rolecateDao.FindByKey(_Id));
        }
        public IList<RoleCate> FindAll()
        {
            IList<RoleCate> list = new List<RoleCate>();
            IList<RoleCateBO> listBO = new List<RoleCateBO>();
            listBO = rolecateDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (RoleCateBO obj in listBO)
                    list.Add(new RoleCate(obj));
            return list;
        }

    }
}
