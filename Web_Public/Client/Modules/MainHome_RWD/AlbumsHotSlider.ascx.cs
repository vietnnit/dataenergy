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
public partial class Client_AlbumsHotSlidert : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewAlbum();
        }
    }
    private void ViewAlbum()
    {
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("tbl_MainHomeAlbumHot" + "_" + Language.language.Replace("-", "_")) == false)
        {

            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            table = albumscateBSO.GetAlbumsCate(Language.language);

            DataTable table1 = table.Clone();
            for (int i = 0; i < Convert.ToInt32(hddRecord.Value); i++)
            {
                if (i >= table.Rows.Count)
                    break;
                table1.ImportRow(table.Rows[i]);
            }
            table = table1;
            AspNetCache.SetCacheWithTime("tbl_MainHomeAlbumHot" + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_MainHomeAlbumHot" + "_" + Language.language.Replace("-", "_"));
        }

        //rptAlbums.DataSource = table.Rows.Cast<System.Data.DataRow>().Take(3);
        rptAlbums.DataSource = table;
        rptAlbums.DataBind();

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