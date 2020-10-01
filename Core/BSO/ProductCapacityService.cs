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
    public class ProductCapacityService
    {

        ProductCapacityDao productcapacityDao = new ProductCapacityDao();
        public int Insert(ProductCapacity obj)
        {
            ProductCapacityBO productcapacityBO = new ProductCapacityBO(obj);
            return productcapacityDao.Insert(productcapacityBO);
        }
        public ProductCapacity Update(ProductCapacity obj)
        {
            ProductCapacityBO productcapacityBO = new ProductCapacityBO(obj);
            productcapacityDao.Update(productcapacityBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return productcapacityDao.Delete(_Id);
        }
        public ProductCapacity FindByKey(int _Id)
        {
            return new ProductCapacity(productcapacityDao.FindByKey(_Id));
        }
        public IList<ProductCapacity> FindAll()
        {
            IList<ProductCapacity> list = new List<ProductCapacity>();
            IList<ProductCapacityBO> listBO = new List<ProductCapacityBO>();
            listBO = productcapacityDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProductCapacityBO obj in listBO)
                    list.Add(new ProductCapacity(obj));
            return list;
        }
        public DataTable GetDataCapacity(int ReportId, bool blIsPlan)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@ReportId", ReportId);
            parameter[1] = new DbParameter("@IsPlan", blIsPlan);
            try
            {
                return new Db().GetDataTable("SELECT C.*, P.ProductName, P.Measurement FROM  " + new ProductCapacityBO().TableName + " as C INNER JOIN " + new ProductBO().TableName + " as P ON P.Id=C.ProductId WHERE C.ReportId=@ReportId AND C.IsPlan=@IsPlan", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
