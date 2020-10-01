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
    public class ProductService
    {
        ProductDao productDao = new ProductDao();
        public int Insert(Product obj)
        {
            ProductBO infrastructureBO = new ProductBO(obj);
            return productDao.Insert(infrastructureBO);
        }
        public Product Update(Product obj)
        {
            ProductBO infrastructureBO = new ProductBO(obj);
            productDao.Update(infrastructureBO);
            return obj;
        }

        public long Delete(int _Id)
        {
            return productDao.Delete(_Id);
        }
        public Product FindByKey(int _Id)
        {
            return new Product(productDao.FindByKey(_Id));
        }

        public IList<Product> FindAll()
        {
            IList<Product> list = new List<Product>();
            IList<ProductBO> listBO = new List<ProductBO>();
            listBO = productDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (ProductBO obj in listBO)
                    list.Add(new Product(obj));
            return list;
        }

        public DataTable FindProductList(int fromYear, int toYear,int isProduct, string keyword, int enterpriseId, PagingInfo paging, bool bPaging)
        {
            return productDao.FindProductList(fromYear, toYear, isProduct, keyword, enterpriseId, paging, bPaging);
        }

        public IList<Product> GetListByEnterprise(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            try
            {
                return new Db().GetList<Product>("SELECT * FROM  " + new ProductBO().TableName + " WHERE EnterpriseId=@EnterpriseId order by ProductName", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
