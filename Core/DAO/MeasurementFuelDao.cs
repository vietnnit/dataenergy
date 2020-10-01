using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
	public class MeasurementFuelDao: EntityDao<MeasurementFuelBO>
	{
        public DataTable GetMeasurementByFuel(int FuelId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@FuelId", FuelId);
            return new Db().GetDataTable("SELECT a.Id,a.FuelId,a.TOE,a.From_TOE,a.To_TOE,a.NoCO2,a.MeasurementId,b.MeasurementName,c.FuelName FROM " + new MeasurementFuelBO().TableName + " a inner join " + new MeasurementBO().TableName + " b on b.Id=a.MeasurementId inner join " + new FuelBO().TableName + " c on c.Id=a.FuelId where a.FuelId=@FuelId order by c.FuelName,b.MeasurementName", parameter, System.Data.CommandType.Text);
        }
	}
}
