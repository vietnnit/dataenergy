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
public partial class Client_BannerMenuTop : System.Web.UI.UserControl
{
    MemberValidation m_UserValidation = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            rptAdv.DataSource = ViewMenuTop(hddValue.Value);
            rptAdv.DataBind();

            rptAdv2.DataSource = ViewMenuTop(hddValue2.Value);
            rptAdv2.DataBind();
            liSignOut.Visible = false;
            //liSignIn.Visible = true;

            //if (m_UserValidation.IsSigned())
            //{
            //    //liSignIn.Visible = false;
            //    liSignOut.Visible = true;
            //    ltInfoUser.Text = "Xin chào: <span class='text-danger'>" + m_UserValidation.UserName + "</span>";
            //}

        }

    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        m_UserValidation.SignOut();
        Response.Redirect("~/Default.aspx");
    }
    private DataTable ViewMenuTop(string value)
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("Menutop_" + value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            table = _menulink.GetHotMenuLinks(value, Language.language);
            AspNetCache.SetCacheWithTime("Menutop_" + value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Menutop_" + value + "_" + Language.language.Replace("-", "_"));
        }

        return table;
    }

    protected void rptAdv_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        //LinkButton btnLink = (LinkButton)e.Item.FindControl("btnLink");
        //btnLink.ToolTip = DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString();

        //string Imgthumb = DataBinder.Eval(e.Item.DataItem, "MenuLinksIcon").ToString();
        //Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlICON");
        //if (Imgthumb != "")
        //    ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/MenuLinks/" + Imgthumb + "' width='" + DataBinder.Eval(e.Item.DataItem, "Width").ToString() + "' height='" + DataBinder.Eval(e.Item.DataItem, "Height").ToString() + "' alt='" + DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString() + "' >";

    }
    protected void rptAdv_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
        if (e.CommandName == "_link")
        {
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            menuLinksBSO.MenuLinksClickUpdate(mID);

            Response.Redirect(menuLinksBSO.GetMenuLinksById(mID).MenuLinksUrl);

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string _keyword = Tool.StripTagsCharArray(Slugify(txtkeyword.Text));

        if (_keyword != "")
        {
            Session["keyword"] = _keyword;
            Response.Redirect("~/tim-kiem/" + GetString(_keyword) + ".aspx");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string _keyword = Tool.StripTagsCharArray(Slugify(txtkeyword.Text));

        if (_keyword != "")
        {
            Session["keyword"] = _keyword;
            Response.Redirect("~/tim-kiem/" + GetString(_keyword) + ".aspx");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    public static string RemoveAccent(string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }

    public static string Slugify(string phrase)
    {
        //string str = RemoveAccent(phrase).ToLower();
        string str = phrase;
        str = System.Text.RegularExpressions.Regex.Replace(str, @"[^\w\.@-]", " "); // Remove all non valid chars          
        str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
        //str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
        return str;
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
