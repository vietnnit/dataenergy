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
public partial class Client_BlockVideoHot : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //int cateID = Convert.ToInt32(hddValue.Value);
            //ViewVideo(cateID);
            //VideosCateBSO videoCateBSO = new VideosCateBSO();
            //VideosCate videoCate = videoCateBSO.GetVideosCateById(cateID);
            //string strIcon = "";
            //if (videoCate != null)
            //{
            string strTitle = "<a class='news_cm_tt_a' style='float:left' href='" + ResolveUrl("~/") + "thu-vien-video.aspx' title='" + Resources.resource.T_Video + "'>" + Resources.resource.T_Video + "</a>";
                lblTitle.Text = strTitle;
                //strIcon += "<a href='" + ResolveUrl("~/") + "thu-vien-video.aspx' title='Video nổi bật'>";
                //strIcon += "<img class='is_img onLaw2-icon1 onLaw1-Submit-Arrow' src='" + ResolveUrl("~/") + "images/invis.gif' style='border-width: 0px;'>";
                //strIcon += "</a>";
                //lblIcon.Text = strIcon;
                ViewVideo();
            //}
        }

        
    }


    private void ViewVideo()
    {
        // string strCate = GetCateParentIDArrayByID(cID);
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("tbl_PanelVideoHot_") == false)
        {
            VideosBSO videosBSO = new VideosBSO();
            table = videosBSO.GetVideosHot(Convert.ToInt32(hddRecord.Value), "1", Language.language);

            AspNetCache.SetCacheWithTime("tbl_PanelVideoHot_", table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_PanelVideoHot_");
        }

        rptVideo.DataSource = table;
        rptVideo.DataBind();
      

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