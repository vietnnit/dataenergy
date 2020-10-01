using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class BrandDAO : BaseDAO
    {
        public BrandDAO() 
        {
            //constructor
        }

        #region BrandReader
        private Brand BrandReader(SqlDataReader reader) 
        {
            Brand brand = new Brand();
            brand.BrandID = (int)reader["BrandID"];
            brand.BrandName = (string) reader["BrandName"];
            brand.Image = (string)reader["Image"];
            brand.ShortDescribe = (string)reader["ShortDescribe"];
            brand.BrandUrl = (string)reader["BrandUrl"];
            brand.Language = (string)reader["Language"];
            return brand;
        }
        #endregion

        #region CreateBrand
        public void CreateBrand(Brand brand) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@BrandID",0);
                command.Parameters.AddWithValue("@BrandName",brand.BrandName);
                command.Parameters.AddWithValue("@BrandUrl",brand.BrandUrl);
                command.Parameters.AddWithValue("@Image",brand.Image);
                command.Parameters.AddWithValue("ShortDescribe",brand.ShortDescribe);
                command.Parameters.AddWithValue("@Language",brand.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong them moi duoc brand");
                else
                    command.Dispose();
            }
        }
        public int CreateBrandGet(Brand brand)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@BrandID", 0);
                command.Parameters.AddWithValue("@BrandName", brand.BrandName);
                command.Parameters.AddWithValue("@BrandUrl", brand.BrandUrl);
                command.Parameters.AddWithValue("@Image", brand.Image);
                command.Parameters.AddWithValue("ShortDescribe", brand.ShortDescribe);
                command.Parameters.AddWithValue("@Language", brand.Language);
                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc san pham");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateBrand
        public void UpdateBrand(Brand brand)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@BrandID",brand.BrandID);
                command.Parameters.AddWithValue("@BrandName", brand.BrandName);
                command.Parameters.AddWithValue("@BrandUrl", brand.BrandUrl);
                command.Parameters.AddWithValue("@Image", brand.Image);
                command.Parameters.AddWithValue("ShortDescribe", brand.ShortDescribe);
                command.Parameters.AddWithValue("@Language", brand.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc brand");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteBrand
        public void DeleteBrand(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BrandID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc brand");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetBrandById
        public Brand GetBrandById(int Id) 
        {
            Brand brand = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BrandID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        brand = BrandReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri brand");
                    command.Dispose();
                }
            }
            return brand;
        }
        #endregion

        #region GetBrandAll
        public DataTable GetBrandAll(string lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandGetAll",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language",lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion
    }
}
