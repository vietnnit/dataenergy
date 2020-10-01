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
public partial class Client_VideoHotListPlayer : System.Web.UI.UserControl
{
    public string PathFileAudio = "";
    public string PathFileImg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string strTitle = "<a class='news_cm_tt_a' style='float:left' href='" + ResolveUrl("~/") + "thu-vien-video.aspx' title='Thư viện Video'>Thư viện Video</a>";
            //lblTitle.Text = strTitle;

            ViewVideo();
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
        if (AspNetCache.CheckCache("tbl_MainHomeVideoHot" + "_" + Language.language.Replace("-", "_")) == false)
        {
            VideosBSO videosBSO = new VideosBSO();
            table = videosBSO.GetVideosHot(5, "1", Language.language);

            AspNetCache.SetCacheWithTime("tbl_MainHomeVideoHot" + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_MainHomeVideoHot" + "_" + Language.language.Replace("-", "_"));
        }

        string str1 = "";
        string str2 = "";

        if (table.Rows.Count > 0)
        {
            //str2 += "<ul>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                if (i == 0)
                {
                    //str1 += "<div class='boxVideo_wrapper' style='position: relative; width: 470px; height: 280px;'>";
                    //if ( Convert.ToBoolean(row["VideosType"]))
                    //    str1 += @"<iframe title='Video Player' width='470' height='280' src='" + row["VideosUrl"] + "' frameborder='0' allowfullscreen=''></iframe>";
                    //else
                    //    str1 += @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='470' height='280'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" + config.WebDomain + "/Upload/Videos/Files/" + row["FileName"] + "&title=" + row["Title"] + "&startimage=" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/Videos/VideosImg/ImgLarge/" + row["ImageLarge"],480) + "&width=470&height=280&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" + row["Description"] + "&shortcut=1&showtitleandstartimage=0' /></object>";
                    //str1 += "</div>";

                    if (Convert.ToBoolean(row["VideosType"]))
                        PathFileAudio = row["VideosUrl"].ToString();
                    else
                    {
                        PathFileAudio = config.WebDomain + row["FileName"];


                    }

                    PathFileImg = row["ImageLarge"].ToString();


                    str1 += "<div class='video_home_info'>";
                    str1 += "<a href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "' class='video_home_tt'>";
                    str1 += row["Title"];
                    str1 += "</a>";
                    //str1 += "<p class='video_home_sapo'>";
                    //str1 += Tool.SubString(Tool.StripTagsCharArray(row["Description"].ToString()),350);
                    //str1 += "</p>";
                    str1 += "</div>";
                }
                else
                {
                    
                    str2 += "<div class='col-sm-6 view_hot_video'>";
                    str2 += "<div class='view view-tenth embed-image ratio-16-9'>";
                    str2 += "<a href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "'>";
                    str2 += "<img class='img-responsive' alt='" + row["Title"] + "' src='" + Utils.getURLThumbImage(row["ImageLarge"].ToString(), 300) + "'>";
                    
                    str2 += "<div class='mask'>";
                    str2 += "<h2>" + row["Title"] + "</h2>";
                    //str2 += "<p>At vero eos et accusamus et iusto odio dignissimos dolores et quas molestias excepturi sint occaecati cupiditate non provident.</p>";
                    str2 += "<a href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "' class='info'>Xem</a>";
                    str2 += "</div>";
                    str2 += "</a>";
                    str2 += "</div>";
                    str2 += "</div>";
                    //str2 += "<div class='col-sm-6'>";
                    //str2 += "<div class='view view-tenth'>";
                    //str2 += "<img class='img-responsive' src='assets/img/main/img10.jpg' alt=''>";
                    //str2 += "<div class='mask'>";
                    //str2 += "<h2>Portfolio Item</h2>";
                    //str2 += "<p>At vero eos et accusamus et iusto odio dignissimos dolores et quas molestias excepturi sint occaecati cupiditate non provident.</p>";
                    //str2 += "<a href='portfolio_old_item.html' class='info'>Read More</a>";
                    //str2 += "</div> ";
                    //str2 += "</div>";
                    //str2 += "</div>";
                    

                    //str2 += "<li>";
                    //str2 += "<a class='lnk_img' href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "'>";
                    //str2 += "<img alt='" + row["Title"] + "' src='" + Utils.getURLThumbImage(row["ImageThumb"].ToString(), 100) + "'>";
                    //str2 += "</a>";
                    //str2 += "<a class='video_home_tt clred' href='" + ResolveUrl("~/") + "thu-vien-videos/" + GetString(row["Title"]) + "-" + row["VideosCateID"] + "-" + row["VideosID"] + ".aspx' title='" + row["Title"] + "'>";
                    //str2 += row["Title"];
                    //str2 += "</a>";
                    //str2 += "<div class='clr'> </div>";
                    //str2 += "</li>";

                }
            }
            //str2 += "</ul>";
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
