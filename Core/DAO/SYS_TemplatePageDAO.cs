using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_TemplatePageDAO : BaseDAO
    {
        public SYS_TemplatePageDAO() 
        {
            //constructor
        }

        #region SYS_TemplatePageReader
        private SYS_TemplatePage SYS_TemplatePageReader(SqlDataReader reader) 
        {
            SYS_TemplatePage sys_TemplatePage = new SYS_TemplatePage();
            sys_TemplatePage.Id  = (int)reader["Id"];
            sys_TemplatePage.Info = (string)reader["Info"];
            sys_TemplatePage.TemplateControl = (string)reader["TemplateControl"];
            sys_TemplatePage.MasterControl = (string)reader["MasterControl"];
            sys_TemplatePage.TemplateName = (string)reader["TemplateName"];
            sys_TemplatePage.Language = (string)reader["Language"];
            return sys_TemplatePage;
        }
        #endregion

        #region CreateSYS_TemplatePage
        public int CreateSYS_TemplatePageGet(SYS_TemplatePage sys_TemplatePage)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_TemplatePageInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@TemplateName", sys_TemplatePage.TemplateName);
                command.Parameters.AddWithValue("@TemplateControl", sys_TemplatePage.TemplateControl);
                command.Parameters.AddWithValue("@MasterControl", sys_TemplatePage.MasterControl);
                command.Parameters.AddWithValue("@Info", sys_TemplatePage.Info);
                command.Parameters.AddWithValue("@Language", sys_TemplatePage.Language);
               
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

        #region UpdateSYS_TemplatePage
        public void UpdateSYS_TemplatePage(SYS_TemplatePage sys_TemplatePage)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_TemplatePageUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Id",sys_TemplatePage.Id);
                command.Parameters.AddWithValue("@TemplateName", sys_TemplatePage.TemplateName);
                command.Parameters.AddWithValue("@TemplateControl", sys_TemplatePage.TemplateControl);
                command.Parameters.AddWithValue("@MasterControl", sys_TemplatePage.MasterControl);
                command.Parameters.AddWithValue("@Info", sys_TemplatePage.Info);
                command.Parameters.AddWithValue("@Language", sys_TemplatePage.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_TemplatePage");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_TemplatePage
        public void DeleteSYS_TemplatePage(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_TemplatePageDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_TemplatePage");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_TemplatePageById
        public SYS_TemplatePage GetSYS_TemplatePageById(int Id) 
        {
            SYS_TemplatePage sys_TemplatePage = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_TemplatePageGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_TemplatePage = SYS_TemplatePageReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri sys_TemplatePage");
                    command.Dispose();
                }
            }
            return sys_TemplatePage;
        }
        #endregion

        #region GetSYS_TemplatePageAll
        public DataTable GetSYS_TemplatePageAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_TemplatePageGetAll",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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
