using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;
public partial class Client_Admin_Control_Menu_MenuBarMulti : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int gId = 0;
        if (!String.IsNullOrEmpty(Request["g"]))
            if (!int.TryParse(Request["g"], out gId))
                Response.Redirect("~/Default.aspx");
        if (!IsPostBack)
        {

            GetMenuCateGroupAll(Language.language, gId);
        }
    }

    private void GetMenuCateGroupAll(string lang, int gID)
    {

        string strMenu = "";
        if (AspNetCache.CheckCache("HTML_MenuBar_All_" + gID + "_" + Language.language.Replace("-", "_")) == false)
        {
            strMenu += BindMenuCateGroupAll("", lang, gID);
            AspNetCache.SetCacheWithTime("HTML_MenuBar_All_" + gID + "_" + Language.language.Replace("-", "_"), strMenu, 150);
            MenuNews.Text = strMenu;
        }
        else
        {
            MenuNews.Text = (string)AspNetCache.GetCache("HTML_MenuBar_All_" + gID + "_" + Language.language.Replace("-", "_"));
        }


    }

    private string BindMenuCateGroupAll(string strMenuSub, string lang, int gID)
    {
        CateNewsGroupBSO catnewsgroupBSO = new CateNewsGroupBSO();
        DataTable table = catnewsgroupBSO.GetCateNewsGroupMenuAll(lang);
        string strClass = "";

        if (table.Rows.Count > 0)
        {
            strMenuSub += "<ul>";
            //if (gID==0)
            //{
            //    strClass = "<li class='selected'>";
            //}
            //else
            //    strClass = "<li>";

            //strMenuSub += strClass;
            //strMenuSub += "<a href='" + ResolveUrl("~/") + "' title='" + Resources.resource.T_home + "'>" + Resources.resource.T_home + "</a>";
            //strMenuSub += "</a>";
            //strMenuSub += "</li>";

            foreach (DataRow dataRow in table.Rows)
            {
                if (Convert.ToInt32(dataRow["GroupCate"].ToString()) == gID)
                {
                    strClass = "class='selected'";
                }
                else
                    strClass = "";

                strMenuSub += "<li " + strClass + ">";
                if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                    strMenuSub += "<a href='" + dataRow["Url"].ToString() + "' " + strClass + " >" + dataRow["CateNewsGroupName"].ToString() + "</a>";
                //else if (Convert.ToBoolean(dataRow["IsPage"].ToString()))
                //    strMenuSub += "<a href='" + ResolveUrl("~/") + "tin-tuc-fp/" + GetString(dataRow["CateNewsGroupName"]) + "-" + dataRow["GroupCate"] + ".aspx' "+strClass+" >" + dataRow["CateNewsGroupName"].ToString() + "</a>";
                else
                    strMenuSub += "<a href='" + ResolveUrl("~/") + "c2/" + catnewsgroupBSO.GetSlugById(Convert.ToInt32(dataRow["CateNewsGroupID"])) + "/" + GetString(dataRow["CateNewsGroupName"]) + "-" + dataRow["GroupCate"] + ".aspx' " + strClass + " >" + dataRow["CateNewsGroupName"].ToString() + "</a>";

                strMenuSub += BindMenuCateGroup("", 0, lang, Convert.ToInt32(dataRow["GroupCate"].ToString()));

                strMenuSub += "</li>";
            }
            strMenuSub += "</ul>";

        }

        return strMenuSub;

    }

    private string BindMenuCateGroup(string strMenuSub, int iCate, string lang, int group)
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.getCateClientGroupUrl(iCate, lang, group, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(group, lang);
        if (catenewsgroup != null)
        {

            if (table.Rows.Count > 0)
            {
                strMenuSub += "<ul>";
                foreach (DataRow dataRow in table.Rows)
                {
                    strMenuSub += "<li>";
                    if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                        strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
                    //else if (catenewsgroup.IsPage)
                    //    strMenuSub += "<a href='" + ResolveUrl("~/") + "tin-tuc-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";
                    else
                        strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

                    strMenuSub += GetSubCategoryMenuCateGroup("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), lang, group);

                    strMenuSub += "</li>";
                }
                strMenuSub += "</ul>";

            }
        }
        return strMenuSub;

    }

    private string GetSubCategoryMenuCateGroup(string strMenuSub, int iCate, string lang, int group)
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable datatable = catenewsBSO.getCateClientGroupUrl(iCate, lang, group, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(group, lang);

        if (datatable.Rows.Count > 0)
        {
            strMenuSub += "<ul>";
            foreach (DataRow dataRow in datatable.Rows)
            {
                strMenuSub += "<li>";
                if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                    strMenuSub += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["CateNewsName"].ToString() + "</a>";
                //else if (catenewsgroup.IsPage)
                //    strMenuSub += "<a href='" + ResolveUrl("~/") + "tin-tuc-dmp/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";
                else
                    strMenuSub += "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"].ToString())) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";

                strMenuSub += GetSubCategoryMenuCateGroup("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), lang, group);

                strMenuSub += "</li>";
            }
            strMenuSub += "</ul>";

        }
        return strMenuSub;

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