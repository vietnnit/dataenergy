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
    public class ModulesDAO : BaseDAO
    {
        public ModulesDAO()
        {
            //contructor
        }

        #region ModulesReader
        private Modules ModulesReader(SqlDataReader reader) 
        {
            Modules modules         = new Modules();
            modules.ModulesID       = (int) reader["Modules_ID"];
            modules.ModulesName     = (string)reader["Modules_Name"];
            modules.ModulesOrder    = (int)reader["Modules_Order"];
            modules.ModulesParent   = (int)reader["Modules_Parent"];
            modules.ModulesDir      = (string)reader["Modules_Dir"];
            modules.ModulesUrl      = (string)reader["Modules_Url"];
            modules.ModulesHelp     = (string)reader["Modules_Help"];
            modules.ModulesIcon     = (string)reader["Modules_Icon"];
            modules.Status          = (bool)reader["Status"];
            modules.IsMenu          = (bool)reader["IsMenu"];
            modules.IsView          = (bool)reader["IsView"];
            modules.Slug            = (string)reader["Slug"];
            return modules;
        }
        #endregion

        #region GetModulesById
        public Modules GetModulesById(int ID) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_ID",ID);
                connection.Open();
                Modules modules = null;
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        modules = ModulesReader(reader);
                    else
                        throw new DataAccessException("Lỗi : Không tìm thấy giá trị .. ");
                }
                return modules;
            }
        }
        #endregion

        #region GetModulesByUrl
        public Modules GetModulesByUrl(string url)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByUrl", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_Url", url);
                connection.Open();
                Modules modules = null;
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        modules = ModulesReader(reader);
                    else
                        throw new DataAccessException("Lỗi : Không tìm thấy giá trị .. ");
                }
                return modules;
            }
        }
        #endregion

        #region GetModulesBySlug
        public Modules GetModulesBySlug(string slug)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetBySlug", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Slug", slug);
                connection.Open();
                Modules modules = null;
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        modules = ModulesReader(reader);
                    else
                        throw new DataAccessException("Lỗi : Không tìm thấy giá trị .. ");
                }
                return modules;
            }
        }
        #endregion

        #region CreateModules
        public int CreateModules(Modules modules)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Modules_ID", 1);
                command.Parameters.AddWithValue("@Modules_Name", modules.ModulesName);
                command.Parameters.AddWithValue("@Modules_Parent", modules.ModulesParent);
                command.Parameters.AddWithValue("@Modules_Dir", modules.ModulesDir);
                command.Parameters.AddWithValue("@Modules_Url", modules.ModulesUrl);
                command.Parameters.AddWithValue("@Modules_Order", modules.ModulesOrder);
                command.Parameters.AddWithValue("@Modules_Help", modules.ModulesHelp);
                command.Parameters.AddWithValue("@Modules_Icon", modules.ModulesIcon);
                command.Parameters.AddWithValue("@Status", modules.Status);
                command.Parameters.AddWithValue("@IsMenu", modules.IsMenu);
                command.Parameters.AddWithValue("@IsView", modules.IsView);
                command.Parameters.AddWithValue("@Slug", modules.Slug);
                //connection.Open();
                //i = command.ExecuteNonQuery();
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

        #region UpdateModules
        public int UpdateModules(Modules modules)
        {
            int i;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Modules_ID", modules.ModulesID);
                command.Parameters.AddWithValue("@Modules_Name", modules.ModulesName);
                command.Parameters.AddWithValue("@Modules_Parent", modules.ModulesParent);
                command.Parameters.AddWithValue("@Modules_Dir", modules.ModulesDir);
                command.Parameters.AddWithValue("@Modules_Url", modules.ModulesUrl);
                command.Parameters.AddWithValue("@Modules_Order", modules.ModulesOrder);
                command.Parameters.AddWithValue("@Modules_Help", modules.ModulesHelp);
                command.Parameters.AddWithValue("@Modules_Icon", modules.ModulesIcon);
                command.Parameters.AddWithValue("@Status", modules.Status);
                command.Parameters.AddWithValue("@IsMenu", modules.IsMenu);
                command.Parameters.AddWithValue("@IsView", modules.IsView);
                command.Parameters.AddWithValue("@Slug", modules.Slug);
                connection.Open();
                i = command.ExecuteNonQuery();
                if (i <= 0)
                    throw new DataAccessException("lỗi không thể cập nhật");
                else
                    return i;

            }
        }
        #endregion

        #region GetAllModules
        public DataTable GetAllModules()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
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

        #region GetModulesByParent
        public DataTable GetModulesByParent(int cID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_ID", cID);
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

        #region MixModules
        public DataTable MixModules()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Modules_ID");
            table1.Columns.Add("Modules_Parent");
            table1.Columns.Add("Modules_Name");
            table1.Columns.Add("Modules_Dir");
            table1.Columns.Add("Modules_Url");
            table1.Columns.Add("Modules_Order");
            table1.Columns.Add("Modules_Help");
            table1.Columns.Add("Modules_Icon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsMenu");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Slug");
            DataTable table2 = GetModulesByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["Modules_ID"] = r2["Modules_ID"].ToString().Trim();
                r1["Modules_Parent"] = r2["Modules_Parent"].ToString().Trim();
                r1["Modules_Name"] = r2["Modules_Name"].ToString().Trim();
                r1["Modules_Dir"] = r2["Modules_Dir"].ToString().Trim();
                r1["Modules_Url"] = r2["Modules_Url"].ToString().Trim();
                r1["Modules_Order"] = r2["Modules_Order"].ToString().Trim();
                r1["Modules_Help"] = r2["Modules_Help"].ToString().Trim();
                r1["Modules_Icon"] = r2["Modules_Icon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsMenu"] = r2["IsMenu"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Slug"] = r2["Slug"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixModules(table1, Convert.ToInt32(r1["Modules_ID"]), HttpUtility.HtmlDecode("&nbsp;&nbsp;"));
            }
            return table1;
        }
        #endregion

        #region SubMixModules
        public void SubMixModules(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_ID", mID);
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
                        rs["Modules_ID"] = subrow["Modules_ID"].ToString().Trim();
                        rs["Modules_Parent"] = subrow["Modules_Parent"].ToString().Trim();
                        rs["Modules_Name"] = sSpace + subrow["Modules_Name"].ToString().Trim();
                        rs["Modules_Dir"] = subrow["Modules_Dir"].ToString().Trim();
                        rs["Modules_Url"] = subrow["Modules_Url"].ToString().Trim();
                        rs["Modules_Order"] = subrow["Modules_Order"].ToString().Trim();
                        rs["Modules_Help"] = subrow["Modules_Help"].ToString().Trim();
                        rs["Modules_Icon"] = subrow["Modules_Icon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsMenu"] = subrow["IsMenu"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Slug"] = subrow["Slug"].ToString().Trim();

                        table.Rows.Add(rs);
                        this.SubMixModules(table, Convert.ToInt32(rs["Modules_ID"]), sSpace);
                    }
                }
            }
        }
        #endregion

        #region MixModulesAdmin
        public DataTable MixModulesAdmin()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Modules_ID");
            table1.Columns.Add("Modules_Parent");
            table1.Columns.Add("Modules_Name");
            table1.Columns.Add("Modules_Dir");
            table1.Columns.Add("Modules_Url");
            table1.Columns.Add("Modules_Order");
            table1.Columns.Add("Modules_Help");
            table1.Columns.Add("Modules_Icon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsMenu");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Slug");
            DataTable table2 = GetModulesByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["Modules_ID"] = r2["Modules_ID"].ToString().Trim();
                r1["Modules_Parent"] = r2["Modules_Parent"].ToString().Trim();
                r1["Modules_Name"] = r2["Modules_Name"].ToString().Trim();
                r1["Modules_Dir"] = r2["Modules_Dir"].ToString().Trim();
                r1["Modules_Url"] = r2["Modules_Url"].ToString().Trim();
                r1["Modules_Order"] = r2["Modules_Order"].ToString().Trim();
                r1["Modules_Help"] = r2["Modules_Help"].ToString().Trim();
                r1["Modules_Icon"] = r2["Modules_Icon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsMenu"] = r2["IsMenu"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Slug"] = r2["Slug"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixModulesAdmin(table1, Convert.ToInt32(r1["Modules_ID"]), "");
            }
            return table1;
        }

        public void SubMixModulesAdmin(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_ID", mID);
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
                        rs["Modules_ID"] = subrow["Modules_ID"].ToString().Trim();
                        rs["Modules_Parent"] = subrow["Modules_Parent"].ToString().Trim();
                        rs["Modules_Name"] = sSpace + subrow["Modules_Name"].ToString().Trim();
                        rs["Modules_Dir"] = subrow["Modules_Dir"].ToString().Trim();
                        rs["Modules_Url"] = subrow["Modules_Url"].ToString().Trim();
                        rs["Modules_Order"] = subrow["Modules_Order"].ToString().Trim();
                        rs["Modules_Help"] = subrow["Modules_Help"].ToString().Trim();
                        rs["Modules_Icon"] = subrow["Modules_Icon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsMenu"] = subrow["IsMenu"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Slug"] = subrow["Slug"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixModulesAdmin(table, Convert.ToInt32(rs["Modules_ID"]), HttpUtility.HtmlDecode(""));
                    }
                }
            }
        }
        #endregion

        #region DeleteModules
        public void DeleteModules(int ID) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Modules_ID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Loi he thong");
            }
        }
        #endregion

        #region ModulesUpOrder
        public void ModulesUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ModulesID", cId);
                command.Parameters.AddWithValue("@ModulesOrder", cOrder);
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