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
    public class ElectricSupplyingService
    {

        ElectricSupplyingDao electricsupplyingDao = new ElectricSupplyingDao();
        public int Insert(ElectricSupplying obj)
        {
            ElectricSupplyingBO electricsupplyingBO = new ElectricSupplyingBO(obj);
            return electricsupplyingDao.Insert(electricsupplyingBO);
        }
        public ElectricSupplying Update(ElectricSupplying obj)
        {
            ElectricSupplyingBO electricsupplyingBO = new ElectricSupplyingBO(obj);
            electricsupplyingDao.Update(electricsupplyingBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return electricsupplyingDao.Delete(_Id);
        }
        public ElectricSupplying FindByKey(int _Id)
        {
            return new ElectricSupplying(electricsupplyingDao.FindByKey(_Id));
        }
        public IList<ElectricSupplying> FindAll()
        {
            IList<ElectricSupplying> list = new List<ElectricSupplying>();
            IList<ElectricSupplyingBO> listBO = new List<ElectricSupplyingBO>();
            listBO = electricsupplyingDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ElectricSupplyingBO obj in listBO)
                    list.Add(new ElectricSupplying(obj));
            return list;
        }
        public DataTable GetElectrict(int ReportId, bool blIsSelf)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsSelf", blIsSelf);
            try
            {                
                return new Db().GetDataTable("SELECT * FROM  " + new ElectricSupplyingBO().TableName + " WHERE AuditReportId=@ReportId AND IsSelf=@IsSelf", parameter, System.Data.CommandType.Text);               
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
