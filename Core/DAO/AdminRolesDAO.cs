using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class AdminRolesDAO:BaseDAO
    {
         public AdminRolesDAO() 
        {
            //constructor
        }

        #region AdminRolesReader
        private AdminRoles AdminRolesReader(SqlDataReader reader) 
        {
            AdminRoles adminRoles = new AdminRoles();
            adminRoles.AdminRolesID = (int) reader["AdminRolesID"];
            adminRoles.RolesID = (int) reader["RolesID"];
            adminRoles.AdminUserName = (string) reader["Admin_UserName"];
            adminRoles.Permission = (string)reader["Permission"];
            adminRoles.Created = (DateTime) reader["Created"];
            adminRoles.UserName = (string) reader["UserName"];

            return adminRoles;
        }
        #endregion

        #region CreateAdminRoles
        public void CreateAdminRoles(AdminRoles adminRoles) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@AdminRolesID",0);
                command.Parameters.AddWithValue("@RolesID",adminRoles.RolesID);
                command.Parameters.AddWithValue("@Admin_UserName", adminRoles.AdminUserName);
                command.Parameters.AddWithValue("@Permission", adminRoles.Permission);
                command.Parameters.AddWithValue("@Created", adminRoles.Created);
                command.Parameters.AddWithValue("@UserName", adminRoles.UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateAdminRoles
        public void UpdateAdminRoles(AdminRoles adminRoles) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AdminRolesID",adminRoles.AdminRolesID);
                command.Parameters.AddWithValue("@RolesID", adminRoles.RolesID);
                command.Parameters.AddWithValue("@Admin_UserName", adminRoles.AdminUserName);
                command.Parameters.AddWithValue("@Permission", adminRoles.Permission);
                command.Parameters.AddWithValue("@Created", adminRoles.Created);
                command.Parameters.AddWithValue("@UserName", adminRoles.UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteAdminRoles
        public void DeleteAdminRoles(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdminRolesID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteAdminRolesRoles
        public void DeleteAdminRolesRoles(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDeleteRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteAdminRolesUserName
        public void DeleteAdminRolesUserName(string username)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDeleteUserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_UserName", username);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetAdminRolesById
        public AdminRoles GetAdminRolesById(int Id) 
        {
            AdminRoles adminRoles = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdminRolesID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        adminRoles = AdminRolesReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return adminRoles;
        }
        #endregion

        #region GetAdminRolesByRoles
        public DataTable GetAdminRolesByRoles(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetByRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", rolesID);
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

        #region GetAdminRolesByUserName
        public DataTable GetAdminRolesByUserName(string username)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetByUserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_UserName", username);
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

        #region GetAdminRolesAll
        public DataTable GetAdminRolesAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetAll",connection);
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

        #region GetAdminRoles
        public AdminRoles GetAdminRoles(int rolesId, string username)
        {
            AdminRoles adminRoles = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", rolesId);
                command.Parameters.AddWithValue("@Admin_UserName", username);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        adminRoles = AdminRolesReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy giá trị");
                    command.Dispose();
                }
            }
            return adminRoles;
        }
        #endregion

        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, string username)
        {
            bool check = false;


            DataTable dataTable = GetAdminRolesAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "RolesID = " + rolesID + " AND Admin_UserName = '" + username + "'";
                if (dataView.Count > 0)
                    check = true;
            }
            return check;
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, string username)
        {
            string permission = "";

            if (CheckExitPermission(rolesID, username))
            {
                AdminRoles adminRoles = GetAdminRoles(rolesID, username);
                permission = adminRoles.Permission;
            }

            return permission;
        }
        #endregion

        #region CheckExitRolesUser
        public bool CheckExitRolesUser(int rolesID, string username)
        {
            bool check = false;


            DataTable dataTable = GetAdminRolesAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "RolesID = " + rolesID + " AND Admin_UserName = '" + username + "'";
                if (dataView.Count > 0)
                    check = true;
            }
            return check;
        }
        #endregion

        #region GetRoles
        public string GetRoles(string username)
        {
            DataTable table = GetAdminRolesByUserName(username);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["RolesID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion

        #region GetRoles
        public string GetRoles1(string username)
        {
            DataTable table = GetAdminRolesByUserName(username);
            string str = "";
           if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["RolesID"].ToString() + ",";

                }             

            }
            return str + "0";
        }
        #endregion


        #region GetAdminUserName
        public string GetAdminUserName(int rolesID)
        {
            DataTable table = GetAdminRolesByRoles(rolesID);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["Admin_UserName"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion

        #region GetAdminUserName1
        public string GetAdminUserName1(int rolesID)
        {
            DataTable table = GetAdminRolesByRoles(rolesID);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["Admin_UserName"].ToString() + ",";

                }

             //   restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion

        
    }
}
