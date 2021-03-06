using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class NewsCateDAO : BaseDAO
    {
        public NewsCateDAO() 
        {
            //constructor
        }

        #region NewsCateReader
        private NewsCate NewsCateReader(SqlDataReader reader) 
        {
            NewsCate cateNews = new NewsCate();
            cateNews.Id = (int)reader["Id"];
            cateNews.CateNewsID = (int)reader["CateNewsID"];
            cateNews.NewsGroupID = (int)reader["NewsGroupID"];
            
            return cateNews;
        }
        #endregion

        #region CreateNewsCate
        public int CreateNewsCateGet(NewsCate cateNews)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@CateNewsID", cateNews.CateNewsID);
                command.Parameters.AddWithValue("@NewsGroupID", cateNews.NewsGroupID);
               
                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateNewsCate
        public void UpdateNewsCate(NewsCate cateNews)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Id",cateNews.Id);
                command.Parameters.AddWithValue("@CateNewsID", cateNews.CateNewsID);
                command.Parameters.AddWithValue("@NewsGroupID", cateNews.NewsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc cateNews");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsCate
        public void DeleteNewsCate(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc cateNews");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsCate(string sId, int cateNewsID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsCate where NewsGroupID in('" + sId + "') AND CateNewsID=@CateNewsID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsCatebyNewsID(int _newsID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsCate where NewsGroupID =@NewsGroupID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@NewsGroupID", _newsID);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsCatebyCateID(int _cateID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsCate where CateNewsID =@CateNewsID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@CateNewsID", _cateID);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetNewsCatePaging
        public DataTable GetNewsCatePaging(string lang, int cateNewsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                command.Parameters.AddWithValue("@CurrentPage", _paging.CurrentPage);
                command.Parameters.AddWithValue("@PageSize", _paging.PageSize);
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

        

        #region GetNewsCateByCateNewsID
        public DataTable GetNewsCateByCateNewsID(int cateNewsID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateGetByCateNewsID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }
        public DataTable GetNewsCateByNewsGroupID(int newsGroupID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateGetByNewsGroupID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;

          
           
        }
        public NewsCate GetNewsCateByID(int newsGroupID, int cateNewsID)
        {
            NewsCate _newsCate = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateGetByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsCate = NewsCateReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newsCate = null;

                }
                command.Dispose();
            }
            return _newsCate;


        }
      
        #endregion

        #region GetNewsCateAll
        public DataTable GetNewsCateAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCateGetAll",connection);
                command.CommandType = CommandType.StoredProcedure;
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
