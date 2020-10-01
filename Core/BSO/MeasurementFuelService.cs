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
    public class MeasurementFuelService
    {

        MeasurementFuelDao measurementfuelDao = new MeasurementFuelDao();
        public int Insert(MeasurementFuel obj)
        {
            MeasurementFuelBO measurementfuelBO = new MeasurementFuelBO(obj);
            return measurementfuelDao.Insert(measurementfuelBO);
        }
        public MeasurementFuel Update(MeasurementFuel obj)
        {
            MeasurementFuelBO measurementfuelBO = new MeasurementFuelBO(obj);
            measurementfuelDao.Update(measurementfuelBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return measurementfuelDao.Delete(_Id);
        }
        public MeasurementFuel FindByKey(int _Id)
        {
            return new MeasurementFuel(measurementfuelDao.FindByKey(_Id));
        }
        public IList<MeasurementFuel> FindAll()
        {
            IList<MeasurementFuel> list = new List<MeasurementFuel>();
            IList<MeasurementFuelBO> listBO = new List<MeasurementFuelBO>();
            listBO = measurementfuelDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (MeasurementFuelBO obj in listBO)
                    list.Add(new MeasurementFuel(obj));
            return list;
        }

        public DataTable GetMeasurementByFuel(int FuelId)
        {
            return measurementfuelDao.GetMeasurementByFuel(FuelId);
        }
        public int UpdateTOE(int FuelId, int MeasurementId, decimal fromTOE, decimal toTOE)
        {
            DbParameter[] parameter = new DbParameter[4];
            parameter[0] = new DbParameter("@FuelId", FuelId);
            parameter[1] = new DbParameter("@MeasurementId", MeasurementId);
            parameter[2] = new DbParameter("@From_TOE", toTOE);
            parameter[3] = new DbParameter("@To_TOE", toTOE);
            int ret = new Db().Update("UPDATE " + new MeasurementBO().TableName + " SET FuelId=@FuelId,MeasurementId=@MeasurementId,From_TOE=@From_TOE,To_TOE=@To_TOE WHERE FuelId=@FuelId AND MeasurementId=@MeasurementId", parameter, System.Data.CommandType.Text);
            if (ret > 0)
                return ret;
            else
            {
                MeasurementFuelBO measurement = new MeasurementFuelBO();
                measurement.FuelId = FuelId;
                measurement.MeasurementId = MeasurementId;
                measurement.From_TOE = fromTOE;
                measurement.To_TOE = toTOE;
                return measurementfuelDao.Insert(measurement);
            }
        }
        public DataTable GetListMeasurement(int FuelId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@FuelId", FuelId);
            return new Db().GetDataTable("SELECT M.Id, M.MeasurementName FROM " + new MeasurementBO().TableName + " M, " + new MeasurementFuelBO().TableName + " MF WHERE MF.MeasurementId=M.Id AND MF.FuelId=@FuelId", parameter, System.Data.CommandType.Text);

        }
        public DataTable GetTOE(int FuelId, int MeasurementId)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@FuelId", FuelId);
            parameter[1] = new DbParameter("@MeasurementId", MeasurementId);
            return new Db().GetDataTable("SELECT * FROM " + new MeasurementFuelBO().TableName + " MF WHERE MF.MeasurementId=@MeasurementId AND MF.FuelId=@FuelId", parameter, System.Data.CommandType.Text);

        }
    }
}


