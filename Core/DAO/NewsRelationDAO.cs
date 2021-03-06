using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class NewsRelationDAO : BaseDAO
    {
        public NewsRelationDAO() 
        {
            //constructor
        }

        #region NewsRelationReader
        private NewsRelation NewsRelationReader(SqlDataReader reader) 
        {
            NewsRelation newsRelation = new NewsRelation();
            newsRelation.Id = (int)reader["Id"];
            newsRelation.NewsID = (int)reader["NewsID"];
            newsRelation.NewsGroupID = (int)reader["NewsGroupID"];
            
            return newsRelation;
        }
        #endregion

        #region CreateNewsRelation
        public int CreateNewsRelationGet(NewsRelation newsRelation)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@NewsID", newsRelation.NewsID);
                command.Parameters.AddWithValue("@NewsGroupID", newsRelation.NewsGroupID);
               
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

        #region UpdateNewsRelation
        public void UpdateNewsRelation(NewsRelation newsRelation)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Id",newsRelation.Id);
                command.Parameters.AddWithValue("@NewsID", newsRelation.NewsID);
                command.Parameters.AddWithValue("@NewsGroupID", newsRelation.NewsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc newsRelation");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsRelation
        public void DeleteNewsRelation(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc newsRelation");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsRelation(string sId, int newsID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsRelation where NewsGroupID in('" + sId + "') AND NewsID=@NewsID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@NewsID", newsID);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetNewsRelationPaging
        public DataTable GetNewsRelationPaging(string lang, int newsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@NewsID", newsID);
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

        

        #region GetNewsRelationByNewsID
        public DataTable GetNewsRelationByNewsID(int newsID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationGetByNewsID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", newsID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }
        public NewsRelation GetNewsRelationByNewsGroupID(int newsGroupID)
        {
            NewsRelation _newRelation = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationGetByNewsGroupID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newRelation = NewsRelationReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newRelation = null;

                }
                command.Dispose();
            }
            return _newRelation;

           
        }
        public NewsRelation GetNewsRelationByID(int newsGroupID, int newsID)
        {
            NewsRelation _newRelation = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationGetByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                command.Parameters.AddWithValue("@NewsID", newsID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newRelation = NewsRelationReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newRelation = null;

                }
                command.Dispose();
            }
            return _newRelation;


        }
      
        #endregion

        #region GetNewsRelationAll
        public DataTable GetNewsRelationAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRelationGetAll",connection);
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
