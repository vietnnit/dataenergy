using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsGroupFileDAO : BaseDAO
    {
        public NewsGroupFileDAO()
        {
            //constructor
        }

        #region NewsGroupFileReader
        private NewsGroupFile NewsGroupFileReader(SqlDataReader reader)
        {
            NewsGroupFile _newsGroupFile = new NewsGroupFile();
            _newsGroupFile.NewsGroupFileID = (int)reader["NewsGroupFileID"];
            _newsGroupFile.NewsGroupID = (int)reader["NewsGroupID"];
            _newsGroupFile.FileName = (string)reader["FileName"];
            _newsGroupFile.Title = (string)reader["Title"];

            return _newsGroupFile;
        }
        #endregion

        #region CreateNewsGroupFile
        public void CreateNewsGroupFile(NewsGroupFile _newsGroupFile)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsGroupFileID", 0);
                command.Parameters.AddWithValue("@NewsGroupID", _newsGroupFile.NewsGroupID);
                command.Parameters.AddWithValue("@FileName", _newsGroupFile.FileName);
                command.Parameters.AddWithValue("@Title", _newsGroupFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm hình ảnh");
                else
                    command.Dispose();
            }

        }
        #endregion

        #region UpdateNewsGroupFile
        public void UpdateNewsGroupFile(NewsGroupFile _newsGroupFile)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsGroupFileID", _newsGroupFile.NewsGroupFileID);
                command.Parameters.AddWithValue("@NewsGroupID", _newsGroupFile.NewsGroupID);
                command.Parameters.AddWithValue("@FileName", _newsGroupFile.FileName);
                command.Parameters.AddWithValue("@Title", _newsGroupFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật hình ảnh");
                else
                    command.Dispose();
            }

        }
        #endregion

        #region DeleteNewsGroupFile
        public void DeleteNewsGroupFile(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupFileID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không xóa được hình ảnh");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsGroupFile(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsGroupFile where NewsGroupFileID in('" + sId + "')";
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

        #region GetNewsGroupFileByID
        public NewsGroupFile GetNewsGroupFileByID(int Id)
        {
            NewsGroupFile _newsGroupFile = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileGetByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupFileID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsGroupFile = NewsGroupFileReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy tin");

                }
                command.Dispose();
            }
            return _newsGroupFile;
        }
        #endregion


        #region GetNewsGroupFileByNewsGroup
        public DataTable GetNewsGroupFileByNewsGroup(int pId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileGetByNewsGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", pId);
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

        #region GetNewsGroupFileAll
        public DataTable GetNewsGroupFileAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupFileGetAll", connection);
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
    }
}
