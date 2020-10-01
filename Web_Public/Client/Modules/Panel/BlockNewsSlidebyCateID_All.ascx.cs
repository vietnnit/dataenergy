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
using System.Xml;
using System.Xml.Xsl;
using ETO;
using BSO;
using System.Text;
public partial class Client_BlockNewsSlidebyCateID_All : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             int cateID = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out cateID))
                {
                    CateNewsBSO cateNewsBSO = new CateNewsBSO();
                    CateNews cateNews = cateNewsBSO.GetCateNewsById(cateID);
                    int groupcate = cateNews.GroupCate;
                    GetNewsGroup(cateID, groupcate);

                    if (cateID != 0 && cateNews != null)
                    {
                        //lblIcon.Text = "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'>" + "<img class='is_img onLaw2-icon1 onLaw1-Submit-Arrow' src='" + ResolveUrl("~/") + "images/invis.gif' style='border-width: 0px;'>" + "</a>";
                        lblTitle.Text = "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'>" + cateNews.CateNewsName + "</a>";
                    }
                }
        }

    }


    void GetNewsGroup(int cateID, int groupcate)
    {
        //string _value = hddValue.Value.Replace(",", "_").Substring(0, 25);
        string _value = hddValue.Value;
      //  string _value = truongID.ToString();

        String csname1 = "PanelScript_byCateID_" + _value;
        Type cstype = this.GetType();

        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsClientScriptBlockRegistered(cstype, csname1))
        {
            StringBuilder cstext1 = new StringBuilder();
            cstext1.Append("<script type=\"text/javascript\">");
            //cstext1.Append("$(document).ready(function(){");
            cstext1.Append("$(function() {");
            cstext1.Append("$(\"#carousel_newsID_" + _value + "\").carouFredSel({");
            cstext1.Append("items: 5,");
            cstext1.Append("scroll:1,");
            cstext1.Append("circular: true,");
            cstext1.Append("infinite: false,");
            cstext1.Append("direction: \"up\",");
            cstext1.Append("auto: {");
            cstext1.Append("play: true,");
            cstext1.Append("duration: 1000");
            cstext1.Append("},");
            cstext1.Append("height: 355,");
            cstext1.Append("width:295,");
            cstext1.Append("prev: {");
            cstext1.Append("button: \"#prev_" + _value + "\",");
            cstext1.Append("key: \"up\"");
            cstext1.Append("},");
            cstext1.Append("next: {");
            cstext1.Append("button: \"#next_" + _value + "\",");
            cstext1.Append("key: \"down\"");
            cstext1.Append("}");
            cstext1.Append("});");

            cstext1.Append("});");
            cstext1.Append("</script>");

            cs.RegisterClientScriptBlock(cstype, csname1, cstext1.ToString());
        }


        string strCate = GetCateParentIDArrayByID(cateID, groupcate);

        if (AspNetCache.CheckCache("HTML_blockNewsSlidebyCateID_All_" + _value) == false)
        {
            string strHotNewsSlider = "";

            if (strCate != String.Empty && strCate != "")
            {
                NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
                DataTable table = newsGroupBSO.GetNewsGroupByCateHot(strCate, groupcate, "1", Convert.ToInt32(hddRecord.Value), "1", "1");


                if (table.Rows.Count > 0)
                {
                    strHotNewsSlider += "<div id='carousel_newsID_" + _value + "'>";
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow dataRow = table.Rows[i];


                        strHotNewsSlider += "<div class='box-carousel-newsStrID'>";
                        strHotNewsSlider += "<div class='news-list'>";
                        strHotNewsSlider += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                        strHotNewsSlider += "<span>";
                        if (dataRow["ImageThumb"].ToString() != "")
                            strHotNewsSlider += "<img class='is_img' src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(),65) + "' style='border-width: 0px;' alt='" + dataRow["Title"] + "'>";
                        else
                            strHotNewsSlider += "<img class='is_img' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='border-width: 0px;' alt='" + dataRow["Title"] + "'>";
                        strHotNewsSlider += dataRow["Title"];
                        strHotNewsSlider += "</span>";
                        strHotNewsSlider += "</a>";
                        strHotNewsSlider += "<div class='clr'></div>";
                        strHotNewsSlider += "</div>";
                        strHotNewsSlider += "</div>";

                    }
                    strHotNewsSlider += "</div>";
                    strHotNewsSlider += "<div class='clearfix'>";
                    strHotNewsSlider += "</div>";
                    strHotNewsSlider += "<a class='prev-newsStrID' id='prev_" + _value + "' href='#'><span>up</span></a>";
                    strHotNewsSlider += "<a class='next-newsStrID' id='next_" + _value + "' href='#'><span>down</span></a>";

                }
            }
            // + hddValue.Value.Replace(",", "_").Substring(0, 10)
            AspNetCache.SetCacheWithTime("HTML_blockNewsSlidebyCateID_All_" + _value, strHotNewsSlider, 150);
            ltlHotNewsSlider.Text = strHotNewsSlider;

        }
        else
        {
            ltlHotNewsSlider.Text = (string)AspNetCache.GetCache("HTML_blockNewsSlidebyCateID_All_" + _value);
        }



    }

    private string GetCateParentIDArrayByID(int cID, int group)
    {
        string strArrayID = Convert.ToString(cID) + ",";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = cateNewsBSO.GetCateParentGroupAll(cID, Language.language, group);
        DataTable table2 = new DataTable();
        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()), group);

            }

        }

        return strArrayID;

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
