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
    public class FuelService
    {

        FuelDao fuelDao = new FuelDao();
        public int Insert(Fuel obj)
        {
            FuelBO fuelBO = new FuelBO(obj);
            return fuelDao.Insert(fuelBO);
        }
        public Fuel Update(Fuel obj)
        {
            FuelBO fuelBO = new FuelBO(obj);
            fuelDao.Update(fuelBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return fuelDao.Delete(_Id);
        }
        public Fuel FindByKey(int _Id)
        {
            return new Fuel(fuelDao.FindByKey(_Id));
        }
        public IList<Fuel> FindAll()
        {
            IList<Fuel> list = new List<Fuel>();
            IList<FuelBO> listBO = new List<FuelBO>();
            listBO = fuelDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (FuelBO obj in listBO)
                    list.Add(new Fuel(obj));
            return list;
        }
        public DataTable FindAll(int GroupFuelId)
        {
            return fuelDao.FindAll(GroupFuelId);
        }

        public DataTable FindFuelList(string keyword, int measurementId, int groupFuelId, PagingInfo paging, bool bPaging)
        {
            return fuelDao.FindFuelList(keyword, measurementId, groupFuelId, paging, bPaging);
        }

    }
}
