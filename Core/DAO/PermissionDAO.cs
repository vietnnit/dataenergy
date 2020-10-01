using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class PermissionDAO : BaseDAO
    {
        public PermissionDAO()
        {
            //constructor
        }

        #region PermissionReader
        private Permission PermissionReader(SqlDataReader reader)
        {
            Permission permission = new Permission();
            permission.PermissionID = (int)reader["PermissionID"];
            permission.PermissionName = (string)reader["PermissionName"];
            permission.Description = (string)reader["Description"];
            permission.Value = (string)reader["Value"];
        

            return permission;
        }
        #endregion

        #region CreatePermission
        public void CreatePermission(Permission permission)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@PermissionID", 0);
                command.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                command.Parameters.AddWithValue("@Description", permission.Description);
                command.Parameters.AddWithValue("@Value", permission.Value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdatePermission
        public void UpdatePermission(Permission permission)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@PermissionID", permission.PermissionID);
                command.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                command.Parameters.AddWithValue("@Description", permission.Description);
                command.Parameters.AddWithValue("@Value", permission.Value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeletePermission
        public void DeletePermission(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PermissionID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetPermissionById
        public Permission GetPermissionById(int Id)
        {
            Permission permission = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PermissionID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        permission = PermissionReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return permission;
        }
        #endregion

        #region GetPermissionAll
        public DataTable GetPermissionAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionGetAll", connection);
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
