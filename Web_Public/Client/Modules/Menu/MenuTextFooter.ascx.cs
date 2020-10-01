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

public partial class Client_Modules_Menu_MenuTextFooter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewMenu();
          
        }
    }

    protected void viewMenu()
    {

        if (AspNetCache.CheckCache("HTML_ltlMenuTextLinkFooter_11" + "_" + Language.language.Replace("-", "_")) == false)
        {
            string strMenuSubCate = "";
            CateNewsGroupBSO _catenewsgroupBSO = new CateNewsGroupBSO();
            CateNewsBSO _catenewsBSO = new CateNewsBSO();

            DataTable table_cate_group = _catenewsgroupBSO.GetCateNewsGroupHomeAll(Language.language);
            if (table_cate_group.Rows.Count > 0)
            {
                //int col = 0;
                strMenuSubCate += "<ul class='list-unstyled link-list'>";
                for (int i = 0; i < table_cate_group.Rows.Count; i++)
                {
                    DataRow dataRow = table_cate_group.Rows[i];
                    //col++;

                   
                    strMenuSubCate += "<li>";
                    if (Convert.ToBoolean(dataRow["isUrl"].ToString()))
                        strMenuSubCate += "<a href='" + dataRow["Url"].ToString() + "'>" + dataRow["ShortName"].ToString() + "</a>";
                    else
                        strMenuSubCate += "<a href='" + ResolveUrl("~/") + "c2/"+_catenewsgroupBSO.GetSlugById(Convert.ToInt32(dataRow["CateNewsGroupID"])) + "/" + GetString(dataRow["CateNewsGroupName"]) + "-" + dataRow["GroupCate"] + ".aspx'>" + dataRow["ShortName"].ToString() + "</a><i class='fa fa-angle-right'></i>";
                    strMenuSubCate += "</li>";

                    //DataTable table_cate = _catenewsBSO.getCateClientGroupUrl(0, Language.language, Convert.ToInt32(dataRow["GroupCate"].ToString()), 6);
                    //if (table_cate.Rows.Count > 0)
                    //{
                    //    strMenuSubCate += "<ul class='list-unstyled simple-list margin-bottom-20'>";
                    //    for (int j = 0; j < table_cate.Rows.Count; j++)
                    //    {
                    //        DataRow dataRow1 = table_cate.Rows[j];

                    //        strMenuSubCate += "<li>";
                    //        if (Convert.ToBoolean(dataRow1["isUrl"].ToString()))
                    //            strMenuSubCate += "<a href='" + dataRow1["Url"].ToString() + "'>" + dataRow1["ShortName"].ToString() + "</a>";
                    //        else
                    //            strMenuSubCate += "<a href='" + ResolveUrl("~/") + "c3/"+ _catenewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow1["CateNewsID"])) + "/" + GetString(dataRow1["CateNewsName"]) + "-" + dataRow1["GroupCate"] + "-" + dataRow1["CateNewsID"] + ".aspx'>" + dataRow1["ShortName"].ToString() + "</a>";
                    //        strMenuSubCate += "</li>";
                    //    }
                    //    strMenuSubCate += "</ul>";
                    //}

                   

                  
                }
                strMenuSubCate += "</ul>";
            }
           

            AspNetCache.SetCacheWithTime("HTML_ltlMenuTextLinkFooter_11" + "_" + Language.language.Replace("-", "_"), strMenuSubCate, 150);
            ltlTextLinkMenu.Text = strMenuSubCate;

        }
        else
        {
            ltlTextLinkMenu.Text = (string)AspNetCache.GetCache("HTML_ltlMenuTextLinkFooter_11" + "_" + Language.language.Replace("-", "_"));
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
