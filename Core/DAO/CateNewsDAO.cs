using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class CateNewsDAO : BaseDAO
    {
        public CateNewsDAO() 
        {
            //constructor
        }

        #region CateNewsReader
        private CateNews CateNewsReader(SqlDataReader reader) 
        {
            CateNews catenews = new CateNews();
            catenews.CateNewsID = (int)reader["CateNewsID"];
            catenews.ParentNewsID = (int)reader["ParentNewsID"];
            catenews.CateNewsName = (string)reader["CateNewsName"];
            catenews.CateNewsTotal = (int)reader["CateNewsTotal"];
            catenews.CateNewsOrder = (int)reader["CateNewsOrder"];
            catenews.Language = (string) reader["Language"];
            catenews.GroupCate = (int)reader["GroupCate"];
            catenews.Icon = (string)reader["Icon"];
            catenews.Slogan = (string)reader["Slogan"];
            catenews.Roles = (string)reader["Roles"];
            catenews.UserName = (string)reader["UserName"];
            catenews.Created = (DateTime)reader["Created"];
            catenews.isUrl = (bool)reader["isUrl"];
            catenews.Url = (string)reader["Url"];
            catenews.Status = (bool)reader["Status"];
            catenews.ShortName = (string)reader["ShortName"];
            catenews.PageLayoutID = (int)reader["PageLayoutID"];
            return catenews;
        }
        #endregion

        #region CreateCateNews
        public void CreateCateNews(CateNews catenews) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@ParentNewsID",catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName",catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal",catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder",catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language",catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                command.Parameters.AddWithValue("@Status", catenews.Status);
                command.Parameters.AddWithValue("@ShortName", catenews.ShortName);
                command.Parameters.AddWithValue("@PageLayoutID", catenews.PageLayoutID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể tạo danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CreateCateNewsGet
        public int CreateCateNewsGet(CateNews catenews)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ParentNewsID", catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName", catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal", catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder", catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language", catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@Status", catenews.Status);
                command.Parameters.AddWithValue("@ShortName", catenews.ShortName);
                command.Parameters.AddWithValue("@PageLayoutID", catenews.PageLayoutID);
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

        #region UpdateCateNews
        public void UpdateCateNews(CateNews catenews)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsID",catenews.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName", catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal", catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder", catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language", catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                command.Parameters.AddWithValue("@Status", catenews.Status);
                command.Parameters.AddWithValue("@ShortName", catenews.ShortName);
                command.Parameters.AddWithValue("@PageLayoutID", catenews.PageLayoutID);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteCateNews
        public void DeleteCateNews(int cId) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID",cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa danh mục tin");
                else
                    command.Dispose();
            }
            
        }
        #endregion


        #region UpdateCateNewsGroupCate
        public void UpdateCateNewsGroupCatebyAll(int cateNewsId, int groupCate, string lang)
        {
             DataTable table = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetUrl", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID",cateNewsId);
                command.Parameters.AddWithValue("@Language",lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    UpdateCateNewsGroupCatebyID(Convert.ToInt32(row["CateNewsID"].ToString()), groupCate);
                    UpdateCateNewsGroupCatebyAll(Convert.ToInt32(row["CateNewsID"].ToString()), groupCate, lang);
                }
            }
        }

        public void UpdateCateNewsGroupCatebyID(int cateNewsId, int groupCate)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblCateNews set GroupCate = @GroupCate where CateNewsID = @CateNewsID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@CateNewsID", cateNewsId);
                command.Parameters.AddWithValue("@GroupCate", groupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CateNewsUpOrder
        public void CateNewsUpOrder(int cId , int cOrder) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cId);
                command.Parameters.AddWithValue("@CateNewsOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetCateNews
        public DataTable GetCateNews(string lang) 
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");
           

            DataTable table = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID",0);
                command.Parameters.AddWithValue("@Language",lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                   
                    datatable.Rows.Add(datarow);
                    this.GetParentNews(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;");
                }
            
            }
            return datatable;
        }

        private void GetParentNews(DataTable table, int cID, string language, int level, string sSpace)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Url"] = subrow["Url"].ToString();
                        rs["IsUrl"] = subrow["IsUrl"].ToString();
                        rs["status"] = subrow["status"].ToString();
                        rs["ShortName"] = subrow["ShortName"].ToString();
                        rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                        table.Rows.Add(rs);
                        this.GetParentNews(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;");
                    }
                }
            }
        }
        #endregion

        
        #region GetCateNewsById
        public CateNews GetCateNewsById(int cId) 
        {
            CateNews catenews = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID",cId);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        catenews = CateNewsReader(reader);
                    else
                        return catenews;
                       // throw new DataAccessException("Không tìm thấy danh mục");
                    command.Dispose();
                }
            }
            return catenews;
        }

        public string GetSlugByCateId(int cId)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsSlugById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cId);
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

        #region GetCateNewsParentAll
        public DataTable GetCateNewsParentAll(int Id, string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 1);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        #endregion

        #region GetCateCompanyParentAll
        public DataTable GetCateCompanyParentAll(int Id, string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 2);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        #endregion

        #region GetCateParentGroupAll
        public DataTable GetCateParentGroupAll(int Id, string lang,int group)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        #endregion

        #region GetCateGroup
        public DataTable GetCateGroup(string lang, int group)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroup(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;", group);
                }

            }
            return datatable;
        }

        private void GetParentGroup(DataTable table, int cID, string language, int level, string sSpace, int group)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Url"] = subrow["Url"].ToString();
                        rs["IsUrl"] = subrow["IsUrl"].ToString();
                        rs["status"] = subrow["status"].ToString();
                        rs["ShortName"] = subrow["ShortName"].ToString();
                        rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroup(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;",group);
                    }
                }
            }
        }

        #endregion

        

        #region GetCateGroupRoles
        public DataTable GetCateGroupRoles(string lang, int group, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();
                    
                    command.CommandText = "_CateGetGroup";
                    command.Connection = connection;

                    //  SqlCommand command = new SqlCommand("_CateGetGroup", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }

                
            }

               
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupRoles(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", group, username);
                }

            }
            return datatable;
        }

        private void GetParentGroupRoles(DataTable table, int cID, string language, int level, string sSpace, int group, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();
                    
                    command.CommandText = "_CateGetGroup";
                    command.Connection = connection;

                    //     SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
               


            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["status"] = subrow["status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentGroupRoles(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace, group, username);
                }
            }
        }

        #endregion

        #region GetCateRoles
        public DataTable GetCateRoles(string lang, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
  
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }


            }


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentRoles(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", username);
                }

            }
            return datatable;
        }

        private void GetParentRoles(DataTable table, int cID, string language, int level, string sSpace, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);

                   
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }



            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["status"] = subrow["status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentRoles(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace,  username);
                }
            }
        }

        #endregion
        #region GetCateGroupBullet
        public DataTable GetCateGroupBullet(string lang, int group, string bullet)
        {
            string str = HttpUtility.HtmlDecode("<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace = str;
            string sSpace1 = HttpUtility.HtmlDecode("</b>");


            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");
            datatable.Columns.Add("SlugPageName");

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = sSpace+ row["CateNewsName"].ToString() +sSpace1;
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();
                    datarow["SlugPageName"] = GetSlugByCateId(Convert.ToInt32(row["CateNewsID"].ToString()));

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupBullet(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;", group, bullet);
                }

            }
            return datatable;
        }

        private void GetParentGroupBullet(DataTable table, int cID, string language, int level, string sSpace, int group, string bullet)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;");
         //   sSpace = sSpace + str;

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            sStr += str;
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Url"] = subrow["Url"].ToString();
                        rs["IsUrl"] = subrow["IsUrl"].ToString();
                        rs["status"] = subrow["status"].ToString();
                        rs["ShortName"] = subrow["ShortName"].ToString();
                        rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();
                        rs["SlugPageName"] = GetSlugByCateId(Convert.ToInt32(subrow["CateNewsID"].ToString()));
                        table.Rows.Add(rs);
                        this.GetParentGroupBullet(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;", group, bullet);
                    }
                }
            }
        }
        #endregion


        #region GetCateParentGroupRolesAll
        public DataTable GetCateParentGroupRolesAll(int Id, string lang, int group, string username)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroupRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        #endregion

        #region GetCateNewsName
        public DataTable GetCateNewsName(string lang)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("GroupCateName");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["GroupCateName"] = row["GroupCateName"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();


                    datatable.Rows.Add(datarow);
                    this.GetParentNewsName(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                }

            }
            return datatable;
        }

        private void GetParentNewsName(DataTable table, int cID, string language, int level, string sSpace)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["GroupCateName"] = subrow["GroupCateName"].ToString();
                        rs["Url"] = subrow["Url"].ToString();
                        rs["IsUrl"] = subrow["IsUrl"].ToString();
                        rs["status"] = subrow["status"].ToString();
                        rs["ShortName"] = subrow["ShortName"].ToString();
                        rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                        table.Rows.Add(rs);
                        this.GetParentNewsName(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                }
            }
        }

        public DataTable GetCateNewsName(string lang, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("GroupCateName");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }

                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }


            }


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["GroupCateName"] = row["GroupCateName"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentNewsName(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);

                }

            }
            return datatable;
        }

        private void GetParentNewsName(DataTable table, int cID, string language, int level, string sSpace, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0 ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }



            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["GroupCateName"] = subrow["GroupCateName"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["status"] = subrow["status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentNewsName(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);
                }
            }
        }

        public DataTable GetCateNewsNamePermission(string lang, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("GroupCateName");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }

                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                CateNewsGroupPermissionDAO catenewGroupPermissionDAO = new CateNewsGroupPermissionDAO();
                string strCateGroupID = catenewGroupPermissionDAO.GetCateNewsGroupID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND tblCateNews.Language = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0 AND tblCateNewsGroup.CateNewsGroupID in('" + strCateGroupID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }


            }


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["GroupCateName"] = row["GroupCateName"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentNewsNamePermission(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);

                }

            }
            return datatable;
        }

        private void GetParentNewsNamePermission(DataTable table, int cID, string language, int level, string sSpace, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                CateNewsGroupPermissionDAO catenewGroupPermissionDAO = new CateNewsGroupPermissionDAO();
                string strCateGroupID = catenewGroupPermissionDAO.GetCateNewsGroupID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND tblCateNews.Language = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0  AND tblCateNewsGroup.CateNewsGroupID in('" + strCateGroupID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }



            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["GroupCateName"] = subrow["GroupCateName"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["status"] = subrow["status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentNewsNamePermission(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);
                }
            }
        }
        #endregion

        //Getcate groupRoles by Url
        #region GetCateGroupRolesUrl
        public DataTable GetCateGroupRolesUrl(string lang, int group, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("Status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "_CateGetGroupUrl";
                    command.Connection = connection;

                    //  SqlCommand command = new SqlCommand("_CateGetGroup", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }


            }


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["Status"] = row["Status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupRolesUrl(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", group, username);
                }

            }
            return datatable;
        }

        private void GetParentGroupRolesUrl(DataTable table, int cID, string language, int level, string sSpace, int group, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "_CateGetGroupUrl";
                    command.Connection = connection;

                    //     SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }



            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["Status"] = subrow["Status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentGroupRoles(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace, group, username);
                }
            }
        }

        #endregion

        #region GetCateGroupRolesWithPage
        public DataTable GetCateGroupRolesWithPage(string lang, int group, string username)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("Status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");
            datatable.Columns.Add("PageName");
            datatable.Columns.Add("SlugPageName");

            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "_CateGetGroupWithPage";
                    command.Connection = connection;

                    //  SqlCommand command = new SqlCommand("_CateGetGroup", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }

            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, lang);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*, SYS_PageLayout.PageName, SYS_PageLayout.SlugPageName FROM SYS_PageLayout INNER JOIN  tblCateNews ON SYS_PageLayout.Id = tblCateNews.PageLayoutID  WHERE  tblCateNews.[ParentNewsID] = @CateNewsID AND  tblCateNews.[Language] = @Language  AND  tblCateNews.[GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "')	ORDER BY  tblCateNews.CateNewsOrder ASC";
                  //  string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }


            }


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["Status"] = row["Status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();
                    datarow["PageName"] = row["PageName"].ToString();
                    datarow["SlugPageName"] = row["SlugPageName"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupRolesWithPage(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", group, username);
                }

            }
            return datatable;
        }

        private void GetParentGroupRolesWithPage(DataTable table, int cID, string language, int level, string sSpace, int group, string username)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();

            if (username.Equals("administrator"))
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "_CateGetGroupWithPage";
                    command.Connection = connection;

                    //     SqlCommand command = new SqlCommand("_CateGetGroup", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }

                }
            }
            else
            {
                AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
                string strRoles = adminRolesDAO.GetRoles(username);
                CateNewsPermissionDAO catenewPermissionDAO = new CateNewsPermissionDAO();
                string strCateID = catenewPermissionDAO.GetCateNewsID(strRoles, language);

                using (SqlConnection connection = GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*, SYS_PageLayout.PageName, SYS_PageLayout.SlugPageName FROM SYS_PageLayout INNER JOIN  tblCateNews ON SYS_PageLayout.Id = tblCateNews.PageLayoutID  WHERE  tblCateNews.[ParentNewsID] = @CateNewsID AND  tblCateNews.[Language] = @Language  AND  tblCateNews.[GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "')	ORDER BY  tblCateNews.CateNewsOrder ASC";
                    //  string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }



            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    rs["Status"] = subrow["Status"].ToString();
                    rs["ShortName"] = subrow["ShortName"].ToString();
                    rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();
                    rs["PageName"] = subrow["PageName"].ToString();
                    rs["SlugPageName"] = subrow["SlugPageName"].ToString();

                    table.Rows.Add(rs);
                    this.GetParentGroupRolesWithPage(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace, group, username);
                }
            }
        }

        #endregion
        public DataTable GetCateNewsBystrId(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblCateNews where CateNewsID in('" + strCate + "') AND Status = 1  ORDER BY CateNewsOrder ASC";
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

        public DataTable GetCateNewsBystrId(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblCateNews where CateNewsID in('" + strCate + "') AND Status = 1  ORDER BY CateNewsOrder ASC";
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

        #region GetCateGroupStatus
        public DataTable GetCateGroupStatus(string lang, int group, bool status)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Url");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("status");
            datatable.Columns.Add("ShortName");
            datatable.Columns.Add("PageLayoutID");

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroupStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["status"] = row["status"].ToString();
                    datarow["ShortName"] = row["ShortName"].ToString();
                    datarow["PageLayoutID"] = row["PageLayoutID"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupStatus(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;", group, status);
                }

            }
            return datatable;
        }

        private void GetParentGroupStatus(DataTable table, int cID, string language, int level, string sSpace, int group, bool status)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroupStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Url"] = subrow["Url"].ToString();
                        rs["IsUrl"] = subrow["IsUrl"].ToString();
                        rs["status"] = subrow["status"].ToString();
                        rs["ShortName"] = subrow["ShortName"].ToString();
                        rs["PageLayoutID"] = subrow["PageLayoutID"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroup(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;", group);
                    }
                }
            }
        }

        #endregion
    }
}
