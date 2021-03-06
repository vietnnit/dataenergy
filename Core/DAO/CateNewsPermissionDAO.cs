using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class CateNewsPermissionDAO:BaseDAO
    {
         public CateNewsPermissionDAO() 
        {
            //constructor
        }

        #region CateNewsPermissionReader
        private CateNewsPermission CateNewsPermissionReader(SqlDataReader reader) 
        {
            CateNewsPermission cateNewsPermission = new CateNewsPermission();
            cateNewsPermission.CateNewsPermissionID = (int) reader["CateNewsPermissionID"];
            cateNewsPermission.RolesID = (int) reader["RolesID"];
            cateNewsPermission.CateNewsID = (int) reader["CateNewsID"];
            cateNewsPermission.Permission = (string)reader["Permission"];
            cateNewsPermission.Created = (DateTime) reader["Created"];
            cateNewsPermission.UserName = (string) reader["UserName"];
            cateNewsPermission.Language = (string)reader["Language"];

            return cateNewsPermission;
        }
        #endregion

        #region CreateCateNewsPermission
        public void CreateCateNewsPermission(CateNewsPermission cateNewsPermission) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@CateNewsPermissionID",0);
                command.Parameters.AddWithValue("@RolesID",cateNewsPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsPermission.CateNewsID);
                command.Parameters.AddWithValue("@Permission", cateNewsPermission.Permission);
                command.Parameters.AddWithValue("@Created", cateNewsPermission.Created);
                command.Parameters.AddWithValue("@UserName", cateNewsPermission.UserName);
                command.Parameters.AddWithValue("@Language", cateNewsPermission.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateCateNewsPermission
        public void UpdateCateNewsPermission(CateNewsPermission cateNewsPermission) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsPermissionID",cateNewsPermission.CateNewsPermissionID);
                command.Parameters.AddWithValue("@RolesID", cateNewsPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsPermission.CateNewsID);
                command.Parameters.AddWithValue("@Permission", cateNewsPermission.Permission);
                command.Parameters.AddWithValue("@Created", cateNewsPermission.Created);
                command.Parameters.AddWithValue("@UserName", cateNewsPermission.UserName);
                command.Parameters.AddWithValue("@Language", cateNewsPermission.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsPermission
        public void DeleteCateNewsPermission(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsPermissionID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsPermissionRoles
        public void DeleteCateNewsPermissionRoles(int Id, string lang)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDeleteRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsPermissionCateID
        public void DeleteCateNewsPermissionCateID(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDeleteCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetCateNewsPermissionById
        public CateNewsPermission GetCateNewsPermissionById(int Id) 
        {
            CateNewsPermission cateNewsPermission = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsPermissionID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        cateNewsPermission = CateNewsPermissionReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return cateNewsPermission;
        }
        #endregion

        #region GetCateNewsPermissionByRoles
        public DataTable GetCateNewsPermissionByRoles(int rolesID, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetByRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", rolesID);
                command.Parameters.AddWithValue("@Language", lang);
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

        #region GetCateNewsPermissionByCateID
        public DataTable GetCateNewsPermissionByCateID(int cateID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetByCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cateID);
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

        #region GetCateNewsPermissionAll
        public DataTable GetCateNewsPermissionAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetAll",connection);
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

        #region GetCateNewsPermission
        public CateNewsPermission GetCateNewsPermission(int rolesId, int cateNewsID)
        {
            CateNewsPermission cateNewsPermission = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", rolesId);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        cateNewsPermission = CateNewsPermissionReader(reader);
                    //else
                    //    throw new DataAccessException("Không tìm thấy giá trị");
                    command.Dispose();
                }
            }
            return cateNewsPermission;
        }
        #endregion


        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, int cateNewsID)
        {
            bool check = false;

             CateNewsPermission catenewsPermission = GetCateNewsPermission(rolesID, cateNewsID);
            if (catenewsPermission != null)
                check = true;
            //DataTable dataTable = GetCateNewsPermissionAll();
            //if (dataTable != null)
            //{
            //    DataView dataView = new DataView(dataTable);
            //    dataView.RowFilter = "RolesID = " + rolesID + " AND CateNewsID = " + cateNewsID;
            //    if (dataView.Count > 0)
            //        check = true;
            //}
            return check;
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, int cateNewsID)
        {
            string permission = "";

            //if (CheckExitPermission(rolesID, cateNewsID))
            //{
            //    CateNewsPermission catenewsPermission = GetCateNewsPermission(rolesID, cateNewsID);
            //    permission = catenewsPermission.Permission;
            //}
            CateNewsPermission catenewsPermission = GetCateNewsPermission(rolesID, cateNewsID);
            if (catenewsPermission != null)
                permission = catenewsPermission.Permission;
            return permission;
        }
        #endregion

        #region GetRoles
        public string GetRoles(int cateID)
        {
            DataTable table = GetCateNewsPermissionByCateID(cateID);
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

        #region GetCateNewsID
        public string GetCateNewsID(int rolesID, string lang)
        {
            DataTable table = GetCateNewsPermissionByRoles(rolesID, lang);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["CateNewsID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }

        public string GetCateNewsID(string strRoles, string lang)
        {

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select * from tblCateNewsPermission where RolesID IN('" + strRoles + "') AND [Language]=@Language";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Language", lang);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["CateNewsID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion
        
    }
}
