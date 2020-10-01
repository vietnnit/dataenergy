using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ETO;
using BSO;
public partial class Client_Modules_Menu_MenuBarOE : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetMenuBarOE();
    }

    private void GetMenuBarOE()
    {
        if (AspNetCache.CheckCache("HTML_ltlMenuBarOE_11") == false)
        {
            CateNewsGroupBSO _catenewsgroupBSO = new CateNewsGroupBSO();
            CateNewsBSO _catenewsBSO = new CateNewsBSO();
            NewsGroupBSO _newsgroupBSO = new NewsGroupBSO();
            DataTable table_news = new DataTable();
            DataTable table_cate = new DataTable();
            DataTable table_cate_sub = new DataTable();
            DataTable table_cate_group = new DataTable();
            DataTable tableClone1 = table_cate_group.Clone();
            DataTable tableClone2 = table_cate_group.Clone();

            string strMenu = "";
            //           string strMenuSub = "";
            string strMenuSubCate = "";
            string strMenuItem = "";

            strMenu += "<ul class='nav navbar-nav'>";
            strMenu += "<li class='dropdown mega-menu-fullwidth'>";
            strMenu += "<a href='" + ResolveUrl("~/") + "Default.aspx' class='dropdown-toggle' data-toggle='dropdown'>";
            strMenu += "<span class='fa fa-home' style='font-size:20px;'></span>";
            strMenu += "</a>";

            // <!-- 0 -->;

            strMenu += "<ul class='dropdown-menu'>";
            strMenu += "<li>";
            strMenu += "<div class='mega-menu-content disable-icons'>";
            strMenu += "<div class='container'>";
            strMenu += "<div class='row equal-height'>";

            table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 2, 4, true);

            //Start Left (1)
            if (table_cate.Rows.Count > 0)
            {
                strMenuSubCate = "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";

                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 2, 7, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //EndLeft (1)

            //Start Mid1 (2)
            if (table_cate.Rows.Count > 1)
            {
                strMenuSubCate = "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</h3></li>";
                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 2, 7, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //End Mid1 (2)

            //Start Mid2 (3)
            if (table_cate.Rows.Count > 2)
            {
                strMenuSubCate = "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[2]["CateNewsName"].ToString() + "</h3></li>";
                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[2]["CateNewsID"].ToString()), Language.language, 2, 7, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //End Mid2 (3)

            //Start Right (4)
            if (table_cate.Rows.Count > 3)
            {
                strMenuSubCate = "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[3]["CateNewsName"].ToString() + "</h3></li>";
                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[3]["CateNewsID"].ToString()), Language.language, 2, 7, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //End Right (4)

            strMenu += "</div>";
            strMenu += "</div>";
            strMenu += "</div>";
            strMenu += "</li>";
            strMenu += "</ul>";
            strMenu += "</li>";


            //Menu 2 - Tuyen sinh DH-CD
            //strMenu += "<li><a href='#'>Tuyển sinh ĐH-CĐ</a>";
            strMenu += "<li class='dropdown mega-menu-fullwidth'>";
            strMenu += "<a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Tuyển sinh ĐH-CĐ") + "-5.aspx' class='dropdown-toggle' data-toggle='dropdown'>";
            strMenu += "Tuyển sinh ĐH-CĐ";
            strMenu += "</a>";

            strMenu += "<ul class='dropdown-menu'>";
            strMenu += "<li>";
            strMenu += "<div class='mega-menu-content disable-icons'>";
            strMenu += "<div class='container'>";
            strMenu += "<div class='row equal-height'>";

            table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 5, 3, true);

            //Start Left (1)
            if (table_cate.Rows.Count > 0)
            {
                strMenuSubCate = "<div class='col-md-4 col-lg-4 col-sm-4 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[0]["CateNewsName"].ToString() + "</h3></li>";

               
                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 5, 12, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //EndLeft (1)

            //Start Mid 1 (2)
            if (table_cate.Rows.Count > 1)
            {
                strMenuSubCate = "<div class='col-md-4 col-lg-4 col-sm-4 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</h3></li>";

                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 5, 12, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //End Mid 1 (2)

            //Start Mid 2 (3)
            if (table_cate.Rows.Count > 2)
            {
                strMenuSubCate = "<div class='col-md-4 col-lg-4 col-sm-4 col-xs-12 equal-height-in'>";
                strMenuSubCate += "<ul class='list-unstyled equal-height-list'>";
                strMenuSubCate += "<li><h3>" + table_cate.Rows[2]["CateNewsName"].ToString() + "</h3></li>";

                table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[2]["CateNewsID"].ToString()), Language.language, 5, 8, true);

                if (table_cate_sub.Rows.Count > 0)
                {
                    for (int i = 0; i < table_cate_sub.Rows.Count; i++)
                    {
                        DataRow dataRow = table_cate_sub.Rows[i];

                        strMenuSubCate += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'><i class='fa fa-list'></i>" + dataRow["CateNewsName"].ToString() + "</a>";

                        strMenuSubCate += "</li>";

                    }
                }
                //strMenuSubCate += "<a class='bt_menubar_1' href='#'><span>Đăng ký tuyển sinh trực tuyến</span></a>";
                strMenuSubCate += "</ul>";
                strMenuSubCate += "</div>";

                strMenu += strMenuSubCate;
            }

            //End Mid 2 (3)

            strMenu += "</div>";
            strMenu += "</div>";
            strMenu += "</div>";
            strMenu += "</li>";
            strMenu += "</ul>";
            strMenu += "</li>";

            //End Menu 2

            ////Menu 3 - Tuyen sinh THPT
            //int groupcate1 = 6;
            //strMenu += "    <li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Tuyển sinh THPT") + "-" + groupcate1 + ".aspx'>Tuyển sinh THPT</a>";
            //strMenu += "    <div style='left: -196px;'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 6, 2, true);

            ////Start Left (1)
            //if (table_cate.Rows.Count > 0)
            //{
            //    strMenuSubCate = "<ul class='oe_subleftmenu'>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 6, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndLeft (1)

            ////Content

            ////Start Content
            //table_news = _newsgroupBSO.GetNewsGroupHot(Language.language, 4, "1", 6);
            //strMenuItem = "<ul class='oe_menucontent-mid'>";
            //strMenuItem += "<span class='heading_icon'> Thông báo tuyển sinh THPT</span>";
            //if (table_news.Rows.Count > 0)
            //{
            //    strMenuItem += "<li class='menu_content-mid'>";
            //    strMenuItem += "<ul class='oe_subleftmenu2'>";
            //    for (int i = 0; i < table_news.Rows.Count; i++)
            //    {
            //        DataRow dataRow = table_news.Rows[i];

            //        strMenuItem += "<li>";
            //        strMenuItem += "<a href='" + ResolveUrl("~/") + "ts/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx'>";

            //        if (dataRow["ImageThumb"].ToString() != "")
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + dataRow["ImageThumb"].ToString(),80) + "' vspace='1' class='img_news_menu'>";
            //        else
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 80) + "' vspace='1' class='img_news_menu'>";


            //        strMenuItem += dataRow["Title"].ToString();

            //        DateTime dtNow;
            //        dtNow = DateTime.Now;
            //        if (Convert.ToDateTime(dataRow["PostDate"].ToString()).Date >= dtNow.Date)
            //            strMenuItem += "<img src='" + ResolveUrl("~/") + "images/red-star.gif' class='icon12' />";

            //        strMenuItem += "<br style='clear: both;' />";
            //        strMenuItem += "</a></li>";

            //        if ((i + 1) % 2 == 0)
            //        {
            //            strMenuItem += "</ul>";
            //            strMenuItem += "</li>";
            //            strMenuItem += "<li class='menu_content'>";
            //            strMenuItem += "<ul class='oe_subleftmenu2'>";
            //        }

            //    }
            //    strMenuItem += "</ul>";
            //    strMenuItem += "</li>";
            //}
            //strMenuItem += "</ul>";

            //strMenu += strMenuItem;

            ////end content

            ////Start Right
            //if (table_cate.Rows.Count > 1)
            //{
            //    strMenuSubCate = "<ul class='oe_subrightmenu_1'>";
            //    strMenuSubCate += "<li class='heading_bold'>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</li>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 6, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndRight

            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End Menu3

            ////Menu 4 - Tu van ho tro
            ////strMenu += "<li><a href=''>Tư vấn hỗ trợ</a>";
            //strMenu += "<li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Tư vấn Hỗ trợ") + "-7.aspx'> Tư vấn Hỗ trợ</a>";
            //strMenu += "<div style='left: -329px;'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 7, 4, true);

            ////Start Left (1)
            //if (table_cate.Rows.Count > 0)
            //{
            //    strMenuSubCate = "<ul class='oe_subleftmenu'>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 7, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndLeft (1)

            ////Start Mid 1 (2)
            //if (table_cate.Rows.Count > 1)
            //{
            //    strMenuSubCate = "<ul class='oe_menucontent_mid_1'>";
            //    strMenuSubCate += "<span class='heading_icon'>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</span>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 7, 4, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "<a class='bt_menubar_1' href='#'><span>Tra điểm ĐH-CĐ</span></a>";
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////End Mid 1 (2)

            ////Start Mid 2 (3)
            //if (table_cate.Rows.Count > 2)
            //{
            //    strMenuSubCate = "<ul class='oe_menucontent_mid_2'>";
            //    strMenuSubCate += "<span class='heading_icon'>" + table_cate.Rows[2]["CateNewsName"].ToString() + "</span>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[2]["CateNewsID"].ToString()), Language.language, 7, 12, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";
            //    strMenu += strMenuSubCate;
            //}

            ////End Mid 2 (3)

            ////Start Mid 3 (4)
            //if (table_cate.Rows.Count > 3)
            //{
            //    strMenuSubCate = "<ul class='oe_subrightmenu_1'>";
            //    strMenuSubCate += "<li class='heading_bold'>" + table_cate.Rows[3]["CateNewsName"].ToString() + "</li>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[3]["CateNewsID"].ToString()), Language.language, 7, 5, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "<a class='bt_menubar_1' href='#'><span>Đăng ký trực tuyến</span></a>";
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////End Mid 3 (4)



            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End menu 5
            ////Menu 5 - On thi Dai hoc

            //strMenu += "<li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Ôn thi Đại học") + "-8.aspx'>Ôn thi Đại học</a>";
            //strMenu += "<div style='left: -451px;'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 8, 3, true);

            ////Start Left (1)
            //if (table_cate.Rows.Count > 0)
            //{
            //    strMenuSubCate = "<ul class='oe_subleftmenu_1'>";
            //    strMenuSubCate += "<span class='heading_icon'>" + table_cate.Rows[0]["CateNewsName"].ToString() + "</span>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 8, 12, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndLeft (1)

            ////Start Mid 1 (2)
            //if (table_cate.Rows.Count > 1)
            //{
            //    strMenuSubCate = "<ul class='oe_menucontent_mid_22'>";
            //    strMenuSubCate += "<span class='heading_icon'>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</span>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 8, 12, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////End Mid 1 (2)

            ////Start Mid 2 (3)
            //if (table_cate.Rows.Count > 2)
            //{
            //    strMenuSubCate = "<ul class='oe_menucontent_mid_2_noline'>";
            //    strMenuSubCate += "<span class='heading_icon'>" + table_cate.Rows[2]["CateNewsName"].ToString() + "</span>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[2]["CateNewsID"].ToString()), Language.language, 8, 8, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "<a class='bt_menubar_1' href='#'><span>Đăng ký học trực tuyến</span></a>";
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////End Mid 2 (3)

            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End Menu 5

            ////Menu 6 - Du học

            //strMenu += "<li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Du học") + "-9.aspx'>Du học</a>";
            //strMenu += "<div style='left: -574px;'>";
            ////Start Left
            //strMenuSubCate = "<ul class='oe_subleftmenu'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 9, 7);
            //if (table_cate.Rows.Count > 0)
            //{
            //    for (int i = 0; i < table_cate.Rows.Count; i++)
            //    {
            //        DataRow dataRow = table_cate.Rows[i];

            //        strMenuSubCate += "<li>";
            //        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //            strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //        else
            //            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //        strMenuSubCate += "</li>";

            //    }
            //}
            //strMenuSubCate += "</ul>";

            //strMenu += strMenuSubCate;

            ////EndLeft
            ////Start Content
            //table_news = _newsgroupBSO.GetNewsGroupHot(Language.language, 6, "1", 9);
            //strMenuItem = "<ul class='oe_menucontent'>";

            //if (table_news.Rows.Count > 0)
            //{
            //    strMenuItem += "<li class='menu_content'>";
            //    strMenuItem += "<ul class='oe_subleftmenu2'>";
            //    for (int i = 0; i < table_news.Rows.Count; i++)
            //    {
            //        DataRow dataRow = table_news.Rows[i];

            //        strMenuItem += "<li>";
            //        strMenuItem += "<a href='" + ResolveUrl("~/") + "ts/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx'>";

            //        if (dataRow["ImageThumb"].ToString() != "")
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + dataRow["ImageThumb"].ToString(),80) + "' vspace='1' class='img_news_menu'>";
            //        else
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 80) + "' vspace='1' class='img_news_menu'>";


            //        strMenuItem += dataRow["Title"].ToString();

            //        DateTime dtNow;
            //        dtNow = DateTime.Now;
            //        if (Convert.ToDateTime(dataRow["PostDate"].ToString()).Date >= dtNow.Date)
            //            strMenuItem += "<img src='" + ResolveUrl("~/") + "images/red-star.gif' class='icon12' />";

            //        strMenuItem += "<br style='clear: both;' />";
            //        strMenuItem += "</a></li>";

            //        if ((i + 1) % 2 == 0)
            //        {
            //            strMenuItem += "</ul>";
            //            strMenuItem += "</li>";
            //            strMenuItem += "<li class='menu_content'>";
            //            strMenuItem += "<ul class='oe_subleftmenu2'>";
            //        }

            //    }
            //    strMenuItem += "</ul>";
            //    strMenuItem += "</li>";
            //}
            //strMenuItem += "</ul>";

            //strMenu += strMenuItem;
            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End Menu 6

            ////Menu 8 - Ban Tin giao duc

            //strMenu += "    <li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Bản tin giáo dục") + "-1.aspx'>Bản tin giáo dục</a>";
            //strMenu += "    <div style='left: -650px;'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 1, 2, true);

            ////Start Left (1)
            //if (table_cate.Rows.Count > 0)
            //{
            //    strMenuSubCate = "<ul class='oe_subleftmenu'>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 1, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndLeft (1)

            ////Content

            ////Start Content
            //table_news = _newsgroupBSO.GetNewsGroupHot(Language.language, 4, "1", 1);
            //strMenuItem = "<ul class='oe_menucontent-mid'>";
            //strMenuItem += "<span class='heading_icon'>Tin nổi bật</span>";
            //if (table_news.Rows.Count > 0)
            //{
            //    strMenuItem += "<li class='menu_content-mid'>";
            //    strMenuItem += "<ul class='oe_subleftmenu2'>";
            //    for (int i = 0; i < table_news.Rows.Count; i++)
            //    {
            //        DataRow dataRow = table_news.Rows[i];

            //        strMenuItem += "<li>";
            //        strMenuItem += "<a href='" + ResolveUrl("~/") + "ts/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx'>";

            //        if (dataRow["ImageThumb"].ToString() != "")
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + dataRow["ImageThumb"].ToString(),80) + "' vspace='1' class='img_news_menu'>";
            //        else
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 80) + "' vspace='1' class='img_news_menu'>";


            //        strMenuItem += dataRow["Title"].ToString();

            //        DateTime dtNow;
            //        dtNow = DateTime.Now;
            //        if (Convert.ToDateTime(dataRow["PostDate"].ToString()).Date >= dtNow.Date)
            //            strMenuItem += "<img src='" + ResolveUrl("~/") + "images/red-star.gif' class='icon12' />";

            //        strMenuItem += "<br style='clear: both;' />";
            //        strMenuItem += "</a></li>";

            //        if ((i + 1) % 2 == 0)
            //        {
            //            strMenuItem += "</ul>";
            //            strMenuItem += "</li>";
            //            strMenuItem += "<li class='menu_content'>";
            //            strMenuItem += "<ul class='oe_subleftmenu2'>";
            //        }

            //    }
            //    strMenuItem += "</ul>";
            //    strMenuItem += "</li>";
            //}
            //strMenuItem += "</ul>";

            //strMenu += strMenuItem;

            ////end content

            ////Start Right
            //if (table_cate.Rows.Count > 1)
            //{
            //    strMenuSubCate = "<ul class='oe_subrightmenu_1'>";
            //    strMenuSubCate += "<li class='heading_bold'>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</li>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 1, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndRight

            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End Menu 8

            ////Menu 9 - Huong nghiep, viec lam

            //strMenu += "<li><a href='" + ResolveUrl("~/") + "ts-f/" + GetString("Hướng nghiệp, Việc làm") + "-10.aspx'>Hướng nghiệp, Việc làm</a>";
            //strMenu += "<div style='left: -789px;'>";

            //table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, 10, 2, true);

            ////Start Left (1)
            //if (table_cate.Rows.Count > 0)
            //{
            //    strMenuSubCate = "<ul class='oe_subleftmenu'>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[0]["CateNewsID"].ToString()), Language.language, 10, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndLeft (1)

            ////Content

            ////Start Content
            //table_news = _newsgroupBSO.GetNewsGroupHot(Language.language, 4, "1", 7);
            //strMenuItem = "<ul class='oe_menucontent-mid'>";
            //strMenuItem += "<span class='heading_icon'>Tin nổi bật</span>";
            //if (table_news.Rows.Count > 0)
            //{
            //    strMenuItem += "<li class='menu_content-mid'>";
            //    strMenuItem += "<ul class='oe_subleftmenu2'>";
            //    for (int i = 0; i < table_news.Rows.Count; i++)
            //    {
            //        DataRow dataRow = table_news.Rows[i];

            //        strMenuItem += "<li>";
            //        strMenuItem += "<a href='" + ResolveUrl("~/") + "ts/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx'>";

            //        if (dataRow["ImageThumb"].ToString() != "")
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + dataRow["ImageThumb"].ToString(),80) + "' vspace='1' class='img_news_menu'>";
            //        else
            //            strMenuItem += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 80) + "' vspace='1' class='img_news_menu'>";


            //        strMenuItem += dataRow["Title"].ToString();

            //        DateTime dtNow;
            //        dtNow = DateTime.Now;
            //        if (Convert.ToDateTime(dataRow["PostDate"].ToString()).Date >= dtNow.Date)
            //            strMenuItem += "<img src='" + ResolveUrl("~/") + "images/red-star.gif' class='icon12' />";

            //        strMenuItem += "<br style='clear: both;' />";
            //        strMenuItem += "</a></li>";

            //        if ((i + 1) % 2 == 0)
            //        {
            //            strMenuItem += "</ul>";
            //            strMenuItem += "</li>";
            //            strMenuItem += "<li class='menu_content'>";
            //            strMenuItem += "<ul class='oe_subleftmenu2'>";
            //        }

            //    }
            //    strMenuItem += "</ul>";
            //    strMenuItem += "</li>";
            //}
            //strMenuItem += "</ul>";

            //strMenu += strMenuItem;

            ////end content

            ////Start Right
            //if (table_cate.Rows.Count > 1)
            //{
            //    strMenuSubCate = "<ul class='oe_subrightmenu_1'>";
            //    strMenuSubCate += "<li class='heading_bold'>" + table_cate.Rows[1]["CateNewsName"].ToString() + "</li>";
            //    table_cate_sub = _catenewsBSO.getCateClientGroupUrl(Convert.ToInt32(table_cate.Rows[1]["CateNewsID"].ToString()), Language.language, 10, 7, true);

            //    if (table_cate_sub.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < table_cate_sub.Rows.Count; i++)
            //        {
            //            DataRow dataRow = table_cate_sub.Rows[i];

            //            strMenuSubCate += "<li>";
            //            if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
            //                strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
            //            else
            //                strMenuSubCate += "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

            //            strMenuSubCate += "</li>";

            //        }
            //    }
            //    strMenuSubCate += "</ul>";

            //    strMenu += strMenuSubCate;
            //}

            ////EndRight

            //strMenu += "</div>";
            //strMenu += "</li>";

            ////End Menu 9

            strMenu += "</ul>";


            AspNetCache.SetCacheWithTime("HTML_ltlMenuBarOE_11", strMenu, 150);
            ltlMenuBarOE.Text = strMenu;

        }
        else
        {
            ltlMenuBarOE.Text = (string)AspNetCache.GetCache("HTML_ltlMenuBarOE_11");
        }


    }

    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }
}
