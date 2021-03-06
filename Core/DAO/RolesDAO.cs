using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class RolesDAO : BaseDAO
    {
        public RolesDAO()
        {
            //constructor
        }

        #region RolesReader
        private IRoles RolesReader(SqlDataReader reader)
        {
            IRoles roles = new IRoles();
            roles.RolesID = (int)reader["Roles_ID"];
            roles.RolesName = (string)reader["Roles_Name"];
            roles.RolesModules = (string)reader["Roles_Modules"];
            //roles.RolesCode = (string) reader["Roles_Code"];
            return roles;
        }
        #endregion

        #region GetAllRoles
        public DataTable GetAllRoles()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetAll", connection);
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

        #region GetRolesById
        public IRoles GetRolesById(int rId)
        {
            IRoles roles = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetById", connection);
                command.Parameters.AddWithValue("@Roles_ID", rId);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        roles = RolesReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay");
                }
                command.Dispose();

            }
            return roles;
        }
        #endregion

        #region GetRolesByName
        public IRoles GetRolesByName(string name)
        {
            IRoles roles = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetByName", connection);
                command.Parameters.AddWithValue("@Roles_Name", name);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        roles = RolesReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay");
                }
                command.Dispose();

            }
            return roles;
        }
        #endregion

        #region CreateRoles
        public int CreateRoles(IRoles roles)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Roles_ID", 1);
                command.Parameters.AddWithValue("@Roles_Name", roles.RolesName);
                command.Parameters.AddWithValue("@Roles_Modules", roles.RolesModules);
                //command.Parameters.AddWithValue("@Roles_Code", roles.RolesCode);

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

        #region UpdateRoles
        public int UpdateRoles(IRoles roles) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Roles_ID", roles.RolesID);
                command.Parameters.AddWithValue("@Roles_Name", roles.RolesName);
                command.Parameters.AddWithValue("@Roles_Modules", roles.RolesModules);
                //command.Parameters.AddWithValue("@Roles_Code", roles.RolesCode);        
                connection.Open();
                int ret = command.ExecuteNonQuery();
                if (ret<=0)
                    throw new DataAccessException("Lỗi không cập nhật Roles");
                else
                    command.Dispose();
                return ret;
            }
            return 0;
        }
        #endregion

        #region DeleteRoles
        public void DeleteRoles(int rId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Roles_ID", rId);
                connection.Open();
                if (command.ExecuteNonQuery() < 0)
                    throw new DataAccessException("Lỗi , không thể xóa");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetRolesbyStrRolesID
        public DataTable GetRolesbyStrRolesID(string strRolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblRoles WHERE [Roles_ID] in('" + strRolesID + "') ORDER BY Roles_ID ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

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


    }
}
