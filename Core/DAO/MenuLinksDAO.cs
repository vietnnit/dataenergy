using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Web;
using ETO;
namespace DAO
{
    public class MenuLinksDAO : BaseDAO
    {
        public MenuLinksDAO()
        {
            //contructor
        }

        #region MenuLinksReader
        private MenuLinks MenuLinksReader(SqlDataReader reader) 
        {
            MenuLinks menuLinks         = new MenuLinks();
            menuLinks.MenuLinksID       = (int) reader["MenuLinksID"];
            menuLinks.MenuLinksName     = (string)reader["MenuLinksName"];
            menuLinks.MenuLinksOrder    = (int)reader["MenuLinksOrder"];
            menuLinks.MenuLinksParent   = (int)reader["MenuLinksParent"];
            menuLinks.MenuLinksUrl      = (string)reader["MenuLinksUrl"];
            menuLinks.MenuLinksHelp     = (string)reader["MenuLinksHelp"];
            menuLinks.MenuLinksIcon     = (string)reader["MenuLinksIcon"];
            menuLinks.Status            = (bool)reader["Status"];
            menuLinks.IsView            = (bool)reader["IsView"];
            menuLinks.Target            = (string)reader["Target"];
            menuLinks.IsFlash           = (bool)reader["IsFlash"];
            menuLinks.FileName          = (string)reader["FileName"];
            menuLinks.Position          = (string)reader["Position"];
            menuLinks.Width             = (int)reader["Width"];
            menuLinks.Height            = (int)reader["Height"];
            menuLinks.Hit               = (int)reader["Hit"];
            menuLinks.Language          = (string)reader["Language"];
            return menuLinks;
        }
        #endregion

