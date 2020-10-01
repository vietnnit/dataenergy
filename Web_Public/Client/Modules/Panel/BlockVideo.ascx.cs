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
public partial class Client_BlockVideo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewVideo();
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

        VideosBSO videosBSO = new VideosBSO();
        Videos video = videosBSO.GetVideosHotTop1("1", Language.language);
        if (video != null)
        {
            if (video.VideosType == true)
                ltlVideo.Text = @"<iframe title='Video Player' width='100%' height='220' src='" + video.VideosUrl + "' frameborder='0' allowfullscreen=''></iframe>";
            else
                ltlVideo.Text = @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='246' height='190'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" + config.WebDomain + video.FileName + "&title=" + video.Title + "&startimage=" + video.ImageThumb + "&width=246&height=190&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" + video.Description + "&shortcut=1&showtitleandstartimage=0' /></object>";
        }
        
    }
}
