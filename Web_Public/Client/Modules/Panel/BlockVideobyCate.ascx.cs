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
using System.Text;
public partial class Client_BlockVideobyCate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

             int cateID = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out cateID))
                {
                    ViewVideo(cateID);
                    VideosCateBSO videoCateBSO = new VideosCateBSO();
                    VideosCate videoCate = videoCateBSO.GetVideosCateById(cateID);
                    //string strIcon = "";
                    if (videoCate != null)
                    {
                        string strTitle = "<a class='news_cm_tt_a' style='float:left' href='" + ResolveUrl("~/") + "thu-vien-video/" + GetString(videoCate.VideosCateName) + "-" + videoCate.VideosCateID + ".aspx' title='" + videoCate.VideosCateName + "'>" + videoCate.VideosCateName + "</a>";
                        lblTitle.Text = strTitle;
                        //strIcon += "<a href='" + ResolveUrl("~/") + "thu-vien-video/" + GetString(videoCate.VideosCateName) + "-" + GetString(videoCate.VideosCateName) + "-" + videoCate.VideosCateID + ".aspx' title='" + videoCate.VideosCateName + "'>";
                        //strIcon += "<img class='is_img onLaw2-icon1 onLaw1-Submit-Arrow' src='" + ResolveUrl("~/") + "images/invis.gif' style='border-width: 0px;'>";
                        //strIcon += "</a>";
                        //lblIcon.Text = strIcon;
                    }
                }
        }

        
    }


    private void ViewVideo(int cID)
    {
        // string strCate = GetCateParentIDArrayByID(cID);
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("tbl_PanelVideobyCate_" + cID) == false)
        {
            VideosBSO videosBSO = new VideosBSO();
            table = videosBSO.GetVideosHot(Convert.ToInt32(hddRecord.Value), "1", cID, Language.language);

            AspNetCache.SetCacheWithTime("tbl_PanelVideobyCate_" + cID, table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_PanelVideobyCate_" + cID);
        }

        rptVideo.DataSource = table;
        rptVideo.DataBind();
        //string str1 = "";
        //string str2 = "";

        //if (table.Rows.Count > 0)
        //{
        //    str2 += "<ul>";
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        DataRow row = table.Rows[i];
        //        if (i == 0)
        //        {
        //            str1 += "<div class='boxVideo_wrapper' style='position: relative; width: 420px; height: 250px;'>";
        //            if (Convert.ToBoolean(row["VideosType"]))
        //                str1 += @"<iframe title='Video Player' width='420' height='250' src='" + row["VideosUrl"] + "' frameborder='0' allowfullscreen=''></iframe>";
        //            else
        //                str1 += @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='420' height='250'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" + config.WebDomain + "/Upload/Videos/Files/" + row["FileName"] + "&title=" + row["Title"] + "&startimage=" + ResolveUrl("~/") + "Upload/Videos/VideosImg/ImgLarge/" + row["ImageLarge"] + "&width=420&height=250&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" + row["Description"] + "&shortcut=1&showtitleandstartimage=0' /></object>";
        //            str1 += "</div>";

        //            str1 += "<div class='video_home_info'>";
        //            str1 += "<a href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "' class='video_home_tt'>";
        //            str1 += row["Title"];
        //            str1 += "</a>";
        //            str1 += "<p class='video_home_sapo'>";
        //            str1 += row["Description"];
        //            str1 += "</p>";
        //            str1 += "</div>";
        //        }
        //        else
        //        {
        //            str2 += "<li>";
        //            str2 += "<a class='lnk_img' href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "'>";
        //            str2 += "<img alt='" + row["Title"] + "' src='" + ResolveUrl("~/") + "Upload/Videos/VideosImg/ImgThumb/" + row["ImageThumb"] + "'>";
        //            str2 += "</a>";
        //            str2 += "<a class='video_home_tt clred' href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "'>";
        //            str2 += row["Title"];
        //            str2 += "</a>";
        //            str2 += "<div class='clr'> </div>";
        //            str2 += "</li>";

        //        }
        //    }
        //    str2 += "</ul>";
        //    // str2 += "<a class='xemthem2' href='"+ ResolveUrl("~/") + "thu-vien-video/"+cID+".aspx' title='Xem thêm'>Xem thêm</a>";
        //}
        //ltlVideoHot1.Text = str1;
        //ltlHotOther.Text = str2;

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