        #region GetMenuLinksById
        public MenuLinks GetMenuLinksById(int ID) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID",ID);
                connection.Open();
                MenuLinks menuLinks = null;
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        menuLinks = MenuLinksReader(reader);
                    else
                        throw new DataAccessException("Lỗi : Không tìm thấy giá trị .. ");
                }
                return menuLinks;
            }
        }
        #endregion

        #region GetMenuLinksByUrl
        public MenuLinks GetMenuLinksByUrl(string url, string _lang)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByUrl", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksUrl", url);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                MenuLinks menuLinks = null;
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        menuLinks = MenuLinksReader(reader);
                    else
                        throw new DataAccessException("Lỗi : Không tìm thấy giá trị .. ");
                }
                return menuLinks;
            }
        }
        #endregion

        #region CreateMenuLinks
        public int CreateMenuLinks(MenuLinks menuLinks)
        {
            int i;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@MenuLinksID", 1);
                command.Parameters.AddWithValue("@MenuLinksName", menuLinks.MenuLinksName);
                command.Parameters.AddWithValue("@MenuLinksParent", menuLinks.MenuLinksParent);
                command.Parameters.AddWithValue("@MenuLinksUrl", menuLinks.MenuLinksUrl);
                command.Parameters.AddWithValue("@MenuLinksOrder", menuLinks.MenuLinksOrder);
                command.Parameters.AddWithValue("@MenuLinksHelp", menuLinks.MenuLinksHelp);
                command.Parameters.AddWithValue("@MenuLinksIcon", menuLinks.MenuLinksIcon);
                command.Parameters.AddWithValue("@Status", menuLinks.Status);
                command.Parameters.AddWithValue("@IsView", menuLinks.IsView);
                command.Parameters.AddWithValue("@Target", menuLinks.Target);
                command.Parameters.AddWithValue("@IsFlash", menuLinks.IsFlash);
                command.Parameters.AddWithValue("@FileName", menuLinks.FileName);
                command.Parameters.AddWithValue("@Position", menuLinks.Position);
                command.Parameters.AddWithValue("@Width", menuLinks.Width);
                command.Parameters.AddWithValue("@Height", menuLinks.Height);
                command.Parameters.AddWithValue("@Hit", menuLinks.Hit);
                command.Parameters.AddWithValue("@Language", menuLinks.Language);

                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc san pham");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateMenuLinks
        public int UpdateMenuLinks(MenuLinks menuLinks)
        {
            int i;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@MenuLinksID", menuLinks.MenuLinksID);
                command.Parameters.AddWithValue("@MenuLinksName", menuLinks.MenuLinksName);
                command.Parameters.AddWithValue("@MenuLinksParent", menuLinks.MenuLinksParent);
                command.Parameters.AddWithValue("@MenuLinksUrl", menuLinks.MenuLinksUrl);
                command.Parameters.AddWithValue("@MenuLinksOrder", menuLinks.MenuLinksOrder);
                command.Parameters.AddWithValue("@MenuLinksHelp", menuLinks.MenuLinksHelp);
                command.Parameters.AddWithValue("@MenuLinksIcon", menuLinks.MenuLinksIcon);
                command.Parameters.AddWithValue("@Status", menuLinks.Status);
                command.Parameters.AddWithValue("@IsView", menuLinks.IsView);
                command.Parameters.AddWithValue("@Target", menuLinks.Target);
                command.Parameters.AddWithValue("@IsFlash", menuLinks.IsFlash);
                command.Parameters.AddWithValue("@FileName", menuLinks.FileName);
                command.Parameters.AddWithValue("@Position", menuLinks.Position);
                command.Parameters.AddWithValue("@Width", menuLinks.Width);
                command.Parameters.AddWithValue("@Height", menuLinks.Height);
                command.Parameters.AddWithValue("@Hit", menuLinks.Hit);
                command.Parameters.AddWithValue("@Language", menuLinks.Language);
                connection.Open();
                i = command.ExecuteNonQuery();
                if (i <= 0)
                    throw new DataAccessException("lỗi không thể cập nhật");
                else
                    return i;

            }
        }
        #endregion

        #region GetAllMenuLinks
        public DataTable GetAllMenuLinks(string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }
        #endregion

        #region MixMenuLinks
        public DataTable MixMenuLinks(string _lang)
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("MenuLinksID");
            table1.Columns.Add("MenuLinksParent");
            table1.Columns.Add("MenuLinksName");
            table1.Columns.Add("MenuLinksUrl");
            table1.Columns.Add("MenuLinksOrder");
            table1.Columns.Add("MenuLinksHelp");
            table1.Columns.Add("MenuLinksIcon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Target");
            table1.Columns.Add("IsFlash");
            table1.Columns.Add("FileName");
            table1.Columns.Add("Position");
            table1.Columns.Add("Width");
            table1.Columns.Add("Height");
            table1.Columns.Add("Hit");
            table1.Columns.Add("Language");
            DataTable table2 = GetAllMenuLinks(_lang);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["MenuLinksID"] = r2["MenuLinksID"].ToString().Trim();
                r1["MenuLinksParent"] = r2["MenuLinksParent"].ToString().Trim();
                r1["MenuLinksName"] = r2["MenuLinksName"].ToString().Trim();
                r1["MenuLinksUrl"] = r2["MenuLinksUrl"].ToString().Trim();
                r1["MenuLinksOrder"] = r2["MenuLinksOrder"].ToString().Trim();
                r1["MenuLinksHelp"] = r2["MenuLinksHelp"].ToString().Trim();
                r1["MenuLinksIcon"] = r2["MenuLinksIcon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Target"] = r2["Target"].ToString().Trim();
                r1["IsFlash"] = r2["IsFlash"].ToString().Trim();
                r1["FileName"] = r2["FileName"].ToString().Trim();
                r1["Position"] = r2["Position"].ToString().Trim();
                r1["Width"] = r2["Width"].ToString().Trim();
                r1["Height"] = r2["Height"].ToString().Trim();
                r1["Hit"] = r2["Hit"].ToString().Trim();
                r1["Language"] = r2["Language"].ToString().Trim();

                table1.Rows.Add(r1);
                this.SubMixMenuLinks(table1, Convert.ToInt32(r1["MenuLinksID"]), "", _lang);
            }
            return table1;
        }
        #endregion

        #region SubMixMenuLinks
        public void SubMixMenuLinks(DataTable table, int mID, string sSpace, string _lang)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID", mID);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subTable);
                    command.Dispose();
                }
                if (subTable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subTable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["MenuLinksID"] = subrow["MenuLinksID"].ToString().Trim();
                        rs["MenuLinksParent"] = subrow["MenuLinksParent"].ToString().Trim();
                        rs["MenuLinksName"] = sSpace + subrow["MenuLinksName"].ToString().Trim();
                        rs["MenuLinksUrl"] = subrow["MenuLinksUrl"].ToString().Trim();
                        rs["MenuLinksOrder"] = subrow["MenuLinksOrder"].ToString().Trim();
                        rs["MenuLinksHelp"] = subrow["MenuLinksHelp"].ToString().Trim();
                        rs["MenuLinksIcon"] = subrow["MenuLinksIcon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Target"] = subrow["Target"].ToString().Trim();

                        rs["IsFlash"] = subrow["IsFlash"].ToString().Trim();
                        rs["FileName"] = subrow["FileName"].ToString().Trim();
                        rs["Position"] = subrow["Position"].ToString().Trim();
                        rs["Width"] = subrow["Width"].ToString().Trim();
                        rs["Height"] = subrow["Height"].ToString().Trim();
                        rs["Hit"] = subrow["Hit"].ToString().Trim();
                        rs["Language"] = subrow["Language"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixMenuLinks(table, Convert.ToInt32(rs["MenuLinksID"]), "", _lang);
                    }
                }
            }
        }
        #endregion

        #region DeleteMenuLinks
        public void DeleteMenuLinks(int ID) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Loi he thong");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region MenuLinksUpOrder
        public void MenuLinksUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID", cId);
                command.Parameters.AddWithValue("@MenuLinksOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetHotMenuLinks
        public DataTable GetHotMenuLinks(string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetHot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }
        #endregion

        #region GetHotMenuLinks
        public DataTable GetHotMenuLinks(int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblMenuLinks Where [Language]=@Language AND IsView=1 and Status=1 order by MenuLinksOrder ASC";
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
            return datatable;
        }
        public DataTable GetHotMenuLinks(string position, int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblMenuLinks Where [Language]=@Language AND IsView=1 and [Position]='" + position + "' and Status=1 order by MenuLinksOrder ASC";
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
            return datatable;
        }
        public DataTable GetMenuByParent(int ParentId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblMenuLinks Where [MenuLinksParent]=@MenuLinksParent AND IsView=1 and Status=1 order by MenuLinksOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@MenuLinksParent", ParentId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetHotMenuLinks(string position, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblMenuLinks Where [Language]=@Language AND IsView=1 and [Position]='" + position + "' and Status=1 order by MenuLinksOrder ASC";
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
            return datatable;
        }

        public DataTable GetRootMenuLinks(string position, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top 1 * from tblMenuLinks Where [Language]=@Language AND MenuLinksParent=0 and [Position]='" + position + "' order by MenuLinksOrder ASC";
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
            return datatable;
        }
        #endregion

        #region MixMenuLinksBullet
        public DataTable MixMenuLinksBullet(string bullet, string _lang)
        {
            string str = HttpUtility.HtmlDecode("<img src='images/"+bullet+"' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace = str;
            string sSpace1 = HttpUtility.HtmlDecode("</b>");

            DataTable table1 = new DataTable();
            table1.Columns.Add("MenuLinksID");
            table1.Columns.Add("MenuLinksParent");
            table1.Columns.Add("MenuLinksName");
            table1.Columns.Add("MenuLinksUrl");
            table1.Columns.Add("MenuLinksOrder");
            table1.Columns.Add("MenuLinksHelp");
            table1.Columns.Add("MenuLinksIcon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Target");
            table1.Columns.Add("IsFlash");
            table1.Columns.Add("FileName");
            table1.Columns.Add("Position");
            table1.Columns.Add("Width");
            table1.Columns.Add("Height");
            table1.Columns.Add("Hit");
            table1.Columns.Add("Language");
            DataTable table2 = GetAllMenuLinks(_lang);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["MenuLinksID"] = r2["MenuLinksID"].ToString().Trim();
                r1["MenuLinksParent"] = r2["MenuLinksParent"].ToString().Trim();
                r1["MenuLinksName"] = sSpace + r2["MenuLinksName"].ToString().Trim() +sSpace1;
                r1["MenuLinksUrl"] = r2["MenuLinksUrl"].ToString().Trim();
                r1["MenuLinksOrder"] = r2["MenuLinksOrder"].ToString().Trim();
                r1["MenuLinksHelp"] = r2["MenuLinksHelp"].ToString().Trim();
                r1["MenuLinksIcon"] = r2["MenuLinksIcon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Target"] = r2["Target"].ToString().Trim();
                r1["IsFlash"] = r2["IsFlash"].ToString().Trim();
                r1["FileName"] = r2["FileName"].ToString().Trim();
                r1["Position"] = r2["Position"].ToString().Trim();
                r1["Width"] = r2["Width"].ToString().Trim();
                r1["Height"] = r2["Height"].ToString().Trim();
                r1["Hit"] = r2["Hit"].ToString().Trim();
                r1["Language"] = r2["Language"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixMenuLinksBullet(table1, Convert.ToInt32(r1["MenuLinksID"]), "",bullet, _lang);
            }
            return table1;
        }
        #endregion

        #region SubMixMenuLinksBullet
        public void SubMixMenuLinksBullet(DataTable table, int mID, string sSpace, string bullet, string _lang)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID", mID);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subTable);
                    command.Dispose();
                }
                if (subTable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subTable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["MenuLinksID"] = subrow["MenuLinksID"].ToString().Trim();
                        rs["MenuLinksParent"] = subrow["MenuLinksParent"].ToString().Trim();
                        rs["MenuLinksName"] = sSpace + subrow["MenuLinksName"].ToString().Trim();
                        rs["MenuLinksUrl"] = subrow["MenuLinksUrl"].ToString().Trim();
                        rs["MenuLinksOrder"] = subrow["MenuLinksOrder"].ToString().Trim();
                        rs["MenuLinksHelp"] = subrow["MenuLinksHelp"].ToString().Trim();
                        rs["MenuLinksIcon"] = subrow["MenuLinksIcon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Target"] = subrow["Target"].ToString().Trim();
                        rs["IsFlash"] = subrow["IsFlash"].ToString().Trim();
                        rs["FileName"] = subrow["FileName"].ToString().Trim();
                        rs["Position"] = subrow["Position"].ToString().Trim();
                        rs["Width"] = subrow["Width"].ToString().Trim();
                        rs["Height"] = subrow["Height"].ToString().Trim();
                        rs["Hit"] = subrow["Hit"].ToString().Trim();
                        rs["Language"] = subrow["Language"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixMenuLinksBullet(table, Convert.ToInt32(rs["MenuLinksID"]), "",bullet,_lang);
                    }
                }
            }
        }
        #endregion

        #region MenuLinksClickUpdate
        public void MenuLinksClickUpdate(int nId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksClickUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion
    }
}