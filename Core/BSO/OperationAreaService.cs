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
    public class OperationAreaService
    {

        OperationAreaDao operationareaDao = new OperationAreaDao();
        public int Insert(OperationArea obj)
        {
            OperationAreaBO operationareaBO = new OperationAreaBO(obj);
            return operationareaDao.Insert(operationareaBO);
        }
        public OperationArea Update(OperationArea obj)
        {
            OperationAreaBO operationareaBO = new OperationAreaBO(obj);
            operationareaDao.Update(operationareaBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return operationareaDao.Delete(_Id);
        }
        public OperationArea FindByKey(int _Id)
        {
            return new OperationArea(operationareaDao.FindByKey(_Id));
        }
        public IList<OperationArea> FindAll()
        {
            IList<OperationArea> list = new List<OperationArea>();
            IList<OperationAreaBO> listBO = new List<OperationAreaBO>();
            listBO = operationareaDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (OperationAreaBO obj in listBO)
                    list.Add(new OperationArea(obj));
            return list;
        }
        public DataTable GetOperationByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            return new Db().GetDataTable("SELECT * FROM " + new OperationAreaBO().TableName + " WHERE AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
        }
    }
}
