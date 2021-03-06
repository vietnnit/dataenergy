using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using DAO;
using System.Text.RegularExpressions;

namespace BSO
{
    public class CateNewsBSO
    {
       
        public CateNewsBSO()
        {
            //constructor
        }

        #region CreateCateNews
        public void CreateCateNew(CateNews catenews)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            catenewsDAO.CreateCateNews(catenews);
        }
        #endregion

        #region CreateCateNewsGet
        public int CreateCateNewGet(CateNews catenews)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.CreateCateNewsGet(catenews);
        }
        #endregion

        #region UpdateCateNews
        public void UpdateCateNews(CateNews catenews)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            catenewsDAO.UpdateCateNews(catenews);
        }
        #endregion

        #region GetCateNews
        public DataTable GetCateNews(string lang)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNews(lang);
        }
        #endregion

        #region GetCateNewsById
        public CateNews GetCateNewsById(int cId)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsById(cId);
        }
        public string GetSlugByCateId(int cId)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetSlugByCateId(cId);
        }
        #endregion

        #region ExistName
        public bool ExistName(string catename)
        {
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return reader.HasRows;
                }
            }
        }
        #endregion

        //Client

        #region MenuNews
        public void MenuNews(Menu menu, int iParentID, string lang)
        {
            try 
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", iParentID);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", 1);
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
                        MenuItem menuitem = new MenuItem(row["CateNewsName"].ToString());
                        menuitem.NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString();
                        this.SubMenuNews(menuitem, Convert.ToInt32(row["CateNewsID"]), lang);
                        menu.Items.Add(menuitem);
                    }

                }
            }
            catch(Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
            

        }

        private void SubMenuNews(MenuItem _parentNote, int iCate_ID , string language)
        {
            try 
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", iCate_ID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", 1);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();

                    }
                }
                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        MenuItem _childNote = new MenuItem(row["CateNewsName"].ToString());
                        _childNote.NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString();
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuNews(_childNote, Convert.ToInt32(row["CateNewsID"]), language);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
            

        }
        #endregion


        #region MenuCompany
        public void MenuCompany(Menu menu, int iParentID , string lang)
        {
            try 
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", iParentID);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", 0);
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
                        MenuItem menuitem = new MenuItem(row["CateNewsName"].ToString());
                        menuitem.NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString();
                        this.SubMenuCompany(menuitem, Convert.ToInt32(row["CateNewsID"]), lang);
                        menu.Items.Add(menuitem);
                    }

                }
            }
            catch(Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
            
        }

        private void SubMenuCompany(MenuItem _parentNote, int iCate_ID, string language)
        {
            try 
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CateNewsID", iCate_ID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", 0);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();

                    }
                }
                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        MenuItem _childNote = new MenuItem(row["CateNewsName"].ToString());
                        _childNote.NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString();
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuCompany(_childNote, Convert.ToInt32(row["CateNewsID"]), language);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
            

        }
        #endregion
       

        //DeleteCateNews

        #region DeleteCateNewsAll
        public void DeleteCateNewsAll(int cateID, string lang)
        {

            try
            {
                DataTable table = GetCateNews(lang);
                for (int m = 0; m < table.Rows.Count;m++ )
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentNewsID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["CateNewsID"]);
                    if (cateID == pParent)
                        this.DeleteCateNewsAll(cCate, lang);
                }
          
                CateNewsDAO catenewsDAO = new CateNewsDAO();
                catenewsDAO.DeleteCateNews(cateID);
            }   
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
            
        }
        #endregion
        
        #region CateNewsUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void CateNewsUpOrder(int cId, int cOrder) 
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            catenewsDAO.CateNewsUpOrder(cId, cOrder);
        }
        #endregion

       
        #region CateNavigator
        /// <summary>
        /// Tao dieu huong cho danh muc
        /// Khi su dung can phai khai bao: string cate_navigator = "";
        /// url co dang: Default.aspx?go=catenews&id= ;
        /// </summary>
        /// <param name="cate_navigator"></param>
        /// <param name="cateId"></param>
        /// <param name="url"></param>
        
        public void CateNavigator(ref string cate_navigator, int cateId , string url) 
        {
            try
            {
                CateNews catenews = GetCateNewsById(cateId);
               
                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }
                    
                cate_navigator = "<a href='"+ url + cateId + "'>" + catenews.CateNewsName + "</a>" + cate_navigator;
                    
                if (catenews.ParentNewsID != 0)
                        this.CateNavigator(ref cate_navigator, catenews.ParentNewsID, url);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
           
        }
        #endregion

        
        //Cate Company

        #region getCateNewsLevel
        public DataTable getCateNewsLevel(int iCate, string lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
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

        #region GetCateNewsParentAll
        public DataTable GetCateNewsParentAll(int Id, string lang)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateNewsParentAll(Id, lang);
        }
        #endregion

        #region GetCateCompanyParentAll
        public DataTable GetCateCompanyParentAll(int Id, string lang)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateCompanyParentAll(Id, lang);
        }
        #endregion

        #region getCateCompanyClient
        public DataTable getCateCompanyClient(int iCate, string lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 0);
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


        #region getCateNewsClient
        public DataTable getCateNewsClient(int iCate, string lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        //Lay Cate theo nhom

        #region getCateClientGroup
        public DataTable getCateClientGroup(int iCate, string lang, int group)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        public DataTable getCateClientGroup(int iCate, string lang, int group, int n)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select top " + n + " * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate AND [IsUrl] = 0 order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        //Lay Cate theo nhom URL

        #region getCateClientGroupUrl
        public DataTable getCateClientGroupUrl(int iCate, string lang, int group)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClientUrl", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        public DataTable getCateClientGroupUrl(int iCate, string lang, int group, int n)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select top " + n + " * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        public DataTable getCateClientGroupUrl(int iCate, string lang, int group, int n, bool status)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select top " + n + " * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate and Status=@Status order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

            return table;
        }

        public DataTable getCateClientGroupUrl(int iCate, string lang, int group, bool status)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate and Status=@Status order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

            return table;
        }
        #endregion

        //Lay tat ca cate theo group

        #region GetCateParentGroupAll
        public DataTable GetCateParentGroupAll(int Id, string lang,int group)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateParentGroupAll(Id, lang, group);
        }
        #endregion

        //Theo user
        #region GetCateParentGroupRolesAll
        public DataTable GetCateParentGroupRolesAll(int Id, string lang, int group,string username)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateParentGroupRolesAll(Id, lang, group,username);
        }
        #endregion

        

        #region GetCateGroup
        public DataTable GetCateGroup(string lang, int group)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroup(lang, group);
        }
        #endregion
        #region GetCateGroupRoles
        public DataTable GetCateGroupRoles(string lang, int group,string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupRoles(lang, group, username);
        }

        #endregion

        #region GetCateGroupRoles
        public DataTable GetCateRoles(string lang, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateRoles(lang, username);
        }

        #endregion

        #region GetCateGroupRolesUrl
        public DataTable GetCateGroupRolesUrl(string lang, int group, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupRolesUrl(lang, group, username);
        }
        #endregion

        #region GetCateGroupRolesWithPage
        public DataTable GetCateGroupRolesWithPage(string lang, int group, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupRolesWithPage(lang, group, username);
        }
        #endregion

        #region GetCateGroupBullet
        public DataTable GetCateGroupBullet(string lang, int group,string bullet)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupBullet(lang, group, bullet);
        }
        #endregion


        #region GetCateNewsName
        public DataTable GetCateNewsName(string lang)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsName(lang);
        }

        public DataTable GetCateNewsName(string lang, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsName(lang, username);
        }

        public DataTable GetCateNewsNamePermission(string lang, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsNamePermission(lang, username);
        }
        #endregion

   
        #region MenuJqueryCateGroupUrl

        //url="~/Default.aspx?go=catenews&id="


        //public void MenuJqueryCateGroupUrl(Literal menu, int iCate, string lang, int group, string url, string css)
        //{
        //    DataTable table = getCateClientGroupUrl(iCate, lang, group);

        //    if (table.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in table.Rows)
        //        {
        //            Literal menuitem = new Literal(row["CateNewsName"].ToString());

        //            if (Convert.ToBoolean(row["IsUrl"].ToString()))
        //                menuitem.NavigateUrl = row["Url"].ToString();
        //            else
        //                menuitem.NavigateUrl = url + row["CateNewsID"].ToString();

        //            this.GetSubCategoryMenuJqueryCateGroupUrl(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
        //            menu.Items.Add(menuitem);
        //        }

        //    }

        //}

        //private void GetSubCategoryMenuJqueryCateGroupUrl(Literal _parentNote, int iCate_ID, string lang, string sSpace, int group, string url)
        //{
        //    string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
        //    sSpace = sSpace + str;

        //    DataTable datatable = getCateClientGroupUrl(iCate_ID, lang, group);
        //    if (datatable.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in datatable.Rows)
        //        {

        //            string Name = row["CateNewsName"].ToString();
        //            if (Name.Contains("-"))
        //            {
        //                Name = Name.Replace("&nbsp;", "");
        //                Name = Name.Replace("-", "");
        //                Name = "<b>" + Name + "</b>";
        //            }
        //            else
        //            {
        //                Name = sSpace + row["CateNewsName"].ToString();
        //            }
        //            Literal _childNote = new Literal(Name);

        //            if (Convert.ToBoolean(row["IsUrl"].ToString()))
        //                _childNote.NavigateUrl = row["Url"].ToString();
        //            else
        //                _childNote.NavigateUrl = url + row["CateNewsID"].ToString();

        //            //       _childNote.NavigateUrl = url + row["CateNewsID"].ToString();
        //            _parentNote.Items.Add(_childNote);
        //            this.GetSubCategoryMenuJqueryCateGroupUrl(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
        //        }
        //    }

        //}

        private bool CheckParent(int cate, int group, string Language)
        {

            bool check = false;
            try
            {
                DataTable datatable = getCateClientGroupUrl(cate, Language, group);
                if (datatable.Rows.Count > 0)
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
              // Response.Write(ex.Message + check);
            }
            return check;
        }

      //  Literal _parentNote, int iCate_ID, string lang, string sSpace, int group, string url
        public void MenuJqueryCateGroupUrl(StringBuilder menubar, int cateID, string lang, string sSpace, int group, string url)
        {

            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;

            DataTable datatable = getCateClientGroupUrl(cateID, lang, group);


            if (cateID == 0)
            {
                menubar.Append("<ul class='menu'>");
            }
            else
            {
                menubar.Append("<ul>");
            }

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    menubar.Append(" <li><a href='");



                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                        menubar.Append(row["Url"].ToString());
                    else
                        menubar.Append(url + row["CateNewsID"].ToString());





                    if (CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang) == true)
                    {

                        menubar.Append("' class='parent'><span>");
                    }
                    else
                    {
                        menubar.Append("'><span>");
                    }

                    string Name = row["CateNewsName"].ToString();

                    Name = sSpace + row["CateNewsName"].ToString();

                    menubar.Append(Name);
                    menubar.Append("</span></a>");

                    if (CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang) == true)
                    {

                        MenuJqueryCateGroupUrl(menubar, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", Convert.ToInt32(row["GroupCate"].ToString()), url);
                    }
                    menubar.Append("</li>");
                }
                menubar.Append("</ul>");
            }

        }

        public void MenuJqueryCateGroupUrl(StringBuilder menubar, int cateID, string lang, string sSpace, int group, string url1, string url2)
        {

            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;

            DataTable datatable = getCateClientGroupUrl(cateID, lang, group);


            if (cateID == 0)
            {
                menubar.Append("<ul class='menu'>");
            }
            else
            {
                menubar.Append("<ul>");
            }

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    menubar.Append(" <li><a href='");



                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                        menubar.Append(row["Url"].ToString());
                    else
                        menubar.Append(url1 + row["CateNewsID"].ToString() + "/" + Getstring(row["CateNewsName"].ToString()) + url2);





                    if (CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang) == true)
                    {

                        menubar.Append("' class='parent'><span>");
                    }
                    else
                    {
                        menubar.Append("'><span>");
                    }

                    string Name = row["CateNewsName"].ToString();

                    Name = sSpace + row["CateNewsName"].ToString();

                    menubar.Append(Name);
                    menubar.Append("</span></a>");

                    if (CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang) == true)
                    {

                        MenuJqueryCateGroupUrl(menubar, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", Convert.ToInt32(row["GroupCate"].ToString()), url1, url2);
                    }
                    menubar.Append("</li>");
                }
                menubar.Append("</ul>");
            }

        }
        #endregion

        #region Getstring
        private string Getstring(string _txt)
        {

            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = _txt.Normalize(NormalizationForm.FormD);
            return RemoveExtraSpaces(UCS2Convert(v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "-").Replace(":", "")));
        }

        private string RemoveExtraSpaces(string s)
        {
            if (!s.Contains("--")) return s;

            return RemoveExtraSpaces(s.Replace("--", "-"));
        }

        private static String UCS2Convert(String sContent)
        {
            sContent = sContent.Trim();
            String sUTF8Lower = "a|á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ|đ|e|é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ|i|í|ì|ỉ|ĩ|ị|o|ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ|u|ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự|y|ý|ỳ|ỷ|ỹ|ỵ";

            String sUTF8Upper = "A|Á|À|Ả|Ã|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|Â|Ấ|Ầ|Ẩ|Ẫ|Ậ|Đ|E|É|È|Ẻ|Ẽ|Ẹ|Ê|Ế|Ề|Ể|Ễ|Ệ|I|Í|Ì|Ỉ|Ĩ|Ị|O|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ|U|Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự|Y|Ý|Ỳ|Ỷ|Ỹ|Ỵ";

            String sUCS2Lower = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|d|e|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|i|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|u|y|y|y|y|y|y";

            String sUCS2Upper = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|D|E|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|I|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|U|Y|Y|Y|Y|Y|Y";

            String[] aUTF8Lower = sUTF8Lower.Split(new Char[] { '|' });

            String[] aUTF8Upper = sUTF8Upper.Split(new Char[] { '|' });

            String[] aUCS2Lower = sUCS2Lower.Split(new Char[] { '|' });

            String[] aUCS2Upper = sUCS2Upper.Split(new Char[] { '|' });

            Int32 nLimitChar;

            nLimitChar = aUTF8Lower.GetUpperBound(0);

            for (int i = 1; i <= nLimitChar; i++)
            {

                sContent = sContent.Replace(aUTF8Lower[i], aUCS2Lower[i]);

                sContent = sContent.Replace(aUTF8Upper[i], aUCS2Upper[i]);

            }
            string sUCS2regex = @"[A-Za-z0-9- ]";
            string sEscaped = new Regex(sUCS2regex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
            if (string.IsNullOrEmpty(sEscaped))
                return sContent;
            sEscaped = sEscaped.Replace("[", "\\[");
            sEscaped = sEscaped.Replace("]", "\\]");
            sEscaped = sEscaped.Replace("^", "\\^");
            string sEscapedregex = @"[" + sEscaped + "]";
            return new Regex(sEscapedregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
        }

        #endregion

        public DataTable GetCateNewsBystrId(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateNewsBystrId(restr);
        }
        public DataTable GetCateNewsBystrId(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateNewsBystrId(restr, num);
        }


        #region UpdateCateNewsGroupCate
        public void UpdateCateNewsGroupCatebyAll(int cateNewsId, int groupCate, string lang)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            catenewsDAO.UpdateCateNewsGroupCatebyAll(cateNewsId, groupCate, lang);
        }
        #endregion

        #region GetCateGroupStatus
        public DataTable GetCateGroupStatus(string lang, int group, bool status)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupStatus(lang, group, status);
        }
        #endregion
    }
}
