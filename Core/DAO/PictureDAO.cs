using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class PictureDAO : BaseDAO
    {
        public PictureDAO() 
        {
            //constructor
        }

        #region PictureReader
        private Picture PictureReader(SqlDataReader reader) 
        {
            Picture picture = new Picture();
            picture.PictureID = (int) reader["PictureID"];
            picture.ProductID = (int) reader["ProductID"];
            picture.PictureThumb = (string) reader["PictureThumb"];
            picture.PictureLarge = (string)reader["PictureLarge"];
            picture.Orders = (int)reader["Orders"];

            return picture;
        }
        #endregion

        #region CreatePicture
        public void CreatePicture(Picture picture) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@PictureID",0);
                command.Parameters.AddWithValue("@ProductID",picture.ProductID);
                command.Parameters.AddWithValue("@PictureThumb",picture.PictureThumb);
                command.Parameters.AddWithValue("@PictureLarge",picture.PictureLarge);
                command.Parameters.AddWithValue("@Orders", picture.Orders);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm hình ảnh");
                else
                    command.Dispose();
            }
        
        }
        #endregion

        #region UpdatePicture
        public void UpdatePicture(Picture picture)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@PictureID", picture.PictureID);
                command.Parameters.AddWithValue("@ProductID", picture.ProductID);
                command.Parameters.AddWithValue("@PictureThumb", picture.PictureThumb);
                command.Parameters.AddWithValue("@PictureLarge", picture.PictureLarge);
                command.Parameters.AddWithValue("@Orders", picture.Orders);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật hình ảnh");
                else
                    command.Dispose();
            }

        }
        #endregion

        #region DeletePicture
        public void DeletePicture(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PictureID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không xóa được hình ảnh");
                else
                    command.Dispose();
            }
        }

        public void DeletePicture(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblPicture where PictureID in('" + sId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }


        #endregion

        #region GetPictureByProduct
        public DataTable GetPictureByProduct(int pId) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureGetByProduct",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID",pId);
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

        #region GetPictureByAll
        public DataTable GetPictureByAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureGetByAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion


        #region GetPictureById
        public Picture GetPictureById(int Id)
        {
            Picture picture = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PictureID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        picture = PictureReader(reader);
                    else
                        //throw new DataAccessException("Khong tim thay san pham");
                        picture = null;
                    command.Dispose();
                }
            }
            return picture;
        }
        #endregion

        #region PictureUpOrder
        public void PictureUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PictureID", cId);
                command.Parameters.AddWithValue("@Orders", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion
    }
}
