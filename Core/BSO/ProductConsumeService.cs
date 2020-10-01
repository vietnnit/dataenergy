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
    public class ProductConsumeService
    {

        ProductConsumeDao productconsumeDao = new ProductConsumeDao();
        public int Insert(ProductConsume obj)
        {
            ProductConsumeBO productconsumeBO = new ProductConsumeBO(obj);
            return productconsumeDao.Insert(productconsumeBO);
        }
        public ProductConsume Update(ProductConsume obj)
        {
            ProductConsumeBO productconsumeBO = new ProductConsumeBO(obj);
            productconsumeDao.Update(productconsumeBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return productconsumeDao.Delete(_Id);
        }
        public ProductConsume FindByKey(int _Id)
        {
            return new ProductConsume(productconsumeDao.FindByKey(_Id));
        }
        public IList<ProductConsume> FindAll()
        {
            IList<ProductConsume> list = new List<ProductConsume>();
            IList<ProductConsumeBO> listBO = new List<ProductConsumeBO>();
            listBO = productconsumeDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProductConsumeBO obj in listBO)
                    list.Add(new ProductConsume(obj));
            return list;
        }
        public DataTable GetProductConsume(int ReportId, bool blIsProduct)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsProduct", blIsProduct);
            try
            {
                return new Db().GetDataTable("SELECT C.*, P.ProductName, P.Measurement FROM  " + new ProductConsumeBO().TableName + " as C INNER JOIN " + new ProductBO().TableName + " as P ON P.Id=C.ProductId WHERE C.AuditReportId=@ReportId AND P.IsProduct=@IsProduct", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
       
    }
}
