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
    public class CompressorService
    {

        CompressorDao compressorDao = new CompressorDao();
        public int Insert(Compressor obj)
        {
            CompressorBO compressorBO = new CompressorBO(obj);
            return compressorDao.Insert(compressorBO);
        }
        public Compressor Update(Compressor obj)
        {
            CompressorBO compressorBO = new CompressorBO(obj);
            compressorDao.Update(compressorBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return compressorDao.Delete(_Id);
        }
        public Compressor FindByKey(int _Id)
        {
            return new Compressor(compressorDao.FindByKey(_Id));
        }
        public IList<Compressor> FindAll()
        {
            IList<Compressor> list = new List<Compressor>();
            IList<CompressorBO> listBO = new List<CompressorBO>();
            listBO = compressorDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (CompressorBO obj in listBO)
                    list.Add(new Compressor(obj));
            return list;
        }
        public DataTable GetCompressorByReport(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            try
            {
                return new Db().GetDataTable("SELECT B.* FROM  " + new CompressorBO().TableName + " as B WHERE B.AuditReportId=@ReportId", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
