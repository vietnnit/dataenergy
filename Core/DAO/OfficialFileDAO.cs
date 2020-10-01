using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class OfficialFileDAO : BaseDAO
    {
        public OfficialFileDAO()
        {
            //constructor
        }

        #region OfficialFileReader
        private OfficialFile OfficialFileReader(SqlDataReader reader)
        {
            OfficialFile officialFile = new OfficialFile();
            officialFile.OfficialFileID = (int)reader["OfficialFileID"];
            officialFile.OfficialID = (int)reader["OfficialID"];
            officialFile.FileName = (string)reader["FileName"];
            officialFile.Title = (string)reader["Title"];

            return officialFile;
        }
        #endregion

        #region CreateOfficialFile
        public void CreateOfficialFile(OfficialFile officialFile)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OfficialFileID", 0);
                command.Parameters.AddWithValue("@OfficialID", officialFile.OfficialID);
                command.Parameters.AddWithValue("@FileName", officialFile.FileName);
                command.Parameters.AddWithValue("@Title", officialFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm hình ảnh");
                else
                    command.Dispose();
            }

        }
        #endregion

        #region UpdateOfficialFile
        public void UpdateOfficialFile(OfficialFile officialFile)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OfficialFileID", officialFile.OfficialFileID);
                command.Parameters.AddWithValue("@OfficialID", officialFile.OfficialID);
                command.Parameters.AddWithValue("@FileName", officialFile.FileName);
                command.Parameters.AddWithValue("@Title", officialFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật hình ảnh");
                else
                    command.Dispose();
            }

        }
        #endregion

        #region DeleteOfficialFile
        public void DeleteOfficialFile(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficialFileID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không xóa được hình ảnh");
                else
                    command.Dispose();
            }
        }
         public void DeleteOfficialFile(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblOfficialFile where OfficialFileID in('" + sId + "')";
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

         #region GetOfficialFileByID
         public OfficialFile GetOfficialFileByID(int Id)
         {
             OfficialFile officialFile = null;
             using (SqlConnection connection = GetConnection())
             {
                 SqlCommand command = new SqlCommand("_OfficialFileGetByID", connection);
                 command.CommandType = CommandType.StoredProcedure;
                 command.Parameters.AddWithValue("@OfficialFileID", Id);
                 connection.Open();
                 using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     if (reader.Read())
                         officialFile = OfficialFileReader(reader);
                     else
                         throw new DataAccessException("Không tìm thấy tin");

                 }
                 command.Dispose();
             }
             return officialFile;
         }
         #endregion


        #region GetOfficialFileByOfficial
        public DataTable GetOfficialFileByOfficial(int pId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileGetByOfficial", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficialID", pId);
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

        #region GetOfficialFileAll
        public DataTable GetOfficialFileAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileGetAll", connection);
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
