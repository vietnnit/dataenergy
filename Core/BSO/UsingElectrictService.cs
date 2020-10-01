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
    public class UsingElectrictService
    {

        UsingElectrictDao usingelectrictDao = new UsingElectrictDao();
        public int Insert(UsingElectrict obj)
        {
            UsingElectrictBO usingelectrictBO = new UsingElectrictBO(obj);
            return usingelectrictDao.Insert(usingelectrictBO);
        }
        public UsingElectrict Update(UsingElectrict obj)
        {
            UsingElectrictBO usingelectrictBO = new UsingElectrictBO(obj);
            usingelectrictDao.Update(usingelectrictBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return usingelectrictDao.Delete(_Id);
        }
        public UsingElectrict FindByKey(int _Id)
        {
            return new UsingElectrict(usingelectrictDao.FindByKey(_Id));
        }
        public IList<UsingElectrict> FindAll()
        {
            IList<UsingElectrict> list = new List<UsingElectrict>();
            IList<UsingElectrictBO> listBO = new List<UsingElectrictBO>();
            listBO = usingelectrictDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (UsingElectrictBO obj in listBO)
                    list.Add(new UsingElectrict(obj));
            return list;
        }
        public UsingElectrict GetUsingElectrictByReport(int ReportId, bool blIsPlan)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsPlan", blIsPlan);
            try
            {
                IList<UsingElectrict> list = new List<UsingElectrict>();
                list = new Db().GetList<UsingElectrict>("SELECT * FROM  " + new UsingElectrictBO().TableName + " WHERE ReportId=@ReportId AND IsPlan=@IsPlan", parameter, System.Data.CommandType.Text);
                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
