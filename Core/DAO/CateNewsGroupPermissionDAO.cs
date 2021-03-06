using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class CateNewsGroupPermissionDAO:BaseDAO
    {
         public CateNewsGroupPermissionDAO() 
        {
            //constructor
        }

        #region CateNewsGroupPermissionReader
        private CateNewsGroupPermission CateNewsGroupPermissionReader(SqlDataReader reader) 
        {
            CateNewsGroupPermission _cateNewsGroupPermission = new CateNewsGroupPermission();
            _cateNewsGroupPermission.CateNewsGroupPermissionID = (int) reader["CateNewsGroupPermissionID"];
            _cateNewsGroupPermission.RolesID = (int) reader["RolesID"];
            _cateNewsGroupPermission.CateNewsGroupID = (int) reader["CateNewsGroupID"];
            _cateNewsGroupPermission.Permission = (string)reader["Permission"];
            _cateNewsGroupPermission.Created = (DateTime) reader["Created"];
            _cateNewsGroupPermission.UserName = (string) reader["UserName"];
            _cateNewsGroupPermission.Language = (string)reader["Language"];
            return _cateNewsGroupPermission;
        }
        #endregion

        #region CreateCateNewsGroupPermission
        public void CreateCateNewsGroupPermission(CateNewsGroupPermission _cateNewsGroupPermission) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@CateNewsGroupPermissionID",0);
                command.Parameters.AddWithValue("@RolesID",_cateNewsGroupPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsGroupID", _cateNewsGroupPermission.CateNewsGroupID);
                command.Parameters.AddWithValue("@Permission", _cateNewsGroupPermission.Permission);
                command.Parameters.AddWithValue("@Created", _cateNewsGroupPermission.Created);
                command.Parameters.AddWithValue("@UserName", _cateNewsGroupPermission.UserName);
                command.Parameters.AddWithValue("@Language", _cateNewsGroupPermission.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateCateNewsGroupPermission
        public void UpdateCateNewsGroupPermission(CateNewsGroupPermission _cateNewsGroupPermission) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsGroupPermissionID",_cateNewsGroupPermission.CateNewsGroupPermissionID);
                command.Parameters.AddWithValue("@RolesID", _cateNewsGroupPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsGroupID", _cateNewsGroupPermission.CateNewsGroupID);
                command.Parameters.AddWithValue("@Permission", _cateNewsGroupPermission.Permission);
                command.Parameters.AddWithValue("@Created", _cateNewsGroupPermission.Created);
                command.Parameters.AddWithValue("@UserName", _cateNewsGroupPermission.UserName);
                command.Parameters.AddWithValue("@Language", _cateNewsGroupPermission.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsGroupPermission
        public void DeleteCateNewsGroupPermission(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupPermissionID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsGroupPermissionRoles
        public void DeleteCateNewsGroupPermissionRoles(int Id, string lang)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionDeleteRoles", connection);
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

        #region DeleteCateNewsGroupPermissionCateID
        public void DeleteCateNewsGroupPermissionCateID(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionDeleteCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được bản ghi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetCateNewsGroupPermissionById
        public CateNewsGroupPermission GetCateNewsGroupPermissionById(int Id) 
        {
            CateNewsGroupPermission _cateNewsGroupPermission = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupPermissionID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _cateNewsGroupPermission = CateNewsGroupPermissionReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return _cateNewsGroupPermission;
        }
        #endregion

        #region GetCateNewsGroupPermissionByRoles
        public DataTable GetCateNewsGroupPermissionByRoles(int rolesID, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionGetByRoles", connection);
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

        #region GetCateNewsGroupPermissionByCateID
        public DataTable GetCateNewsGroupPermissionByCateID(int cateID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionGetByCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", cateID);
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

        #region GetCateNewsGroupPermissionAll
        public DataTable GetCateNewsGroupPermissionAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionGetAll",connection);
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

        #region GetCateNewsGroupPermission
        public CateNewsGroupPermission GetCateNewsGroupPermission(int rolesId, int _cateNewsGroupID)
        {
            CateNewsGroupPermission _cateNewsGroupPermission = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupPermissionGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RolesID", rolesId);
                command.Parameters.AddWithValue("@CateNewsGroupID", _cateNewsGroupID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _cateNewsGroupPermission = CateNewsGroupPermissionReader(reader);
                    //else
                    //    throw new DataAccessException("Không tìm thấy giá trị");
                    command.Dispose();
                }
            }
            return _cateNewsGroupPermission;
        }
        #endregion


        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, int _cateNewsGroupID)
        {
            bool check = false;

            CateNewsGroupPermission catenewsPermission = GetCateNewsGroupPermission(rolesID, _cateNewsGroupID);
            if (catenewsPermission != null)
                check = true;

            //DataTable dataTable = GetCateNewsGroupPermissionAll();
            //if (dataTable != null)
            //{
            //    DataView dataView = new DataView(dataTable);
            //    dataView.RowFilter = "RolesID = " + rolesID + " AND CateNewsGroupID = " + _cateNewsGroupID;
            //    if (dataView.Count > 0)
            //        check = true;
            //}
            return check;
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, int _cateNewsGroupID)
        {
            string permission = "";
            CateNewsGroupPermission catenewsPermission = GetCateNewsGroupPermission(rolesID, _cateNewsGroupID);
            if (catenewsPermission != null)
                permission = catenewsPermission.Permission;

            //if (CheckExitPermission(rolesID, _cateNewsGroupID))
            //{
            //    CateNewsGroupPermission catenewsPermission = GetCateNewsGroupPermission(rolesID, _cateNewsGroupID);
            //    permission = catenewsPermission.Permission;
            //}

            return permission;
        }
        #endregion

        #region GetRoles
        public string GetRoles(int cateID)
        {
            DataTable table = GetCateNewsGroupPermissionByCateID(cateID);
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

        #region GetCateNewsGroupID
        public string GetCateNewsGroupID(int rolesID, string lang)
        {
            DataTable table = GetCateNewsGroupPermissionByRoles(rolesID, lang);
            string str = "";
            string restr = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str += row["CateNewsGroupID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }

        public string GetCateNewsGroupID(string strRoles, string lang)
        {

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select * from tblCateNewsGroupPermission where RolesID IN('" + strRoles + "') AND [Language]=@Language";
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
                    str += row["CateNewsGroupID"].ToString() + ",";

                }

                restr = str.Remove(str.LastIndexOf(",")).Replace(",", "','");

            }
            return restr;
        }
        #endregion
        
    }
}
