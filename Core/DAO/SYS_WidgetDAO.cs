using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_WidgetDAO : BaseDAO
    {
        public SYS_WidgetDAO() 
        {
            //constructor
        }

        #region SYS_WidgetReader
        private SYS_Widget SYS_WidgetReader(SqlDataReader reader) 
        {
            SYS_Widget sys_Widget = new SYS_Widget();
            sys_Widget.Id = (int)reader["Id"];
            sys_Widget.WidgetControl = (string)reader["WidgetControl"];
            sys_Widget.WidgetDir = (string)reader["WidgetDir"];
            sys_Widget.WidgetInfo = (string)reader["WidgetInfo"];
            sys_Widget.WidgetName = (string)reader["WidgetName"];
            sys_Widget.WidgetType = (int)reader["WidgetType"];
            sys_Widget.WidgetStatus = (bool)reader["WidgetStatus"];


            return sys_Widget;
        }
        #endregion

        #region CreateSYS_Widget
        public int CreateSYS_WidgetGet(SYS_Widget sys_Widget)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@WidgetControl", sys_Widget.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_Widget.WidgetDir);
                command.Parameters.AddWithValue("@WidgetInfo", sys_Widget.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetName", sys_Widget.WidgetName);
                command.Parameters.AddWithValue("@WidgetStatus", sys_Widget.WidgetStatus);
                command.Parameters.AddWithValue("@WidgetType", sys_Widget.WidgetType);
               
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

        #region UpdateSYS_Widget
        public void UpdateSYS_Widget(SYS_Widget sys_Widget)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID",sys_Widget.Id);
                command.Parameters.AddWithValue("@WidgetControl", sys_Widget.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_Widget.WidgetDir);
                command.Parameters.AddWithValue("@WidgetInfo", sys_Widget.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetName", sys_Widget.WidgetName);
                command.Parameters.AddWithValue("@WidgetStatus", sys_Widget.WidgetStatus);
                command.Parameters.AddWithValue("@WidgetType", sys_Widget.WidgetType);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_Widget");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_Widget
        public void DeleteSYS_Widget(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_Widget");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_WidgetById
        public SYS_Widget GetSYS_WidgetById(int Id) 
        {
            SYS_Widget sys_Widget = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_Widget = SYS_WidgetReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri sys_Widget");
                    command.Dispose();
                }
            }
            return sys_Widget;
        }
        #endregion

        #region GetSYS_WidgetByType
        public DataTable GetSYS_WidgetByType(int _widgetType)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetGetByType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@WidgetType", _widgetType);
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

        #region GetSYS_WidgetAll
        public DataTable GetSYS_WidgetAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetGetAll",connection);
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

        public DataTable GetSYS_WidgetAllFull()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetGetAllFull", connection);
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
