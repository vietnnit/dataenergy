using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class CateNewsGroupDAO : BaseDAO
    {
        public CateNewsGroupDAO()
        {
            //constructor
        }

        #region CateNewsGroupReader
        private CateNewsGroup CateNewsGroupReader(SqlDataReader reader)
        {
            CateNewsGroup cateNewsGroup = new CateNewsGroup();
            cateNewsGroup.CateNewsGroupID = (int)reader["CateNewsGroupID"];
            cateNewsGroup.GroupCate = (int)reader["GroupCate"];
            cateNewsGroup.CateNewsGroupName = (string)reader["CateNewsGroupName"];
            cateNewsGroup.ShortName = (string)reader["ShortName"];
            cateNewsGroup.Description = (string)reader["Description"];
            cateNewsGroup.Order = (int)reader["Order"];
            cateNewsGroup.IsView = (bool)reader["IsView"];
            cateNewsGroup.IsHome = (bool)reader["IsHome"];
            cateNewsGroup.IsMenu = (bool)reader["IsMenu"];
            cateNewsGroup.IsNew = (bool)reader["IsNew"];
            cateNewsGroup.IsPage = (bool)reader["IsPage"];
            cateNewsGroup.IsRegister = (bool)reader["IsRegister"];
            cateNewsGroup.IsFaq = (bool)reader["IsFaq"];
            cateNewsGroup.IsUrl = (bool)reader["IsUrl"];
            cateNewsGroup.Url = (string)reader["Url"];
            cateNewsGroup.Icon = (string)reader["Icon"];
            cateNewsGroup.Position = (int)reader["Position"];
            cateNewsGroup.Menu = (int)reader["Menu"];
            cateNewsGroup.IsOfficial = (bool)reader["IsOfficial"];
            cateNewsGroup.Language = (string)reader["Language"];
            cateNewsGroup.PageLayoutID = (int)reader["PageLayoutID"];



            return cateNewsGroup;
        }
        #endregion

        #region CreateCateNewsGroup
        public int CreateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CateNewsGroupID", 0);
                command.Parameters.AddWithValue("@GroupCate", cateNewsGroup.GroupCate);
                command.Parameters.AddWithValue("@CateNewsGroupName", cateNewsGroup.CateNewsGroupName);
                command.Parameters.AddWithValue("@ShortName", cateNewsGroup.ShortName);
                command.Parameters.AddWithValue("@Description", cateNewsGroup.Description);
                command.Parameters.AddWithValue("@Order", cateNewsGroup.Order);
                command.Parameters.AddWithValue("@IsView", cateNewsGroup.IsView);
                command.Parameters.AddWithValue("@IsHome", cateNewsGroup.IsHome);
                command.Parameters.AddWithValue("@IsMenu", cateNewsGroup.IsMenu);
                command.Parameters.AddWithValue("@IsNew", cateNewsGroup.IsNew);
                command.Parameters.AddWithValue("@IsPage", cateNewsGroup.IsPage);
                command.Parameters.AddWithValue("@IsRegister", cateNewsGroup.IsRegister);
                command.Parameters.AddWithValue("@IsFaq", cateNewsGroup.IsFaq);
                command.Parameters.AddWithValue("@IsUrl", cateNewsGroup.IsUrl);
                command.Parameters.AddWithValue("@Url", cateNewsGroup.Url);
                command.Parameters.AddWithValue("@Icon", cateNewsGroup.Icon);
                command.Parameters.AddWithValue("@Position", cateNewsGroup.Position);
                command.Parameters.AddWithValue("@Menu", cateNewsGroup.Menu);
                command.Parameters.AddWithValue("@IsOfficial", cateNewsGroup.IsOfficial);
                command.Parameters.AddWithValue("@Language", cateNewsGroup.Language);
                command.Parameters.AddWithValue("@PageLayoutID", cateNewsGroup.PageLayoutID);

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

        #region UpdateCateNewsGroup
        public void UpdateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsGroupID", cateNewsGroup.CateNewsGroupID);
                command.Parameters.AddWithValue("@GroupCate", cateNewsGroup.GroupCate);
                command.Parameters.AddWithValue("@CateNewsGroupName", cateNewsGroup.CateNewsGroupName);
                command.Parameters.AddWithValue("@ShortName", cateNewsGroup.ShortName);
                command.Parameters.AddWithValue("@Description", cateNewsGroup.Description);
                command.Parameters.AddWithValue("@Order", cateNewsGroup.Order);
                command.Parameters.AddWithValue("@IsView", cateNewsGroup.IsView);
                command.Parameters.AddWithValue("@IsHome", cateNewsGroup.IsHome);
                command.Parameters.AddWithValue("@IsMenu", cateNewsGroup.IsMenu);
                command.Parameters.AddWithValue("@IsNew", cateNewsGroup.IsNew);
                command.Parameters.AddWithValue("@IsPage", cateNewsGroup.IsPage);
                command.Parameters.AddWithValue("@IsRegister", cateNewsGroup.IsRegister);
                command.Parameters.AddWithValue("@IsFaq", cateNewsGroup.IsFaq);
                command.Parameters.AddWithValue("@IsUrl", cateNewsGroup.IsUrl);
                command.Parameters.AddWithValue("@Url", cateNewsGroup.Url);
                command.Parameters.AddWithValue("@Icon", cateNewsGroup.Icon);
                command.Parameters.AddWithValue("@Position", cateNewsGroup.Position);
                command.Parameters.AddWithValue("@Menu", cateNewsGroup.Menu);
                command.Parameters.AddWithValue("@IsOfficial", cateNewsGroup.IsOfficial);
                command.Parameters.AddWithValue("@Language", cateNewsGroup.Language);
                command.Parameters.AddWithValue("@PageLayoutID", cateNewsGroup.PageLayoutID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNewsGroup
        public void DeleteCateNewsGroup(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc quang cao");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetCateNewsGroupById
        public CateNewsGroup GetCateNewsGroupById(int Id)
        {
            CateNewsGroup cateNewsGroup = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        cateNewsGroup = CateNewsGroupReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return cateNewsGroup;
        }
        #endregion

        #region GetSlugById
        public string GetSlugById(int Id)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupSlugById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
                return table.Rows[0]["SlugPageName"].ToString();
            else
                return "home";
        }
        #endregion

        #region GetCateNewsGroupByGroupCate
        public CateNewsGroup GetCateNewsGroupByGroupCate(int groupcate, string _lang)
        {
            CateNewsGroup cateNewsGroup = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetByGroupCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", groupcate);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        cateNewsGroup = CateNewsGroupReader(reader);
                    else
                        //throw new DataAccessException("Khong tim thay gia tri nao");'
                        cateNewsGroup = null;
                    command.Dispose();
                }
            }
            return cateNewsGroup;
        }
        #endregion

        #region GetCateNewsGroupAll
        public DataTable GetCateNewsGroupAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetCateNewsGroupAll(string _lang, string username)
        {
            DataTable datatable = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGroupGetAll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Language", _lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsGroupPermissionDAO catenewGroupPermissionDAO = new CateNewsGroupPermissionDAO();
                string strCateID = catenewGroupPermissionDAO.GetCateNewsGroupID(strRoles, _lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT  tblCateNewsGroup.*, SYS_PageLayout.PageName, SYS_PageLayout.SlugPageName  FROM SYS_PageLayout INNER JOIN  tblCateNewsGroup ON SYS_PageLayout.Id = tblCateNewsGroup.PageLayoutID  WHERE tblCateNewsGroup.Language=@Language AND [CateNewsGroupID] in('" + strCateID + "') Order by [Order] ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@Language", _lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }

            }
            return datatable;
        }
        #endregion

        #region GetCateNewsGroupViewAll
        public DataTable GetCateNewsGroupViewAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetViewAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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
        #region GetCateNewsGroupHomeAll
        public DataTable GetCateNewsGroupHomeAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetHomeAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetCateNewsGroupMenuAll
        public DataTable GetCateNewsGroupMenuAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetMenuAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetCateNewsGroupNewAll
        public DataTable GetCateNewsGroupNewAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetNewsAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetCateNewsGroupNewAll(string _lang, string username)
        {
            DataTable datatable = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGroupGetNewsAll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Language", _lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsGroupPermissionDAO catenewGroupPermissionDAO = new CateNewsGroupPermissionDAO();
                string strCateID = catenewGroupPermissionDAO.GetCateNewsGroupID(strRoles, _lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT  tblCateNewsGroup.*  FROM tblCateNewsGroup  WHERE [IsNew] = 1 And Language=@Language AND [CateNewsGroupID] in('" + strCateID + "') Order by [Order] ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@Language", _lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }

            }
            return datatable;
        }
        #endregion

        #region GetCateNewsGroupPageAll
        public DataTable GetCateNewsGroupPageAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetPageAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetCateNewsGroupRegisterAll
        public DataTable GetCateNewsGroupRegisterAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetRegisterAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetCateNewsGroupOfficialAll
        public DataTable GetCateNewsGroupOfficialAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetOfficialAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetCateNewsGroupOfficialAll(string _lang, string username)
        {
            DataTable datatable = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGroupGetOfficialAll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Language", _lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsGroupPermissionDAO catenewGroupPermissionDAO = new CateNewsGroupPermissionDAO();
                string strCateID = catenewGroupPermissionDAO.GetCateNewsGroupID(strRoles, _lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT  tblCateNewsGroup.*  FROM tblCateNewsGroup  WHERE [IsOfficial] = 1 And Language=@Language AND [CateNewsGroupID] in('" + strCateID + "') Order by [Order] ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@Language", _lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();
                    }
                }

            }
            return datatable;
        }
        #endregion

        #region GetCateNewsGroupFaqAll
        public DataTable GetCateNewsGroupFaqAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetFaqAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetCateNewsGroupByMenu
        public DataTable GetCateNewsGroupByMenu(int _menu, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetMenu", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Menu", _menu);
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region CateNewsGroupUpOrder
        public void CateNewsGroupUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", cId);
                command.Parameters.AddWithValue("@Order", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CateNewsGroupUpMenu
        public void CateNewsGroupUpMenu(int cId, int _menu)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpMenu", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsGroupID", cId);
                command.Parameters.AddWithValue("@Menu", _menu);
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
