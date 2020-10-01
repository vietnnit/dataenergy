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
public partial class Client_VideoHot : System.Web.UI.UserControl
{
    public string PathFileAudio = "";
    public string PathFileImg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewVideo();
            //string strTitle = "<a class='h2-cate' href='" + ResolveUrl("~/") + "thu-vien-video.aspx' title='" + Resources.resource.T_Video + "'><span>" + Resources.resource.T_Video + "</span></a>";
            //lblTitle.Text = strTitle;
        }
    }

    private void ViewVideo()
    {

        Config config = new Config();
        if (AspNetCache.CheckCache("Config_" + Language.language) == false)
        {
            ConfigBSO configBSO = new ConfigBSO();

            config = configBSO.GetAllConfig(Language.language);
            AspNetCache.SetCacheWithTime("Config_" + Language.language, config, 150);
        }
        else
        {
            config = (Config)AspNetCache.GetCache("Config_" + Language.language);
        }
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("tbl_MainHomeVideoHot") == false)
        {
            VideosBSO videosBSO = new VideosBSO();
            table = videosBSO.GetVideosHot(1, "1", Language.language);

            AspNetCache.SetCacheWithTime("tbl_MainHomeVideoHot", table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_MainHomeVideoHot");
        }

        string str1 = "";
       
        if (table.Rows.Count > 0)
        {
            //str2 += "<ul>";
            DataRow row = table.Rows[0];
            //str1 += "<div class='videos'>";
            //str1 += "<div class='videos_ul'>";
            //str1 += "<div class='item-video-frame-simple'>";
            //str1 += "<div class='boxVideo_wrapper' style='position: relative; width: 100%; height: 230px; padding: 4px 0 0 5px;'>";
            //if (Convert.ToBoolean(row["VideosType"]))
            //    str1 += @"<iframe title='Video Player' width='100%' height='220' src='" + row["VideosUrl"] + "' frameborder='0' allowfullscreen=''></iframe>";
            //else
            //    str1 += @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='285' height='205'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" + config.WebDomain + row["FileName"] + "&title=" + row["Title"] + "&startimage=" + row["ImageLarge"] + "&width=285&height=205&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" + row["Description"] + "&shortcut=1&showtitleandstartimage=0' /></object>";
            //str1 += "</div>";
            //str1 += "</div>";
            //str1 += "</div>";
            //str1 += "</div>";

            if (Convert.ToBoolean(row["VideosType"]))
                PathFileAudio = row["VideosUrl"].ToString();
            else
            {
                PathFileAudio = config.WebDomain + row["FileName"];


            }

            PathFileImg = row["ImageLarge"].ToString();


            str1 += "<div class='video_home_info-none'>";
            str1 += "<a href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "' class='video_home_tt'>";
            str1 += row["Title"];
            str1 += "</a>";
            //str1 += "<p class='video_home_sapo'>";
            //str1 += row["Description"];
            //str1 += "</p>";
            str1 += "</div>";

            //}
            ////str2 += "</ul>";
            //   str2 += "<a class='xemthem2' href='"+ ResolveUrl("~/") + "thu-vien-video.aspx' title='Xem thêm'>Xem thêm</a>";
        }
        ltlVideoHot1.Text = str1;
        //ltlHotOther.Text = str2;

        //if (video != null)
        //{
        //    if (video.VideosType == true)
        //        ltlVideo.Text = @"<iframe title='Video Player' width='253' height='180' src='" + video.VideosUrl + "' frameborder='0' allowfullscreen=''></iframe>";
        //    else
        //        ltlVideo.Text = @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='253' height='180'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" + config.WebDomain + "/Upload/Videos/Files/" + video.FileName + "&title=" + video.Title + "&startimage=" + ResolveUrl("~/") + "Upload/Videos/VideosImg/ImgThumb/" + video.ImageThumb + "&width=253&height=180&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" + video.Description + "&shortcut=1&showtitleandstartimage=0' /></object>";
        //}

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
