using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class NewsEventRelationDAO : BaseDAO
    {
        public NewsEventRelationDAO() 
        {
            //constructor
        }

        #region NewsEventRelationReader
        private NewsEventRelation NewsEventRelationReader(SqlDataReader reader) 
        {
            NewsEventRelation newsRelation = new NewsEventRelation();
            newsRelation.Id = (int)reader["Id"];
            newsRelation.NewsEventID = (int)reader["NewsEventID"];
            newsRelation.NewsGroupID = (int)reader["NewsGroupID"];
            
            return newsRelation;
        }
        #endregion

        #region CreateNewsEventRelation
        public int CreateNewsEventRelationGet(NewsEventRelation newsRelation)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@NewsEventID", newsRelation.NewsEventID);
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

        #region UpdateNewsEventRelation
        public void UpdateNewsEventRelation(NewsEventRelation newsRelation)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Id",newsRelation.Id);
                command.Parameters.AddWithValue("@NewsEventID", newsRelation.NewsEventID);
                command.Parameters.AddWithValue("@NewsGroupID", newsRelation.NewsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc newsRelation");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsEventRelation
        public void DeleteNewsEventRelation(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc newsRelation");
                else
                    command.Dispose();
            }
        }
        public void DeleteNewsEventRelation(string sId, int newsEventID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblTS_TruongNewsEventRelation where NewsGroupID in('" + sId + "') AND NewsEventID=@NewsEventID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@NewsEventID", newsEventID);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetNewsEventRelationPaging
        public DataTable GetNewsEventRelationPaging(string lang, int newsEventID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@NewsEventID", newsEventID);
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
        #region GetNewsEventRelationSearchPaging
        public DataTable GetNewsEventRelationSearchPaging(string finter, string lang, int newsEventID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetSearchPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@NewsEventID", newsEventID);
                command.Parameters.AddWithValue("@Finter", finter);
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

        

        #region GetNewsEventRelationByNewsEventID
        public DataTable GetNewsEventRelationByNewsEventID(int newsEventID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetByNewsEventID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsEventID", newsEventID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }
        public NewsEventRelation GetNewsEventRelationByNewsGroupID(int newsGroupID)
        {
            NewsEventRelation _newRelation = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetByNewsGroupID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newRelation = NewsEventRelationReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newRelation = null;

                }
                command.Dispose();
            }
            return _newRelation;

           
        }
        public NewsEventRelation GetNewsEventRelationByID(int newsGroupID, int newsEventID)
        {
            NewsEventRelation _newRelation = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                command.Parameters.AddWithValue("@NewsEventID", newsEventID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newRelation = NewsEventRelationReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newRelation = null;

                }
                command.Dispose();
            }
            return _newRelation;


        }
      
        #endregion

        #region GetNewsEventRelationAll
        public DataTable GetNewsEventRelationAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventRelationGetAll",connection);
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
