using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;

public partial class Client_Modules_MenuSearchTags : System.Web.UI.UserControl
{
    public string keyword;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["keyword"] != null)
        {
            keyword = Session["keyword"].ToString();
        }
        else
            keyword = "";

        int gId = 0;
        if (!String.IsNullOrEmpty(Request["gId"]))
            int.TryParse(Request["gId"], out gId);
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["cId"]))
            int.TryParse(Request["cId"], out cId);

        if (!IsPostBack)
        {
            GetMenuCateGroupAll(Language.language, gId, cId, keyword);
        }
    }

    private void GetMenuCateGroupAll(string lang, int gID, int cId, string keyword)
    {
        string strMenu = "";
        strMenu += BindMenuCateGroupAll("", lang, gID, cId, keyword);
        MenuNews.Text = strMenu;
    }

    private string BindMenuCateGroupAll(string strMenuSub, string lang, int gID, int cId, string keyword)
    {
        CateNewsGroupBSO catnewsgroupBSO = new CateNewsGroupBSO();
        DataTable table = catnewsgroupBSO.GetCateNewsGroupMenuAll(lang);
        //string strClass = "";

        if (table.Rows.Count > 0)
        {
            foreach (DataRow dataRow in table.Rows)
            {
                strMenuSub += "<div class='headline-v2 bg-color-light'><h2>";
                if (!Convert.ToBoolean(dataRow["isUrl"].ToString()))
                    if (!String.IsNullOrEmpty(keyword) && keyword.Trim() != "" && keyword.Trim() != "search")
                        strMenuSub += "<a href='" + ResolveUrl("~/") + "tim-kiem/" + dataRow["GroupCate"].ToString() + "/" + GetString(keyword) + ".aspx'>" + dataRow["CateNewsGroupName"].ToString() + "</a>";
                    else
                        strMenuSub += "<a href='" + ResolveUrl("~/") + "tim-kiem/" + dataRow["GroupCate"].ToString() + "/search.aspx'>" + dataRow["CateNewsGroupName"].ToString() + "</a>";

                strMenuSub += "</h2></div>";
                strMenuSub += BindMenuCateGroup("", 0, lang, Convert.ToInt32(dataRow["GroupCate"].ToString()), cId, keyword);
            }
            //strMenuSub += "</ul>";

        }

        return strMenuSub;

    }

    private string BindMenuCateGroup(string strMenuSub, int iCate, string lang, int group, int cId, string keyword)
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.getCateClientGroupUrl(iCate, lang, group, true);

        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        CateNewsGroup catenewsgroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(group, lang);
        if (catenewsgroup != null)
        {

            if (table.Rows.Count > 0)
            {
                strMenuSub += "<ul class='list-inline tags-v2 margin-bottom-20'>";
                foreach (DataRow dataRow in table.Rows)
                {
                    strMenuSub += "<li>";
                    if (!Convert.ToBoolean(dataRow["isUrl"].ToString()))
                        if (!String.IsNullOrEmpty(keyword) && keyword.Trim() != "" && keyword.Trim() != "search")
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "tim-kiem/" + dataRow["GroupCate"] + "/" + dataRow["CateNewsID"].ToString() + "/" + GetString(keyword) + ".aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";
                        else
                            strMenuSub += "<a href='" + ResolveUrl("~/") + "tim-kiem/" + dataRow["GroupCate"] + "/" + dataRow["CateNewsID"].ToString() + "/search.aspx'>" + dataRow["CateNewsName"].ToString() + "</a>";
                    strMenuSub += "</li>";
                    //strMenuSub += GetSubCategoryMenuCateGroup("", Convert.ToInt32(dataRow["CateNewsID"].ToString()), lang, group);
                }
                strMenuSub += "</ul>";

            }
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