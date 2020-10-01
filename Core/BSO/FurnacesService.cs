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
    public class FurnacesService
    {

        FurnacesDao furnacesDao = new FurnacesDao();
        public int Insert(Furnaces obj)
        {
            FurnacesBO furnacesBO = new FurnacesBO(obj);
            return furnacesDao.Insert(furnacesBO);
        }
        public Furnaces Update(Furnaces obj)
        {
            FurnacesBO furnacesBO = new FurnacesBO(obj);
            furnacesDao.Update(furnacesBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return furnacesDao.Delete(_Id);
        }
        public Furnaces FindByKey(int _Id)
        {
            return new Furnaces(furnacesDao.FindByKey(_Id));
        }
        public IList<Furnaces> FindAll()
        {
            IList<Furnaces> list = new List<Furnaces>();
            IList<FurnacesBO> listBO = new List<FurnacesBO>();
            listBO = furnacesDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (FurnacesBO obj in listBO)
                    list.Add(new Furnaces(obj));
            return list;
        }
        public DataTable GetFurnacesByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataTable("SELECT B.*, F.FuelName FROM  " + new FurnacesBO().TableName + " as B INNER JOIN " + new FuelBO().TableName + " as F ON F.Id=B.FuelId WHERE B.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
