using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsTagsDAO:BaseDAO
    {
        public NewsTagsDAO() 
        {
            //constructor
        }

        #region NewsTagsReader
        private NewsTags NewsTagsReader(SqlDataReader reader) 
        {
            NewsTags _newsTags = new NewsTags();
            _newsTags.NewsTagsID = (int) reader["NewsTagsID"];
            _newsTags.TagsID = (int) reader["TagsID"];
            _newsTags.NewsGroupID = (int) reader["NewsGroupID"];

            return _newsTags;
        }
        #endregion

        #region CreateNewsTags
        public void CreateNewsTags(NewsTags _newsTags) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@NewsTagsID",0);
                command.Parameters.AddWithValue("@TagsID",_newsTags.TagsID);
                command.Parameters.AddWithValue("@NewsGroupID", _newsTags.NewsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc ");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsTags
        public void UpdateNewsTags(NewsTags _newsTags) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsTagsID",_newsTags.NewsTagsID);
                command.Parameters.AddWithValue("@TagsID", _newsTags.TagsID);
                command.Parameters.AddWithValue("@NewsGroupID", _newsTags.NewsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsTags
        public void DeleteNewsTags(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsTagsID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsTagsTagsID
        public void DeleteNewsTagsTagsID(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsDeleteTagsID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TagsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsTagsNewsID
        public void DeleteNewsTagsNewsID(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsDeleteNewsID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetNewsTagsById
        public NewsTags GetNewsTagsById(int Id) 
        {
            NewsTags _newsTags = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsTagsID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsTags = NewsTagsReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return _newsTags;
        }
        #endregion

        #region GetNewsTagsByTags
        public DataTable GetNewsTagsByTags(int _tagsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsGetByTags", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TagsID", _tagsID);
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

        #region GetNewsTagsByNews
        public DataTable GetNewsTagsByNews(int _newsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsGetByNews", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", _newsID);
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

        #region GetNewsTagsAll
        public DataTable GetNewsTagsAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsGetAll",connection);
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

        #region GetNewsTags
        public NewsTags GetNewsTags(int _tagsID, int _newsGroupID)
        {
            NewsTags _newsTags = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsTagsGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TagsID", _tagsID);
                command.Parameters.AddWithValue("@NewsGroupID", _newsGroupID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsTags = NewsTagsReader(reader);
                    else
                        _newsTags = null;
                      //  throw new DataAccessException("Không tìm thấy giá trị");
                    command.Dispose();
                }
            }
            return _newsTags;
        }
        #endregion


        #region CheckExitTags
        public bool CheckExitTags(int _tagsID, int _newsGroupID)
        {
            bool check = false;

            NewsTags _newstags = new NewsTags();

            _newstags = GetNewsTags(_tagsID, _newsGroupID);

           if (_newstags != null)
            {
               check = true;
            }
            return check;
        }
        #endregion

        
        #region GetTags
        public string GetTags(int _newsGroupID)
        {
            DataTable table = GetNewsTagsByNews(_newsGroupID);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["TagsID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion

        #region GetNews
        public string GetNews(int _tagsID)
        {
            DataTable table = GetNewsTagsByTags(_tagsID);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["NewsGroupID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }

        
        #endregion
    }
}
