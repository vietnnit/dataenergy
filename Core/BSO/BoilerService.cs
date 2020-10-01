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
    public class BoilerService
    {

        BoilerDao boilerDao = new BoilerDao();
        public int Insert(Boiler obj)
        {
            BoilerBO boilerBO = new BoilerBO(obj);
            return boilerDao.Insert(boilerBO);
        }
        public Boiler Update(Boiler obj)
        {
            BoilerBO boilerBO = new BoilerBO(obj);
            boilerDao.Update(boilerBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return boilerDao.Delete(_Id);
        }
        public Boiler FindByKey(int _Id)
        {
            return new Boiler(boilerDao.FindByKey(_Id));
        }
        public IList<Boiler> FindAll()
        {
            IList<Boiler> list = new List<Boiler>();
            IList<BoilerBO> listBO = new List<BoilerBO>();
            listBO = boilerDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (BoilerBO obj in listBO)
                    list.Add(new Boiler(obj));
            return list;
        }
        public DataTable GetBoilerList(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);            
            try
            {
                return new Db().GetDataTable("SELECT B.*, F.FuelName FROM  " + new BoilerBO().TableName + " as B INNER JOIN " + new FuelBO().TableName + " as F ON F.Id=B.FuelId WHERE B.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}
