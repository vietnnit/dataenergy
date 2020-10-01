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
    public class EnergyQuotaService
    {

        EnergyQuotaDao energyquotaDao = new EnergyQuotaDao();
        public int Insert(EnergyQuota obj)
        {
            EnergyQuotaBO energyquotaBO = new EnergyQuotaBO(obj);
            return energyquotaDao.Insert(energyquotaBO);
        }
        public EnergyQuota Update(EnergyQuota obj)
        {
            EnergyQuotaBO energyquotaBO = new EnergyQuotaBO(obj);
            energyquotaDao.Update(energyquotaBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return energyquotaDao.Delete(_Id);
        }
        public EnergyQuota FindByKey(int _Id)
        {
            return new EnergyQuota(energyquotaDao.FindByKey(_Id));
        }
        public IList<EnergyQuota> FindAll()
        {
            IList<EnergyQuota> list = new List<EnergyQuota>();
            IList<EnergyQuotaBO> listBO = new List<EnergyQuotaBO>();
            listBO = energyquotaDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (EnergyQuotaBO obj in listBO)
                    list.Add(new EnergyQuota(obj));
            return list;
        }

        public DataTable GetDataByFuel(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataTable("SELECT e.*,f.FuelName,m.MeasurementName FROM " + new EnergyQuotaBO().TableName + " e," + new FuelBO().TableName + " f ," + new MeasurementBO().TableName + " m  WHERE e.FuelId=f.Id AND e.MeasurementId=m.Id AND e.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetDataByFuel(int ReportId, int ProductId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProductId", ProductId);
            try
            {
                return new Db().GetDataTable("SELECT e.*,f.FuelName,m.MeasurementName FROM " + new EnergyQuotaBO().TableName + " e," + new FuelBO().TableName + " f ," + new MeasurementBO().TableName + " m  WHERE e.FuelId=f.Id AND e.MeasurementId=m.Id AND e.ProductId=@ProductId AND e.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetDataByFuel(int ReportId, int ProductId, int FuelId)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProductId", ProductId);
            parameter[2] = new DbParameter("@FuelId", FuelId);
            try
            {
                return new Db().GetDataTable("SELECT e.* FROM " + new EnergyQuotaBO().TableName + " WHERE e.FuelId=f.Id AND e.MeasurementId=m.Id AND e.ProductId=@ProductId AND e.AuditReportId=@ReportId AND e.FuelId=@FuelId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int DeleteByProduct(int ReportId, int ProductId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProductId", ProductId);
            try
            {
                return new Db().Delete("Delete FROM " + new EnergyQuotaBO().TableName + " WHERE ProductId=@ProductId AND AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int DeleteByFuel(int ReportId, int ProductId, int FuelId)
        {
            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@ProductId", ProductId);
            parameter[2] = new DbParameter("@FuelId", FuelId);
            try
            {
                return new Db().Delete("Delete FROM " + new EnergyQuotaBO().TableName + " WHERE ProductId=@ProductId AND AuditReportId=@ReportId AND FuelId=@FuelId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
