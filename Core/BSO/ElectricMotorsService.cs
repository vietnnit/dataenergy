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
    public class ElectricMotorsService
    {

        ElectricMotorsDao electricmotorsDao = new ElectricMotorsDao();
        public int Insert(ElectricMotors obj)
        {
            ElectricMotorsBO electricmotorsBO = new ElectricMotorsBO(obj);
            return electricmotorsDao.Insert(electricmotorsBO);
        }
        public ElectricMotors Update(ElectricMotors obj)
        {
            ElectricMotorsBO electricmotorsBO = new ElectricMotorsBO(obj);
            electricmotorsDao.Update(electricmotorsBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return electricmotorsDao.Delete(_Id);
        }
        public ElectricMotors FindByKey(int _Id)
        {
            return new ElectricMotors(electricmotorsDao.FindByKey(_Id));
        }
        public IList<ElectricMotors> FindAll()
        {
            IList<ElectricMotors> list = new List<ElectricMotors>();
            IList<ElectricMotorsBO> listBO = new List<ElectricMotorsBO>();
            listBO = electricmotorsDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ElectricMotorsBO obj in listBO)
                    list.Add(new ElectricMotors(obj));
            return list;
        }
        public DataTable GetElectricMotorsByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataTable("SELECT B.* FROM  " + new ElectricMotorsBO().TableName + " as B WHERE B.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
