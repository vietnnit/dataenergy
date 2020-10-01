using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Client_BlockSearchBanner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string keyword = Request["keyword"];
            if (!String.IsNullOrEmpty(keyword) && keyword.Trim() != "")
            {
                keyword = keyword.Replace("'", "");
                keyword = keyword.Replace("-", " ");
                txtkeyword.Text = keyword;
            }

        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string _keyword = safeString(txtkeyword.Text);
        if (_keyword != "")
        {
            _keyword = _keyword.Replace(" ", "-");
            Response.Redirect("~/tim-kiem-1/" + Server.UrlEncode(_keyword) + ".aspx");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string _keyword = safeString(txtkeyword.Text);
        if (_keyword != "")
        {
            _keyword = _keyword.Replace(" ", "-");
            Response.Redirect("~/tim-kiem/" + Server.UrlEncode(_keyword) + ".aspx");
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    public static string safeString(string unSafe)
    {
        return removeStr(unSafe, Bad_String);
    }

    private static string removeStr(string strRaw, string[] badStr)
    {
        if (string.IsNullOrEmpty(strRaw)) return "";
        int i;
        string tmp = strRaw.ToLower();
        foreach (string remove in badStr)
        {
            i = tmp.IndexOf(remove);
            if (i > -1)
            {
                int n = tmp.Length;
                if (n > 1)
                {
                    int j = tmp.IndexOfAny(new char[] { ';', '-', ' ' }, i);
                    if (j - i > n) n = j - i;
                }
                tmp = tmp.Remove(i, n);
                strRaw = strRaw.Remove(i, n);
            }
        }
        return strRaw.Trim();
    }

    private static string[] Bad_String = { "'", "\\", "<", ">", "--", "select", "insert", "update", "delete", "drop", "exec", "sp_", "xp_", "html" };

}
