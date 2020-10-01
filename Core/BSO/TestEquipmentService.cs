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
    public class TestEquipmentService
    {

        TestEquipmentDao testequipmentDao = new TestEquipmentDao();
        public int Insert(TestEquipment obj)
        {
            TestEquipmentBO testequipmentBO = new TestEquipmentBO(obj);
            return testequipmentDao.Insert(testequipmentBO);
        }
        public TestEquipment Update(TestEquipment obj)
        {
            TestEquipmentBO testequipmentBO = new TestEquipmentBO(obj);
            testequipmentDao.Update(testequipmentBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return testequipmentDao.Delete(_Id);
        }
        public TestEquipment FindByKey(int _Id)
        {
            return new TestEquipment(testequipmentDao.FindByKey(_Id));
        }
        public IList<TestEquipment> FindAll()
        {
            IList<TestEquipment> list = new List<TestEquipment>();
            IList<TestEquipmentBO> listBO = new List<TestEquipmentBO>();
            listBO = testequipmentDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (TestEquipmentBO obj in listBO)
                    list.Add(new TestEquipment(obj));
            return list;
        }
        public DataTable GetList(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataTable("SELECT * FROM  DE_TestEquipment WHERE AuditReportId=@ReportId ORDER BY Id DESC", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
