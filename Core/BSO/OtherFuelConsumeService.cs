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
    public class OtherFuelConsumeService
    {

        OtherFuelConsumeDao otherfuelconsumeDao = new OtherFuelConsumeDao();
        public int Insert(OtherFuelConsume obj)
        {
            OtherFuelConsumeBO otherfuelconsumeBO = new OtherFuelConsumeBO(obj);
            return otherfuelconsumeDao.Insert(otherfuelconsumeBO);
        }
        public OtherFuelConsume Update(OtherFuelConsume obj)
        {
            OtherFuelConsumeBO otherfuelconsumeBO = new OtherFuelConsumeBO(obj);
            otherfuelconsumeDao.Update(otherfuelconsumeBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return otherfuelconsumeDao.Delete(_Id);
        }
        public OtherFuelConsume FindByKey(int _Id)
        {
            return new OtherFuelConsume(otherfuelconsumeDao.FindByKey(_Id));
        }
        public IList<OtherFuelConsume> FindAll()
        {
            IList<OtherFuelConsume> list = new List<OtherFuelConsume>();
            IList<OtherFuelConsumeBO> listBO = new List<OtherFuelConsumeBO>();
            listBO = otherfuelconsumeDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (OtherFuelConsumeBO obj in listBO)
                    list.Add(new OtherFuelConsume(obj));
            return list;
        }
        public DataSet GetAuditFuel(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataSet("GetAuditFuel", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetDataByFuel(int ReportId, int FuelId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@FuelId", FuelId);
            try
            {
                return new Db().GetDataTable("GetDataByFuel", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int DeleteByFuel(int ReportId, int FuelId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@FuelId", FuelId);
            try
            {
                return new Db().Delete("Delete from " + new OtherFuelConsumeBO().TableName + " WHERE AuditReportId=@ReportId AND FuelId=@FuelId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
