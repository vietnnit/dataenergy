using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;
public partial class Control_MenuVer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["cid"]))
            int.TryParse(Request["cid"], out cId);
        int gId = 0;
        if (!String.IsNullOrEmpty(Request["g"]))
            int.TryParse(Request["g"], out gId);
        int nId = 0;
        if (!String.IsNullOrEmpty(Request["id"]))
            int.TryParse(Request["id"], out nId);

        if (!IsPostBack)
        {
            if (gId == 0)
            {
                panel_menutree.Visible = false;
            }
            else
            {
                panel_menutree.Visible = true;

                if (cId == 0 && nId != 0)
                {
                    NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
                    NewsGroup _newsgroup = newsGroupBSO.GetNewsGroupById(nId);
                    if (_newsgroup != null)
                        cId = _newsgroup.CateNewsID;
                }


                string strMenu = "";
                if (AspNetCache.CheckCache("HTML_MenuVer_" + gId + "_" + cId) == false)
                {
                    strMenu += BindMenuVer("", gId, cId);
                    AspNetCache.SetCacheWithTime("HTML_MenuVer_" + gId + "_" + cId, strMenu, 150);
                    MenuNews.Text = strMenu;

                }
                else
                {
                    MenuNews.Text = (string)AspNetCache.GetCache("HTML_MenuVer_" + gId + "_" + cId);
                }
            }
        }

    }

    private string BindMenuVer(string strMenuSub, int groupcate, int cID)
    {


        DataTable table = new DataTable();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        table = catenewsBSO.getCateClientGroupUrl(cID, Language.language, groupcate, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate, Language.language);


        if (catenewsgroup != null)
        {
            if (table.Rows.Count > 0)
            {
               // int level = 1;
                strMenuSub += "<ul class='nav nav-stacke'>";
                foreach (DataRow dataRow in table.Rows)
                {
                   // strMenuSub += "<li>";
                    //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                    if (checkActive(cID, Convert.ToInt32(dataRow["CateNewsID"].ToString())))
                    {
                        strMenuSub += "<li class='active'>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["ShortName"].ToString() + "</a>";
                        else
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["ShortName"].ToString() + "</a>";

                        strMenuSub += "</li>";
                      
                    }
                    else
                    {
                        strMenuSub += "<li>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["ShortName"].ToString() + "</a>";
                        else
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["ShortName"].ToString() + "</a>";


                        //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                        strMenuSub += "</li>";
                      
                    }

                  //  strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), groupcate, cID, level + 1);

                    //strMenuSub += "</div>";
                    //strMenuSub += "</li>";
                }

                strMenuSub += "</ul>";
            }



        }
        return strMenuSub;

    }

    private string BindMenu(string strMenuSub, int groupcate, int cID)
    {


        DataTable table = new DataTable();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        table = catenewsBSO.getCateClientGroupUrl(0, Language.language, groupcate, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate, Language.language);


        if (catenewsgroup != null)
        {
            if (table.Rows.Count > 0)
            {
                int level = 1;
                strMenuSub += "<ul>";
                foreach (DataRow dataRow in table.Rows)
                {
                    strMenuSub += "<li>";
                    //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                    if (checkActive(cID, Convert.ToInt32(dataRow["CateNewsID"].ToString())))
                    {
                        strMenuSub += "<span class='closed opened'>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["ShortName"].ToString() + "</a>";
                        else
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["ShortName"].ToString() + "</a>";

                        strMenuSub += "</span>";
                        strMenuSub += "<div style='display: block;'>";
                    }
                    else
                    {
                        strMenuSub += "<span class='closed'>";
                        if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                            strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["ShortName"].ToString() + "</a>";
                        else
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["ShortName"].ToString() + "</a>";


                        //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                        strMenuSub += "</span>";
                        strMenuSub += "<div style='display: none;'>";
                    }

                    strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), groupcate, cID, level + 1);

                    strMenuSub += "</div>";
                    strMenuSub += "</li>";
                }

                strMenuSub += "</ul>";
            }



        }
        return strMenuSub;

    }

    private string GetSubMenu(string strMenuSub, int iCate, int groupcate, int cID, int level)
    {
        DataTable datatable = new DataTable();
        //if (AdminName.Equals("administrator"))
        //{
        //    SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
        //    datatable = common.CreateDataView(SQL);
        //}
        //else
        //{
        //    SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " And Modules_Url in ('" + strModules + "') Order by [Modules_Order] ASC";
        //    datatable = common.CreateDataView(SQL);
        //}

        CateNewsBSO catenewsBSO = new CateNewsBSO();
        datatable = catenewsBSO.getCateClientGroupUrl(iCate, Language.language, groupcate, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate, Language.language);


        if (datatable.Rows.Count > 0)
        {
            if (level == 4)
                strMenuSub += "<ul class='parent_4_ul'>";
            else
                strMenuSub += "<ul>";
            foreach (DataRow dataRow in datatable.Rows)
            {
                strMenuSub += "<li>";

                if (checkActive(cID, Convert.ToInt32(dataRow["CateNewsID"].ToString())))
                {
                    strMenuSub += "<span class='closed opened parent_" + level + "'>";
                    if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                        strMenuSub += "<a href='" + dataRow["Url"].ToString() + "' " + ((level < 3) ? "class='parent'" : "class='f_normal selected'") + ">" + dataRow["ShortName"].ToString() + "</a>";
                    else
                        strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx' " + ((level < 3) ? "class='parent'" : "class='f_normal selected'") + ">" + dataRow["ShortName"].ToString() + "</a>";
                    strMenuSub += "</span>";

                    strMenuSub += "<div style='display: block;'>";
                }
                else
                {
                    strMenuSub += "<span class='closed parent_" + level + "'>";
                    if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                        strMenuSub += "<a href='" + dataRow["Url"].ToString() + "' " + ((level < 3) ? "class='parent'" : "class='f_normal'") + ">" + dataRow["ShortName"].ToString() + "</a>";
                    else
                        strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx' " + ((level < 3) ? "class='parent'" : "class='f_normal'") + ">" + dataRow["ShortName"].ToString() + "</a>";
                    strMenuSub += "</span>";
                    strMenuSub += "<div style='display: none;'>";
                }

                //strMenuSub += "<span class='closed'></span>";
                //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";
                //strMenuSub += "<div style='display: none;'>";

                strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), groupcate, cID, level + 1);

                strMenuSub += "</div>";
                strMenuSub += "</li>";
            }
            strMenuSub += "</ul>";

        }
        return strMenuSub;

    }

    private bool checkActive(int cateID, int sCateID)
    {
        /*
         * Kiểm tra sCateID có thuộc cùng nhóm chuyên mục với cateID ko?
         * cateID: ID chuyên mục hiện hành
         * sCateID: ID của list chuyên mục tại
         */
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        CateNews cateNews = new CateNews();

        cateNews = catenewsBSO.GetCateNewsById(cateID);

        if (cateNews != null)
        {
            if (cateID == sCateID)
                return true;
            else
                while (cateNews.ParentNewsID != 0 && cateNews.CateNewsID != sCateID)
                {
                    cateNews = catenewsBSO.GetCateNewsById(cateNews.ParentNewsID);
                    if (cateNews.CateNewsID == sCateID)
                        return true;
                }
        }
        return false;
    }

    private bool checkActive(string dll, int id_url)
    {
        ModulesBSO moduleBSO = new ModulesBSO();
        Modules _module = new Modules();

        _module = moduleBSO.GetModulesByUrl(dll);

        if (_module.ModulesParent == id_url)
            return true;
        else
            while (_module.ModulesParent != 0 && _module.ModulesParent != id_url)
            {
                _module = moduleBSO.GetModulesById(_module.ModulesParent);
                if (_module.ModulesParent == id_url)
                    return true;
            }

        return false;
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