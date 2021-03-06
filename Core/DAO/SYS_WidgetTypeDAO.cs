using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_WidgetTypeDAO : BaseDAO
    {
        public SYS_WidgetTypeDAO() 
        {
            //constructor
        }

        #region SYS_WidgetTypeReader
        private SYS_WidgetType SYS_WidgetTypeReader(SqlDataReader reader) 
        {
            SYS_WidgetType sys_WidgetType = new SYS_WidgetType();
            sys_WidgetType.Id = (int)reader["Id"];
            sys_WidgetType.WidgetControl = (string)reader["WidgetControl"];
            sys_WidgetType.WidgetDir = (string)reader["WidgetDir"];
            sys_WidgetType.WidgetInfo = (string)reader["WidgetInfo"];
            sys_WidgetType.WidgetTypeName = (string)reader["WidgetTypeName"];
            sys_WidgetType.WidgetStatus = (bool)reader["WidgetStatus"];
            sys_WidgetType.Orders = (int)reader["Orders"];

            return sys_WidgetType;
        }
        #endregion

        #region CreateSYS_WidgetType
        public int CreateSYS_WidgetTypeGet(SYS_WidgetType sys_WidgetType)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@WidgetControl", sys_WidgetType.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_WidgetType.WidgetDir);
                command.Parameters.AddWithValue("@WidgetInfo", sys_WidgetType.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetTypeName", sys_WidgetType.WidgetTypeName);
                command.Parameters.AddWithValue("@WidgetStatus", sys_WidgetType.WidgetStatus);
                command.Parameters.AddWithValue("@Orders", sys_WidgetType.Orders);
               
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

        #region UpdateSYS_WidgetType
        public void UpdateSYS_WidgetType(SYS_WidgetType sys_WidgetType)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID",sys_WidgetType.Id);
                command.Parameters.AddWithValue("@WidgetControl", sys_WidgetType.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_WidgetType.WidgetDir);
                command.Parameters.AddWithValue("@WidgetInfo", sys_WidgetType.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetTypeName", sys_WidgetType.WidgetTypeName);
                command.Parameters.AddWithValue("@WidgetStatus", sys_WidgetType.WidgetStatus);
                command.Parameters.AddWithValue("@Orders", sys_WidgetType.Orders);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_WidgetType");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_WidgetType
        public void DeleteSYS_WidgetType(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_WidgetType");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_WidgetTypeById
        public SYS_WidgetType GetSYS_WidgetTypeById(int Id) 
        {
            SYS_WidgetType sys_WidgetType = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_WidgetType = SYS_WidgetTypeReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri sys_WidgetType");
                    command.Dispose();
                }
            }
            return sys_WidgetType;
        }
        #endregion

        #region GetSYS_WidgetTypeAll
        public DataTable GetSYS_WidgetTypeAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeGetAll",connection);
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

        #region SYS_WidgetTypeUpOrder
        public void SYS_WidgetTypeUpOrder(int Id, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetTypeUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Order", cOrder);
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
