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

public partial class Client_BlockAlbum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewAlbum();
        lblTitle.Text = "<a href='" + ResolveUrl("~/") + "thu-vien-anh.aspx' >" + Resources.resource.T_Gallery + "</a>";
    }


    private void ViewAlbum()
    {
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("HTML_ltlAlbumSlider_" + Language.language) == false)
        {

            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            table = albumscateBSO.GetAlbumsCate(Language.language);

            AspNetCache.SetCacheWithTime("HTML_ltlAlbumSlider_" + Language.language, table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("HTML_ltlAlbumSlider_" + Language.language);
        }


        string text = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];

                text += "<li>";
                text += "<a href='" + ResolveUrl("~/") + "thu-vien-anh/" + GetString(dataRow["AlbumsCateName"]) + "-" + dataRow["AlbumsCateID"] + ".aspx' title='" + dataRow["AlbumsCateName"] + "' target='_blank'>";

                if (dataRow["ImageThumb"].ToString() != "")
                    text += "<img src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(),295) + "' vspace='1' class='imgalbum_slider'>";
                else
                    text += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",295) + "' vspace='1' class='imgalbum_slider'>";
                text += "</a>";

                text += "<p class='flex-caption'>" + dataRow["AlbumsCateName"].ToString() + "</p>";
                text += "</li>";
            }
        }

        ltlAlbumSlider.Text = text;
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

