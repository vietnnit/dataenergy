using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class AdminDAO : BaseDAO
    {
        public AdminDAO()
        {
            //constructor
        }

        #region AdminReader
        private Admin AdminReader(SqlDataReader reader)
        {
            Admin admin = new Admin();
            admin.AdminID = (int)reader["Admin_ID"];
            admin.AdminName = (string)reader["Admin_Username"];
            admin.AdminFullName = (string)reader["Admin_FullName"];
            admin.AdminEmail = (string)reader["Admin_Email"];
            admin.AdminPass = (string)reader["Admin_Password"];
            admin.RolesID = (int)reader["Roles_ID"];
            admin.AdminActive = (bool)reader["Admin_Actived"];
            admin.AdminPermission = (string)reader["Admin_Permission"];
            admin.AdminCreated = (DateTime)reader["Admin_Created"];
            admin.AdminLog = (DateTime)reader["Admin_Log"];
            admin.AdminPhone = (string)reader["Admin_Phone"];
            admin.AdminAddress = (string)reader["Admin_Address"];
            admin.AdminBirth = (DateTime)reader["Admin_Birth"];
            admin.AdminSex = (bool)reader["Admin_Sex"];
            admin.AdminNickYahoo = (string)reader["Admin_NickYahoo"];
            admin.AdminNickSkype = (string)reader["Admin_NickSkype"];
            admin.AdminAvatar = (string)reader["Admin_Avatar"];
            admin.AdminLoginType = (bool)reader["Admin_LoginType"];
            if (reader["Admin_OrganizationId"] != DBNull.Value)
                admin.AdminOrganizationId = (int)reader["Admin_OrganizationId"];


            return admin;
        }
        #endregion

        #region GetAllAdmin
        public DataTable GetAllAdmin()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAdminById
        public Admin GetAdminById(string adminname)
        {
            Admin admin = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_Username", adminname);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        admin = AdminReader(reader);
                    else
                        throw new DataAccessException("khong ton tai admin");
                }
                command.Dispose();

            }
            return admin;
        }

        public Admin GetAdminById(int id)
        {
            Admin admin = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetBynId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_ID", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        admin = AdminReader(reader);
                    else
                        throw new DataAccessException("khong ton tai admin");
                }
                command.Dispose();

            }
            return admin;
        }
        #endregion

        #region CreateAdmin
        public int CreateAdmin(Admin admin)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Admin_ID", 1);
                command.Parameters.AddWithValue("@Admin_Username", admin.AdminName);
                command.Parameters.AddWithValue("@Admin_FullName", admin.AdminFullName);
                command.Parameters.AddWithValue("@Admin_Email", admin.AdminEmail);
                command.Parameters.AddWithValue("@Admin_Password", admin.AdminPass);
                command.Parameters.AddWithValue("@Roles_ID", admin.RolesID);
                command.Parameters.AddWithValue("@Admin_Actived", admin.AdminActive);
                command.Parameters.AddWithValue("@Admin_Permission", admin.AdminPermission);
                command.Parameters.AddWithValue("@Admin_Created", admin.AdminCreated);
                command.Parameters.AddWithValue("@Admin_Log", admin.AdminLog);
                command.Parameters.AddWithValue("@Admin_Phone", admin.AdminPhone);
                command.Parameters.AddWithValue("@Admin_Address", admin.AdminAddress);
                command.Parameters.AddWithValue("@Admin_Birth", admin.AdminBirth);
                command.Parameters.AddWithValue("@Admin_Sex", admin.AdminSex);
                command.Parameters.AddWithValue("@Admin_NickYahoo", admin.AdminNickYahoo);
                command.Parameters.AddWithValue("@Admin_NickSkype", admin.AdminNickSkype);
                command.Parameters.AddWithValue("@Admin_Avatar", admin.AdminAvatar);
                command.Parameters.AddWithValue("@Admin_LoginType", admin.AdminLoginType);
                command.Parameters.AddWithValue("@Admin_OrganizationId", admin.AdminOrganizationId);
                SqlParameter sp = new SqlParameter("@pReturnValue", SqlDbType.Int);
                sp.Direction = ParameterDirection.Output;
                command.Parameters.Add(sp);

                connection.Open();
                command.ExecuteNonQuery();

                int id = Convert.ToInt32(sp.Value.ToString());

                return id;
            }
        }
        #endregion

        #region UpdateAdmin
        public void UpdateAdmin(Admin admin)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Admin_ID", 1);
                command.Parameters.AddWithValue("@Admin_Username", admin.AdminName);
                command.Parameters.AddWithValue("@Admin_FullName", admin.AdminFullName);
                command.Parameters.AddWithValue("@Admin_Email", admin.AdminEmail);
                command.Parameters.AddWithValue("@Admin_Password", admin.AdminPass);
                command.Parameters.AddWithValue("@Roles_ID", admin.RolesID);
                command.Parameters.AddWithValue("@Admin_Actived", admin.AdminActive);
                command.Parameters.AddWithValue("@Admin_Permission", admin.AdminPermission);
                command.Parameters.AddWithValue("@Admin_Created", admin.AdminCreated);
                command.Parameters.AddWithValue("@Admin_Log", admin.AdminLog);
                command.Parameters.AddWithValue("@Admin_Phone", admin.AdminPhone);
                command.Parameters.AddWithValue("@Admin_Address", admin.AdminAddress);
                command.Parameters.AddWithValue("@Admin_Birth", admin.AdminBirth);
                command.Parameters.AddWithValue("@Admin_Sex", admin.AdminSex);
                command.Parameters.AddWithValue("@Admin_NickYahoo", admin.AdminNickYahoo);
                command.Parameters.AddWithValue("@Admin_NickSkype", admin.AdminNickSkype);
                command.Parameters.AddWithValue("@Admin_Avatar", admin.AdminAvatar);
                command.Parameters.AddWithValue("@Admin_LoginType", admin.AdminLoginType);
                command.Parameters.AddWithValue("@Admin_OrganizationId", admin.AdminOrganizationId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
            }
        }

        public int ChangePass(string newPass, string oldPass, int Admin_Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("UPDATE tblAdmin SET Admin_Password= @Admin_NewPass WHERE Admin_Password=@Admin_OldPass AND Admin_id=@Admin_ID", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Admin_NewPass", newPass);
                command.Parameters.AddWithValue("@Admin_OldPass", oldPass);
                command.Parameters.AddWithValue("@Admin_ID", Admin_Id);
                connection.Open();
                int ret = command.ExecuteNonQuery();
                if (ret <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
                return ret;
            }
        }
        #endregion

        #region DeleteAdmin
        public void DeleteAdmin(string adminname)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_Username", adminname);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa admin");
                else
                    command.Dispose();
            }
        }
        public void DeleteAdmin(int adminID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminDeleteID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_ID", adminID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa admin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetAllAdminRoles
        public DataTable GetAllAdminRoles()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblAdmin.*, tblRoles.* FROM tblAdmin INNER JOIN tblRoles ON tblAdmin.Roles_ID = tblRoles.Roles_ID ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
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

        #region UpdateAdminLog
        public void UpdateAdminLog(string name, DateTime log)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminUpdateLog", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_Username", name);
                command.Parameters.AddWithValue("@Admin_Log", log);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region AdminGetRolesByID
        public DataTable AdminGetRolesByID(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetRolesByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Roles_ID", rolesID);
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
        #region AdminGetAllRolesByID
        public DataTable AdminGetAllRolesByID(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblAdmin.*, tblRoles.* FROM tblAdmin INNER JOIN tblRoles ON tblAdmin.Roles_ID = tblRoles.Roles_ID WHERE tblAdmin.Roles_ID = @Roles_ID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Roles_ID", rolesID);
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


        #region GetAdminByCateHomeList
        public DataTable GetAdminByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblAdmin where Roles_ID in('" + strCate + "') order by Admin_UserName Asc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
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

        #region GetAdminByStrName
        public DataTable GetAdminByStrName(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblAdmin where Admin_UserName in('" + strCate + "') order by Admin_UserName Asc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
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

        #region GetAdminByAccountPass
        public Admin GetAdminByAccountPass(string adminname, string pass)
        {
            Admin admin = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetByAccountPass", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_Username", adminname);
                command.Parameters.AddWithValue("@Admin_Password", pass);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        admin = AdminReader(reader);
                    //else
                    //    throw new DataAccessException("khong ton tai admin");
                }
                command.Dispose();

            }
            return admin;
        }

        #endregion

        #region GetAdminByEmail
        public Admin GetAdminByEmail(string email)
        {
            Admin admin = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetByEmail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Admin_Email", email);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        admin = AdminReader(reader);
                    //else
                    //    throw new DataAccessException("khong ton tai admin");
                }
                command.Dispose();

            }
            return admin;
        }

        #endregion
    }
}
