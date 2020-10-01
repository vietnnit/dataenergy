using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class BrandBSO
    {
        public BrandBSO() 
        {
            //constructor
        }

        #region CreateBrand
        public void CreateBrand(Brand brand) 
        {
            BrandDAO brandDAO = new BrandDAO();
            brandDAO.CreateBrand(brand);
        }
        public int CreateBrandGet(Brand brand)
        {
            BrandDAO brandDAO = new BrandDAO();
            return brandDAO.CreateBrandGet(brand);
        }
        #endregion

        #region UpdateBrand
        public void UpdateBrand(Brand brand) 
        {
            BrandDAO brandDAO = new BrandDAO();
            brandDAO.UpdateBrand(brand);
        }
        #endregion

        #region DeleteBrand
        public void DeleteBrand(int Id) 
        {
            BrandDAO brandDAO = new BrandDAO();
            brandDAO.DeleteBrand(Id);
        }
        #endregion

        #region GetBrandById
        public Brand GetBrandById(int Id) 
        {
            BrandDAO brandDAO = new BrandDAO();
            return brandDAO.GetBrandById(Id);
        }
        #endregion

        #region GetBrandAll
        public DataTable GetBrandAll(string lang) 
        {
            BrandDAO brandDAO = new BrandDAO();
            return brandDAO.GetBrandAll(lang);
        }
        #endregion
    }
}
