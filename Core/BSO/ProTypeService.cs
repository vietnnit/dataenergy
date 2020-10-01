using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using PR.Domain;
using PR.Dao;

namespace PR.Service
{
    public class ProTypeService
    {

        ProTypeDao protypeDao = new ProTypeDao();
        public int Insert(ProType obj)
        {
            ProTypeBO protypeBO = new ProTypeBO(obj);
            return protypeDao.Insert(protypeBO);
        }
        public ProType Update(ProType obj)
        {
            ProTypeBO protypeBO = new ProTypeBO(obj);
            protypeDao.Update(protypeBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return protypeDao.Delete(_Id);
        }
        public ProType FindByKey(int _Id)
        {
            return new ProType(protypeDao.FindByKey(_Id));
        }
        public IList<ProType> FindAll()
        {
            IList<ProType> list = new List<ProType>();
            IList<ProTypeBO> listBO = new List<ProTypeBO>();
            listBO = protypeDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProTypeBO obj in listBO)
                    list.Add(new ProType(obj));
            return list;
        }
        public int DeleteByProjectId(int ProjectId)
        {
            return protypeDao.DeleteByProjectId(ProjectId);
        }
        public IList<ProType> GetListByProject(int ProjectId)
        {
            IList<ProType> list = new List<ProType>();
            IList<ProTypeBO> listBO = new List<ProTypeBO>();
            listBO = protypeDao.GetListByProject(ProjectId);
            if (listBO != null && listBO.Count > 0)
                foreach (ProTypeBO obj in listBO)
                    list.Add(new ProType(obj));
            return list;
        }


    }
}
